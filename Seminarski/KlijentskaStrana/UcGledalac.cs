using Domen;
using KlijentskaStrana.GUIKontroler;
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
        public event EventHandler GledalacAzuriran;
        public Klijent klijent { get; set; }
        public GledalacKontroler kontrolerGledalac { get; set; }
        private Gledalac gledalac;

        public UcGledalac(GledalacKontroler kontroler)
        {
            InitializeComponent();
            this.kontrolerGledalac = kontroler;
        }

        public void PopuniPolja()
        {
            cmbGledalac.DataSource = kontrolerGledalac.VratiMesta();
            cmbGledalac.DisplayMember = "NazivMesta";
            cmbGledalac.ValueMember = "IdMesto";

            txtIme.Text = "";
            txtPrezime.Text = "";
            txtMejl.Text = "";
            cmbGledalac.SelectedIndex = -1;
            gledalac = null;
        }

        public void PopuniPoljaIzObjekta(object o) 
        {
            gledalac = o as Gledalac;
            if (gledalac == null) return;

       
            cmbGledalac.DataSource = kontrolerGledalac.VratiMesta();
            cmbGledalac.DisplayMember = "NazivMesta";
            cmbGledalac.ValueMember = "IdMesto";

            txtIme.Text = gledalac.Ime;
            txtPrezime.Text = gledalac.Prezime;
            txtMejl.Text = gledalac.Mejl;

            cmbGledalac.SelectedValue = gledalac.IdMesto;
        }

        private void btnZapamti_Click(object sender, EventArgs e)
        {
            Gledalac novi = new Gledalac
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Mejl = txtMejl.Text,
                IdMesto = (int)cmbGledalac.SelectedValue
            };

            bool uspeh = kontrolerGledalac.ZapamtiGledaoca(novi);
            if (uspeh)
            {
                MessageBox.Show("Sistem je zapamtio gledaoca.");
                GledalacAzuriran?.Invoke(this, EventArgs.Empty);
                PopuniPolja();
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti gledaoca.");
            }
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (gledalac == null)
            {
                MessageBox.Show("Gledalac nije učitan.");
                return;
            }

            gledalac.Ime = txtIme.Text;
            gledalac.Prezime = txtPrezime.Text;
            gledalac.Mejl = txtMejl.Text;
            gledalac.IdMesto = (int)cmbGledalac.SelectedValue;

            kontrolerGledalac.PostaviGledaoca(gledalac);
            bool uspeh = kontrolerGledalac.IzmeniGledaoca();

            if (uspeh)
            {
                MessageBox.Show("Sistem je izmenio gledaoca.");
                GledalacAzuriran?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Sistem ne može da izmeni gledaoca.");
            }
        }

        private void btnObriši_Click(object sender, EventArgs e)
        {

            if (gledalac == null)
            {
                MessageBox.Show("Gledalac nije učitan.");
                return;
            }

            kontrolerGledalac.PostaviGledaoca(gledalac);
            bool uspesno = kontrolerGledalac.ObrisiGledaoca();

            if (uspesno)
            {
                MessageBox.Show("Sistem je obrisao gledaoca.");
                GledalacAzuriran?.Invoke(this, EventArgs.Empty);
                PopuniPolja();
            }
            else
            {
                MessageBox.Show("Sistem ne može da obriše gledaoca.");
            }
        }
    }
}
