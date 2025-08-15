using Domen;
using Domen.DTO;
using KlijentskaStrana.GUIKontroler;
using Komunikacija;
using Logika;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KlijentskaStrana.Forme
{
    public class StavkaRacunaKontroler
    {
        private readonly FrmStavkaRacuna forma;
        private Klijent klijent => Session.Session.Instance.Klijent;

        // Možeš čuvati trenutno izabranu stavku
        private StavkaRacuna trenutnaStavka;
        private readonly RacunKontroler racunKontroler;

        public StavkaRacunaKontroler(FrmStavkaRacuna frm, RacunKontroler racunKontroler)
        {
            forma = frm;
            this.racunKontroler = racunKontroler;

            forma.BtnDodaj.Click += (s, e) => { DodajStavku(); racunKontroler.OsveziStavke(); };
            forma.BtnIzmeni.Click += (s, e) => { IzmeniStavku(); racunKontroler.OsveziStavke(); };
            forma.BtnObrisi.Click += (s, e) => { ObrisiStavku(); racunKontroler.OsveziStavke(); };
        }

        public void DodajStavku()
        {
            var prikaz = Session.Session.Instance.TrenutnaStavkaRacuna as PrikazStavkeRacuna;
            int idRacun= prikaz.IdRacun;
            if (idRacun == 0)
            {
                MessageBox.Show("Prvo izaberite račun.");
                return;
            }

            if (!ValidirajUnos(out string opis, out double cena, out int idFilma))
                return;

            try
            {
                int sledeciRb = Kontroler.Instance.VratiSledeciRbZaRacun(idRacun);

                var stavka = new StavkaRacuna
                {
                    Rb = sledeciRb,
                    Opis = opis,
                    Cena = cena,
                    IdFilm = idFilma,
                    IdRacun = idRacun
                };

                PosaljiPoruku(Operacija.DodajStavkuRacuna, stavka);

            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri dodavanju stavke");
            }
        }

        public void IzmeniStavku()
        {
            var prikaz = Session.Session.Instance.TrenutnaStavkaRacuna as PrikazStavkeRacuna;
            if (prikaz == null)
            {
                MessageBox.Show("Niste selektovali nijednu stavku.");
                return;
            }

            if (!ValidirajUnos(out string opis, out double cena, out int idFilma))
                return;

            var stavka = new StavkaRacuna
            {
                Rb = prikaz.Rb,
                Opis = opis,
                Cena = cena,
                IdFilm = idFilma,
                IdRacun = prikaz.IdRacun
            };

            PosaljiPoruku(Operacija.IzmeniStavkuRacuna, stavka);
        }

        public void ObrisiStavku()
        {
            var prikaz = Session.Session.Instance.TrenutnaStavkaRacuna as PrikazStavkeRacuna;
            if (prikaz == null)
            {
                MessageBox.Show("Niste selektovali nijednu stavku.");
                return;
            }

            if (!ValidirajUnos(out string opis, out double cena, out int idFilma))
                return;

            var stavka = new StavkaRacuna
            {
                Rb = prikaz.Rb,
                Opis = opis,
                Cena = cena,
                IdFilm = idFilma,
                IdRacun = prikaz.IdRacun
            };

            PosaljiPoruku(Operacija.ObrisiStavkuRacuna, stavka);
        }

        private bool ValidirajUnos(out string opis, out double cena, out int idFilma)
        {
            opis = forma.TxtOpis.Text.Trim();
            cena = 0;      
            idFilma = 0;   

            bool cenaValid = double.TryParse(forma.TxtCena.Text, out cena);
            bool filmValid = forma.CmbFilm.SelectedValue != null &&
                             int.TryParse(forma.CmbFilm.SelectedValue.ToString(), out idFilma);

            if (string.IsNullOrWhiteSpace(opis))
            {
                MessageBox.Show("Unesite opis stavke.");
                return false;
            }

            if (!cenaValid)
            {
                MessageBox.Show("Cena mora biti broj.");
                return false;
            }

            if (!filmValid)
            {
                MessageBox.Show("Izaberite film.");
                return false;
            }

            return true;
        }


        private void PosaljiPoruku(Operacija operacija, StavkaRacuna stavka)
        {
            try
            {
                Poruka zahtev = new Poruka
                {
                    Operacija = operacija,
                    Object = stavka
                };


                klijent.PošaljiPoruku(zahtev);
                Poruka odgovor = klijent.PrimiPoruku();

                if (odgovor.Operacija == Operacija.Uspešno)
                {
                    MessageBox.Show($"Uspešno izvršeno {OpisOperacije(operacija)}.");
                    OcistiPolja();
                }
                else
                {
                    MessageBox.Show($"Greška pri {OpisOperacije(operacija)}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void OcistiPolja()
        {
            forma.TxtOpis.Clear();
            forma.TxtCena.Clear();
            if (forma.CmbFilm.Items.Count > 0)
                forma.CmbFilm.SelectedIndex = 0;

            trenutnaStavka = null;
        }
        private string OpisOperacije(Operacija operacija)
        {
            switch (operacija)
            {
                case Operacija.DodajStavkuRacuna: return "dodavanje stavke";
                case Operacija.IzmeniStavkuRacuna: return "izmena stavke";
                case Operacija.ObrisiStavkuRacuna: return "brisanje stavke";
                default: return operacija.ToString().ToLower();
            }
        }
    }
}