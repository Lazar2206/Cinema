using Domen;
using Domen.DTO;
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
    public partial class UcStavkaRacunacs : UserControl
    {
        public Klijent klijent;
        public Bioskop bioskop;
        public event Action<double> StavkaDodata;
        public event Action StavkaPromenjena;

        private RacunKontroler racunKontroler;
        public int IdRacun { get; set; }
        public int selektovaniRb { get; set; }
        private double staraCena; // Postaviš pri izmeni stavke
        public Klijent Klijent;
        public Bioskop Bioskop;
        public UcStavkaRacunacs()
        {
            InitializeComponent();
            

        }

        public void PoveziSaKontrolerom(RacunKontroler kontroler)
        {
            this.racunKontroler = kontroler;
            UcitajFilmove(); 
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            double cena;
            if (!double.TryParse(txtCena.Text, out cena))
            {
                MessageBox.Show("Cena nije validna.");
                return;
            }

            var stavka = new StavkaRacuna
            {
                Opis = txtOpis.Text,
                Cena = cena,
                IdFilm = (int)cmbFilm.SelectedValue
            };

            bool uspesno = racunKontroler.DodajStavku(stavka);
            if (uspesno)
            {
                StavkaDodata?.Invoke(cena);
                MessageBox.Show("Stavka dodata.");
            }
            else
            {
                MessageBox.Show("Greška pri dodavanju stavke.");
            }
        }
        public void UcitajFilmove()
        {
            cmbFilm.DataSource = racunKontroler.VratiFilmove();
            cmbFilm.DisplayMember = "Naslov";
            cmbFilm.ValueMember = "IdFilm";
            cmbFilm.SelectedIndex = -1;
        }
        public void PostaviStavku(PrikazStavkeRacuna stavka)
        {
            txtOpis.Text = stavka.Opis;
            txtCena.Text = stavka.Cena.ToString("F2");
            cmbFilm.SelectedValue = stavka.NaslovFilma;

         
            selektovaniRb = stavka.Rb;
            staraCena = stavka.Cena;
        }


        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            double cena;
            if (!double.TryParse(txtCena.Text, out cena))
            {
                MessageBox.Show("Cena nije validna.");
                return;
            }

            var stavka = new StavkaRacuna
            {
                Opis = txtOpis.Text,
                Cena = cena,
                IdFilm = (int)cmbFilm.SelectedValue
            };

            bool uspesno = racunKontroler.IzmeniStavku(stavka);
            if (uspesno)
            {
                StavkaPromenjena?.Invoke();
                MessageBox.Show("Stavka izmenjena.");
            }
            else
            {
                MessageBox.Show("Greška pri izmeni stavke.");
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
