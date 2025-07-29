using Domen;
using Domen.DTO;
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
        private int selektovaniRb;
        public event Action StavkaPromenjena;

        private double staraCena = 0;
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
        public void PostaviStavku(PrikazStavkeRacuna stavka)
        {
            txtOpis.Text = stavka.Opis;
            txtCena.Text = stavka.Cena.ToString("F2");
            cmbFilm.SelectedIndex = cmbFilm.FindStringExact(stavka.NaslovFilma);

            staraCena = stavka.Cena;
            selektovaniRb = stavka.Rb;
        }


        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCena.Text, out double novaCena)) return;
            if (cmbFilm.SelectedItem == null) return;

            Film izabraniFilm = (Film)cmbFilm.SelectedItem;

            StavkaRacuna stavka = new StavkaRacuna
            {
                IdRacun = IdRacun,
                Opis = txtOpis.Text,
                Cena = novaCena,
                IdFilm = izabraniFilm.IdFilm,
                Rb = selektovaniRb
            };

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.IzmeniStavkuRacuna,
                Object = stavka
            };

            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Stavka uspešno izmenjena.");

                // Izračunaj razliku u ceni i prosledi događajem
                double razlika = novaCena - staraCena;
                StavkaDodata?.Invoke(razlika);
                staraCena = novaCena;
                StavkaPromenjena?.Invoke();
            }
            else
            {
                MessageBox.Show("Greška prilikom izmene stavke.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCena.Text, out double novaCena)) return;
            if (cmbFilm.SelectedItem == null) return;

            Film izabraniFilm = (Film)cmbFilm.SelectedItem;

            
            StavkaRacuna stavka = new StavkaRacuna
            {
                IdRacun = IdRacun,
                Opis = txtOpis.Text,
                Cena = novaCena,
                IdFilm = izabraniFilm.IdFilm,
                Rb = selektovaniRb 
            };

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.ObrisiStavkuRacuna,
                Object = stavka
            };

            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Stavka uspešno obrisana.");
                StavkaDodata?.Invoke(-staraCena);
                StavkaPromenjena?.Invoke();
            }
            else
            {
                MessageBox.Show("Greška prilikom brisanja stavke.");
            }
        }
    }
}
