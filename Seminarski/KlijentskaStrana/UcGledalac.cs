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
    public partial class UcGledalac : UserControl
    {
        public Gledalac Gledalac { get; set; }
        public Klijent Klijent { get; set; }
        public UcGledalac( )
        {
            InitializeComponent();
            txtIme.Text = Gledalac.Ime;
            txtPrezime.Text = Gledalac.Prezime;
            txtMejl.Text = Gledalac.Mejl;
            cmbGledalac.DataSource = Kontroler.Instance.VratiMesta();


        }



        private void btnPretraži_Click(object sender, EventArgs e)
        {
        }
        public void PopuniPolja()
        {
            if (Gledalac != null)
            {
                txtIme.Text = Gledalac.Ime;
                txtPrezime.Text = Gledalac.Prezime;
                txtMejl.Text = Gledalac.Mejl;

                cmbGledalac.DataSource = Kontroler.Instance.VratiMesta();
                cmbGledalac.DisplayMember = "NazivMesta";
                cmbGledalac.ValueMember = "IdMesto";
                cmbGledalac.SelectedValue = Gledalac.IdMesto;
            }
        }
        private void btnUredi_Click(object sender, EventArgs e)
        {

            Gledalac g = new Gledalac
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Mejl = txtMejl.Text,
                IdMesto = cmbGledalac.SelectedIndex,
                KorisničkoIme=Gledalac.KorisničkoIme,
                Šifra = Gledalac.Šifra
            };
            Poruka zahtev = new Poruka
            {
                Object = g,
                Operacija = Operacija.PromeniGledaoca,
            };
            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Paket je uspešno izmenjen");
            }
            else
            {
                MessageBox.Show("Greska");
            }
        }
    }
}
