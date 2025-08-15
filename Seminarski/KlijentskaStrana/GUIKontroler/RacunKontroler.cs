using DBBroker;
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
            forma.CmbGledalac.DataSource = Kontroler.Instance.VratiSveGledaoce();
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

                Session.Session.Instance.TrenutniRacun = new Racun
                {
                    IdRacun = idRacun,
                    Datum = forma.DtpDatum.Value.Date,
                    UkupnaCena = 0,
                    IdGledalac = (int)forma.CmbGledalac.SelectedValue,
                    IdBioskop = bioskop.IdBioskop
                };
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

            forma.DgvRacuni.DataSource = Kontroler.Instance.VratiRacun(r);

            forma.DgvRacuni.DataSource = null;
            forma.DgvRacuni.DataSource = Kontroler.Instance.VratiRacun(r);
            forma.DgvRacuni.Columns["IdGledalac"].Visible = false;
            forma.DgvRacuni.Columns["IdBioskop"].Visible = false;
        }

        public void PrikaziDetaljeStavke()
        {
            if (forma.DgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite račun.");
                return;
            }

            var prikaz = (PrikazRacuna)forma.DgvRacuni.SelectedRows[0].DataBoundItem;
            idRacun = prikaz.IdRacun;

            Session.Session.Instance.TrenutniRacun = new Racun
            {
                IdRacun = prikaz.IdRacun,
                Datum = prikaz.Datum,
                UkupnaCena = prikaz.UkupnaCena,
                IdGledalac = prikaz.IdGledalac,
                IdBioskop = bioskop.IdBioskop
            };

            OsvežiDGV();

        }

        private void OsvežiDGV()
        {
            var stavke = Kontroler.Instance.VratiStavkeRacuna(idRacun);
            forma.DgvRacunStavke.DataSource = null;
            forma.DgvRacunStavke.DataSource = stavke;
            forma.DgvRacunStavke.Columns["idRacun"].Visible = false;
            forma.DgvRacunStavke.Columns["idFilm"].Visible = false;

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
        

    

       
        public void DodajStavku()
        {
            if (idRacun == 0)
            {
                MessageBox.Show("Prvo kreirajte račun.");
                return;
            }
            
        }



        public void PrikaziDetaljeJedneStavke()
        {

            var izabranaStavka = (PrikazStavkeRacuna)forma.DgvRacunStavke.CurrentRow.DataBoundItem;
            Session.Session.Instance.TrenutnaStavkaRacuna = izabranaStavka;

            var frm = new FrmStavkaRacuna(this);
            frm.TxtOpis.Text = izabranaStavka.Opis;
            frm.TxtCena.Text = izabranaStavka.Cena.ToString("F2");
            frm.CmbFilm.SelectedValue = izabranaStavka.IdFilm;
            frm.CmbFilm.DisplayMember = "NaslovFilma";
            frm.CmbFilm.ValueMember = "IdFilm";

            frm.ShowDialog();
        }
        public void OsveziStavke()
        {
            
            var racun = Session.Session.Instance.TrenutniRacun;
            if (racun != null)
            {
                
                var stavke = Kontroler.Instance.VratiStavkeRacuna(racun.IdRacun);
                

                var racuni=Kontroler.Instance.VratiRacun(racun);
                forma.DgvRacuni.DataSource = null;
                forma.DgvRacuni.DataSource = racuni;
                forma.DgvRacuni.Columns["IdGledalac"].Visible = false;
                forma.DgvRacuni.Columns["IdBioskop"].Visible = false;
                forma.DgvRacunStavke.DataSource = null;
                forma.DgvRacunStavke.DataSource = stavke;
                forma.DgvRacunStavke.Columns["IdRacun"].Visible = false;
                forma.DgvRacunStavke.Columns["IdFilm"].Visible = false;
           


                forma.TxtUkupnaCena.Text = stavke.Sum(s => s.Cena).ToString("F2");
            }
        }
    }
}

