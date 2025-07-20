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
    public partial class FrmFilm : Form
    {
        private Klijent klijent;
        private Bioskop bioskop;
        public FrmFilm(Klijent klijent, Bioskop bioskop)
        {
            InitializeComponent();
            this.klijent = klijent;
            this.bioskop = bioskop;
            NapuniCMB();
            NapuniDGV();
        }
        private void NapuniCMB()
        {
            cmbŽanr.DataSource = Enum.GetValues(typeof(Žanr));
            cmbŽanr.SelectedIndex = -1;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            TimeSpan pocetak = dateTimePickerPocetak.Value.TimeOfDay;
            TimeSpan kraj = dateTimePickerKraj.Value.TimeOfDay;

            if (kraj <= pocetak)
            {
                MessageBox.Show("Vreme kraja mora biti veće od vremena početka!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNaslov.Text) || cmbŽanr.SelectedIndex == -1)
            {
                MessageBox.Show("Sistem ne može da kreira gledaoca.\nPopunite sva polja");
                return;
            }
            else
            {
                Film f = new Film
                {
                    Naslov = txtNaslov.Text,
                    Zanr = (Žanr)cmbŽanr.SelectedItem,
                    Pocetak = pocetak,
                    Kraj = kraj,
                    TrajanjeMinuti = (int)(kraj - pocetak).TotalMinutes
                };
                Poruka zahtev = new Poruka
                {
                    Object = f,
                    Operacija = Operacija.KreirajMesto,
                };
                klijent.PošaljiPoruku(zahtev);
                Poruka odgovor = klijent.PrimiPoruku();
                if (odgovor.Operacija == Operacija.Uspešno)
                {
                    MessageBox.Show("Sistem je kreirao film");
                    txtNaslov.Text = string.Empty;
                    cmbŽanr.SelectedIndex = -1;
                    dateTimePickerPocetak.Value = DateTime.Now;
                    dateTimePickerKraj.Value = DateTime.Now.AddHours(2);
                    OsveziFilmove();
                }
                else
                {
                    MessageBox.Show("Sistem ne može da kreira film");
                }
            }
        }
        private void NapuniDGV()
        {

            dgvFilmovi.DataSource = null;
            dgvFilmovi.DataSource = Kontroler.Instance.VratiFilmove();
        }
        private void OsveziFilmove()
        {

            dgvFilmovi.DataSource = null;
            dgvFilmovi.DataSource = Kontroler.Instance.VratiFilmove();
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
