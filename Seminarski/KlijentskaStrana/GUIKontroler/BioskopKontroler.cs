using Domen;
using Komunikacija;
using Logika;
using KlijentskaStrana.Session;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana.GUIKontroler
{
    public class BioskopKontroler
    {
        private FrmBioskop forma;

        public BioskopKontroler(FrmBioskop forma)
        {
            this.forma = forma;
            OsveziTabelu();
        }

        public void DodajBioskop()
        {
            string naziv = forma.TxtNaziv.Text;
            string adresa = forma.TxtAdresa.Text;
            string korisnickoIme = forma.TxtKorisnickoIme.Text;
            string sifra = forma.TxtSifra.Text;

            if (string.IsNullOrWhiteSpace(naziv) || string.IsNullOrWhiteSpace(adresa) ||
                string.IsNullOrWhiteSpace(korisnickoIme) || string.IsNullOrWhiteSpace(sifra))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            Bioskop b = new Bioskop
            {
                NazivBioskopa = naziv,
                AdresaBioskopa = adresa,
                KorisnickoIme = korisnickoIme,
                Sifra = sifra
            };

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.DodajBioskop,
                Object = b
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Session.Session.Instance.Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Bioskop uspešno dodat!");
                forma.TxtNaziv.Clear();
                forma.TxtAdresa.Clear();
                forma.TxtKorisnickoIme.Clear();
                forma.TxtSifra.Clear();
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show("Sistem ne može da doda bioskop.");
            }
        }

        public void OsveziTabelu()
        {
            var lista = Kontroler.Instance.VratiSveBioskope();
            forma.Dgv.DataSource = null;
            forma.Dgv.DataSource = lista;
            forma.Dgv.Columns[5].Visible = false;
            forma.Dgv.Columns[6].Visible = false;
            forma.Dgv.Columns[7].Visible = false;
            forma.Dgv.Columns[8].Visible = false;
            forma.Dgv.Columns[9].Visible = false;
            forma.Dgv.Columns[10].Visible = false;
        
        }
    }
}
