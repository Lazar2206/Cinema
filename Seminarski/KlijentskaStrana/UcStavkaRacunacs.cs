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
    public partial class UcStavkaRacunacs : UserControl
    {
        public Bioskop Bioskop { get; set; }
        public Klijent Klijent { get; set; }
        public int IdRacun { get; set; }
        public event Action<double> StavkaDodata;

        public UcStavkaRacunacs()
        {
            InitializeComponent();
          
            
        }
       

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCena.Text, out double cena) || cena < 0)
            {
                MessageBox.Show("Unesite validnu cenu!");
                return;
            }

            if (cmbFilm.SelectedItem == null)
            {
                MessageBox.Show("Izaberite film!");
                return;
            }

            StavkaRacuna stavka = new StavkaRacuna
            {
                IdRacun = IdRacun,
                Opis = txtOpis.Text,
                Cena = cena,
                IdFilm = ((Film)cmbFilm.SelectedItem).IdFilm
            };

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.DodajStavkuRacuna,
                Object = stavka
            };
            MessageBox.Show($"Dodajem stavku za RacunId={stavka.IdRacun}, FilmId={stavka.IdFilm}, Cena={stavka.Cena}");

            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Stavka uspešno dodata!");
                txtOpis.Clear();
                txtCena.Clear();
                StavkaDodata?.Invoke(cena);
               
            }
            else
            {
                MessageBox.Show("Sistem ne može da doda stavku.");
            }
        }
        public void UcitajFilmove()
        {
            List<Film> filmovi = Kontroler.Instance.VratiFilmove();
            cmbFilm.DataSource = filmovi;
            cmbFilm.DisplayMember = "Naslov";
            cmbFilm.ValueMember = "IdFilm";
        }
    }
}
