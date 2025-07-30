using Domen;
using Domen.DTO;
using KlijentskaStrana.Session;
using Komunikacija;
using Logika;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KlijentskaStrana.GUIKontroler
{
    public class RacunKontroler
    {
        public int TrenutniRacunId { get; set; }
        public int SelektovaniRb { get; set; }
        private FrmRačun forma;
        private Klijent klijent => Session.Session.Instance.Klijent;
        private Bioskop bioskop => Session.Session.Instance.CurrentBioskop as Bioskop;
        private int idRacun = 0;
        private double ukupnaCena;

        public RacunKontroler(FrmRačun forma)
        {
            this.forma = forma;
            forma.TxtBioskop.Text = bioskop.NazivBioskopa;
            NapuniCmbGledalac();
        }

        private void NapuniCmbGledalac()
        {
            forma.CmbGledalac.DataSource = Kontroler.Instance.VratiGledaoce();
            forma.CmbGledalac.DisplayMember = "Prikaz";
            forma.CmbGledalac.ValueMember = "IdGledalac";
            forma.CmbGledalac.SelectedIndex = -1;
        }

        public void KreirajRacun()
        {
            if (forma.DtpDatum.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Datum ne može biti u prošlosti.");
                return;
            }
            if (forma.CmbGledalac.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite gledaoca.");
                return;
            }

            Racun r = new Racun
            {
                Datum = forma.DtpDatum.Value.Date,
                UkupnaCena = 0,
                IdGledalac = (int)forma.CmbGledalac.SelectedValue,
                IdBioskop = bioskop.IdBioskop
            };

            Poruka zahtev = new Poruka { Object = r, Operacija = Operacija.PretražiRacun };
            klijent.PošaljiPoruku(zahtev);

            Poruka odgovor = klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je kreirao račun.");
                idRacun = Kontroler.Instance.VratiIdNajnovijegRacuna();

                var uc = new UcStavkaRacunacs
                {
                  
                    Dock = DockStyle.Fill
                };
                uc.StavkaDodata += (razlikaUCeni) =>
                {
                    OsvežiDGV();
                    AzurirajUkupnuCenu();
                };
                uc.StavkaPromenjena += () =>
                {
                    OsvežiDGV();
                    OsveziTabeluRacuna();
                };
                uc.UcitajFilmove();

                forma.PnlStavka.Controls.Clear();
                forma.PnlStavka.Controls.Add(uc);
            }
            else
            {
                MessageBox.Show("Greška pri kreiranju računa.");
            }
        }

      

        public void PretraziRacune()
        {
            var r = new Racun
            {
                Datum = forma.DtpDatum.Value.Date,
                IdGledalac = forma.CmbGledalac.SelectedIndex != -1 ? (int)forma.CmbGledalac.SelectedValue : 0,
                IdBioskop = bioskop.IdBioskop
            };

            forma.DgvRacuni.DataSource = null;
            forma.DgvRacuni.DataSource = Kontroler.Instance.VratiRacun(r);
            forma.DgvRacuni.Columns["IdGledalac"].Visible = false;
            forma.DgvRacuni.Columns["IdBioskop"].Visible = false;
        }

        public void PrikaziDetalje()
        {
            if (forma.DgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite račun.");
                return;
            }

            var prikaz = (PrikazRacuna)forma.DgvRacuni.SelectedRows[0].DataBoundItem;

            forma.CmbGledalac.SelectedValue = prikaz.IdGledalac;
            forma.DtpDatum.Value = prikaz.Datum;
            forma.TxtUkupnaCena.Text = prikaz.UkupnaCena.ToString("F2");
            idRacun = prikaz.IdRacun;

            OsvežiDGV();
        }

        private void OsvežiDGV()
        {
            var stavke = Kontroler.Instance.VratiStavkeRacuna(idRacun);
            forma.DgvRacunStavke.DataSource = null;
            forma.DgvRacunStavke.DataSource = stavke;

            double ukupno = stavke.Sum(s => s.Cena);
            forma.TxtUkupnaCena.Text = ukupno.ToString("F2");
        }

        public void IzmeniRacun()
        {
            var r = new Racun
            {
                IdRacun = idRacun,
                Datum = forma.DtpDatum.Value,
                IdGledalac = (int)forma.CmbGledalac.SelectedValue,
                IdBioskop = bioskop.IdBioskop,
                UkupnaCena = double.Parse(forma.TxtUkupnaCena.Text)
            };

            Poruka zahtev = new Poruka { Operacija = Operacija.IzmeniRacun, Object = r };
            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
                MessageBox.Show("Račun uspešno izmenjen.");
            else
                MessageBox.Show("Greška pri izmeni računa.");
        }

        public void ObrisiRacun()
        {
            if (forma.DgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite račun za brisanje.");
                return;
            }

            var prikaz = (PrikazRacuna)forma.DgvRacuni.SelectedRows[0].DataBoundItem;

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.ObrisiRacun,
                Object = new Racun { IdRacun = prikaz.IdRacun }
            };

            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Račun obrisan.");
                OsveziTabeluRacuna();
                forma.DgvRacunStavke.DataSource = null;
                forma.TxtUkupnaCena.Clear();
                forma.PnlStavka.Controls.Clear();
            }
            else
            {
                MessageBox.Show("Greška pri brisanju računa.");
            }
        }

        private void AzurirajUkupnuCenu()
        {
            var stavke = Kontroler.Instance.VratiStavkeRacuna(idRacun);
            double ukupno = stavke.Sum(s => s.Cena);

            Poruka azuriraj = new Poruka
            {
                Operacija = Operacija.AzurirajUkupnuCenu,
                Object = Tuple.Create(idRacun, ukupno)
            };

            klijent.PošaljiPoruku(azuriraj);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija != Operacija.Uspešno)
            {
                MessageBox.Show("Greška pri ažuriranju ukupne cene.");
            }

            forma.TxtUkupnaCena.Text = ukupno.ToString("F2");
        }

        private void OsveziTabeluRacuna()
        {
            var kriterijum = new Racun { IdBioskop = bioskop.IdBioskop };
            forma.DgvRacuni.DataSource = null;
            forma.DgvRacuni.DataSource = Kontroler.Instance.VratiRacun(kriterijum);
            forma.DgvRacuni.Columns["IdGledalac"].Visible = false;
            forma.DgvRacuni.Columns["IdBioskop"].Visible = false;
        }
        public List<Film> VratiFilmove()
        {
            return Kontroler.Instance.VratiFilmove();
        }

      public bool DodajStavku(StavkaRacuna stavka)
{
    stavka.IdRacun = idRacun;
    stavka.Rb = Kontroler.Instance.VratiSledeciRbZaRacun(idRacun); 

    Poruka zahtev = new Poruka
    {
        Operacija = Operacija.DodajStavkuRacuna,
        Object = stavka
    };
    klijent.PošaljiPoruku(zahtev);
    Poruka odgovor = klijent.PrimiPoruku();

    return odgovor.Operacija == Operacija.Uspešno;
}

        public bool IzmeniStavku(StavkaRacuna stavka)
        {
            Poruka zahtev = new Poruka { Operacija = Operacija.IzmeniStavkuRacuna, Object = stavka };
            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            var odgovor = Session.Session.Instance.Klijent.PrimiPoruku();
            return odgovor.Operacija == Operacija.Uspešno;
        }
        public void DodajStavku()
        {
            if (idRacun == 0)
            {
                MessageBox.Show("Prvo kreirajte račun.");
                return;
            }
            PrikaziUserControlZaStavke();
        }
        private void PrikaziUserControlZaStavke()
        {
            var uc = new UcStavkaRacunacs
            {
                IdRacun = idRacun,
                Klijent = Session.Session.Instance.Klijent,
                Bioskop = Session.Session.Instance.CurrentBioskop
            };

            uc.StavkaDodata += (razlika) =>
            {
                ukupnaCena += razlika;
                forma.TxtUkupnaCena.Text = ukupnaCena.ToString("F2");
                OsveziStavke();
                AzurirajUkupnuCenu();
            };

            uc.StavkaPromenjena += () =>
            {
                OsveziStavke();
                PretraziRacune();
            };

            uc.UcitajFilmove();

            forma.PnlStavka.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            forma.PnlStavka.Controls.Add(uc);
        }
        private void OsveziStavke()
        {
            var stavke = Kontroler.Instance.VratiStavkeRacuna(idRacun);
            forma.DgvRacunStavke.DataSource = null;
            forma.DgvRacunStavke.DataSource = stavke;
        }

    }
}

