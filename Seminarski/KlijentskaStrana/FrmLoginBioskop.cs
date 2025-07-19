using Domen;
using Komunikacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmLoginBioskop : Form
    {
        private Klijent klijent;
        public FrmLoginBioskop()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PoveziSe();
            Login();
        }
        private void PoveziSe()
        {
            if (klijent == null)
            {
                klijent = new Klijent();
                if (!klijent.PoveziSe())//provera da li se povezao 
                {
                    klijent = null; //ako se nije povezao
                    MessageBox.Show("Neuspešno povezivanje");
                    return;
                }
            }
        }

        private void Login()
        {

            Bioskop bioskop = new Bioskop()
            {
                KorisnickoIme = txtKorisničkoIme.Text,
                Sifra = txtLozinka.Text

            };
            //kreiranje zahteva
            Poruka zahtev = new Poruka();
            zahtev.Object = bioskop;
            zahtev.Operacija = Operacija.Login;
            //slanje zahteva
            klijent.PošaljiPoruku(zahtev);
            //primanje odgovora
            Poruka odgovor = klijent.PrimiPoruku();
            if (odgovor.Operacija.Equals(Operacija.Uspešno))
            {
                MessageBox.Show("Dobrodošli");
                FrmGlavna frm = new FrmGlavna(bioskop, klijent);
                this.Visible = false;
                frm.ShowDialog();
            }
            else
            {
                //ako podaci nisu ispravni
                MessageBox.Show("Nepostojeci korisnik");
            }
        }
    }
}
