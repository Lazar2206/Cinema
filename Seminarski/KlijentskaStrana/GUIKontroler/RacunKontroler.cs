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
           forma.BtnDetalji.Enabled = false;
            forma.BtnDetaljiStavke.Enabled = false;
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
                MessageBox.Show("Sistem ne može da kreira račun");
                return;
            }
            if (forma.CmbGledalac.SelectedIndex == -1)
            {
                MessageBox.Show("Sistem ne može da kreira račun");
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
                idRacun = Kontroler.Instance.VratiIdNajnovijegRacuna();

                Session.Session.Instance.TrenutniRacun = new Racun
                {
                    IdRacun = idRacun,
                    Datum = forma.DtpDatum.Value.Date,
                    UkupnaCena = 0,
                    IdGledalac = (int)forma.CmbGledalac.SelectedValue,
                    IdBioskop = bioskop.IdBioskop
                };
                var frm = new FrmStavkaRacuna(this);
                frm.CmbFilm.DataSource = Kontroler.Instance.VratiFilmove();
                frm.CmbFilm.DisplayMember = "Naslov";
                frm.CmbFilm.ValueMember = "IdFilm";
                forma.DgvRacuni.DataSource = null;
                forma.DgvRacuni.DataSource = Kontroler.Instance.VratiRacun(r);
                MessageBox.Show("Sistem je kreirao račun.");
                frm.ShowDialog();
                forma.BtnDetalji.Enabled = true;
                forma.BtnDetaljiStavke.Enabled = true;
            }
            else
            {
                MessageBox.Show("Sistem ne može da kreira račun.");
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
            forma.BtnDetalji.Enabled = true;
            if(Kontroler.Instance.VratiRacun(r).Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe račun za zadate kriterijume");
                return;
            }
        }

        public void PrikaziDetaljeStavke()
        {
            if (forma.DgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe račun");
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
            forma.BtnDetaljiStavke.Enabled = true;
            MessageBox.Show("Sistem je našao račun");

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
            if(forma.DgvRacuni.SelectedRows.Count == 0 || forma.CmbGledalac.SelectedValue==null|| forma.TxtBioskop.Text==null || forma.TxtUkupnaCena.Text==null || idRacun==0 )
            {
                MessageBox.Show("Sistem ne može da zapamti račun");
                return;
            }
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
            {
                PretraziRacune();
                MessageBox.Show("Sistem je zapamtio racun");
            }
          
        }

        public void ObrisiRacun()
        {
            if (forma.DgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sistem ne može da obriše račun");
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
                MessageBox.Show("Sistem je obrisao račun");
                OsveziTabeluRacuna();
                forma.DgvRacunStavke.DataSource = null;
                forma.TxtUkupnaCena.Clear();
             
            }
            else
            {
                MessageBox.Show("Sistem ne može da obriše račun");
            }
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
                MessageBox.Show("Sistem ne može da zapamti račun");
                return;
            }
            
        }



        public void PrikaziDetaljeJedneStavke()
        {

            var izabranaStavka = (PrikazStavkeRacuna)forma.DgvRacunStavke.CurrentRow.DataBoundItem;
            Session.Session.Instance.TrenutnaStavkaRacuna = izabranaStavka;
            MessageBox.Show("Sistem je našao račun");
            var frm = new FrmStavkaRacuna(this);
            frm.TxtOpis.Text = izabranaStavka.Opis;
            frm.TxtCena.Text = izabranaStavka.Cena.ToString("F2");
            frm.CmbFilm.DataSource = Kontroler.Instance.VratiFilmove();
            frm.CmbFilm.DisplayMember = "Naslov";
            frm.CmbFilm.ValueMember = "IdFilm";
            frm.CmbFilm.SelectedValue = izabranaStavka.IdFilm;

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

