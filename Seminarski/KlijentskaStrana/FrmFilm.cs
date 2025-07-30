using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmFilm : Form
    {
        private FilmKontroler filmKontroler;
        public FrmFilm()
        {
            InitializeComponent();
            filmKontroler = new FilmKontroler(this);
        }
        
      
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            filmKontroler.DodajFilm(txtNaslov.Text, cmbŽanr.SelectedItem, dateTimePickerPocetak.Value, dateTimePickerKraj.Value);
        }
        public void PrikaziZanrove(Array zanrovi)
        {
            cmbŽanr.DataSource = zanrovi;
            cmbŽanr.SelectedIndex = -1;
        }

        public void PrikaziFilmove(object filmovi)
        {
            dgvFilmovi.DataSource = null;
            dgvFilmovi.DataSource = filmovi;
        }

        public void PrikaziPoruku(string poruka)
        {
            MessageBox.Show(poruka);
        }

        public void OčistiPolja()
        {
            txtNaslov.Clear();
            cmbŽanr.SelectedIndex = -1;
            dateTimePickerPocetak.Value = DateTime.Now;
            dateTimePickerKraj.Value = DateTime.Now.AddHours(2);
        }
        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
