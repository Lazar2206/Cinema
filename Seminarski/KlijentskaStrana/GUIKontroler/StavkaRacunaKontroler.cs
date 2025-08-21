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

       
        private StavkaRacuna trenutnaStavka;
        private readonly RacunKontroler racunKontroler;

        public StavkaRacunaKontroler(FrmStavkaRacuna frm, RacunKontroler racunKontroler)
        {
            forma = frm;
            this.racunKontroler = racunKontroler;

        }

       public void DodajStavku()
{
    if (!ValidirajUnos(out string opis, out double cena, out int idFilma))
    {
        
        return;
    }

    var racun = Session.Session.Instance.TrenutniRacun;
    if (racun == null || racun.IdRacun == 0)
    {
        MessageBox.Show("Sistem ne može da zapamti račun");
        return;
    }

    try
    {
        int sledeciRb = Kontroler.Instance.VratiSledeciRbZaRacun(racun.IdRacun);

        var stavka = new StavkaRacuna
        {
            Rb = sledeciRb,
            Opis = opis,
            Cena = cena,
            IdFilm = idFilma,
            IdRacun = racun.IdRacun
        };

        PosaljiPoruku(Operacija.DodajStavkuRacuna, stavka);
    }
    catch
    {
        MessageBox.Show("Sistem ne može da zapamti račun");
    }
}

        public void IzmeniStavku()
        {
            var prikaz = Session.Session.Instance.TrenutnaStavkaRacuna as PrikazStavkeRacuna;
            if (prikaz == null)
            {
                MessageBox.Show("Sistem ne može da izmeni račun");
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
                MessageBox.Show("Sistem ne može da obriše račun");
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

            if (string.IsNullOrWhiteSpace(opis) || !cenaValid || !filmValid)
            {
                MessageBox.Show("Sistem ne može da zapamti racun");
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
                    MessageBox.Show($"Sistem je {OpisOperacije(operacija)}.");
                    OcistiPolja();
                }
                else
                {
                    MessageBox.Show($"Sistem nije {OpisOperacije(operacija)}.");
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
                case Operacija.DodajStavkuRacuna: return "zapamtio račun";
                case Operacija.IzmeniStavkuRacuna: return "izmenio račun";
                case Operacija.ObrisiStavkuRacuna: return "obrisao račun";
                default: return operacija.ToString().ToLower();
            }
        }
    }
}