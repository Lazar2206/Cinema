using DBBroker;
using Domen;
using Komunikacija;
using Logika;
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
    public partial class FrmBioskop : Form
    {
        private Klijent klijent;
        private Bioskop bioskop;
        public FrmBioskop(Klijent klijent, Bioskop bioskop)
        {
            InitializeComponent();
            this.klijent = klijent;
            this.bioskop = bioskop;
            NapuniDGV();
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNazivBioskopa.Text) || string.IsNullOrWhiteSpace(txtAdresaBioskopa.Text) || 
                string.IsNullOrWhiteSpace(txtKorisničkoIme.Text) || string.IsNullOrWhiteSpace(txtŠifra.Text))
            {
                MessageBox.Show("Sistem ne može da kreira bioskop.\nPopunite sva polja");
                return;
            }
            Bioskop b = new Bioskop
            {
                NazivBioskopa = txtNazivBioskopa.Text,
                AdresaBioskopa = txtAdresaBioskopa.Text,
                KorisnickoIme = txtKorisničkoIme.Text,
                Sifra = txtŠifra.Text
            };
            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.DodajBioskop,
                Object = b
            };
            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Bioskop uspešno dodat!");
                txtNazivBioskopa.Clear();
                txtAdresaBioskopa.Clear();
                txtKorisničkoIme.Clear();
                txtŠifra.Clear();
                NapuniDGV();
            }
            else
            {
                MessageBox.Show("Sistem ne može da doda bioskop.");
            }

        }
        private void NapuniDGV()
        {
            dgvBioskopi.DataSource = null;
            dgvBioskopi.DataSource = Kontroler.Instance.VratiSveBioskope();
        }
    }
}
