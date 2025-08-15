using Domen;
using Komunikacija;
using KlijentskaStrana.Session;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logika;

namespace KlijentskaStrana.GUIKontroler
{
    public class FilmKontroler
    {
        private FrmFilm forma;

        public FilmKontroler(FrmFilm forma)
        {
            this.forma = forma;
            NapuniComboZanrova();
            OsveziFilmove();
        }

        public void NapuniComboZanrova()
        {
            PrikaziZanrove(Enum.GetValues(typeof(Žanr)));
        }

        public void DodajFilm()
        {
            if (string.IsNullOrWhiteSpace(forma.TxtNaslov.Text) || forma.CmbŽanr.SelectedItem == null)
            {
                PrikaziPoruku("Popunite sva polja!");
                return;
            }

            TimeSpan pocetak = forma.DateTimePickerPocetak.Value.TimeOfDay;
            TimeSpan kraj = forma.DateTimePickerKraj.Value.TimeOfDay;

            if (kraj <= pocetak)
            {
                PrikaziPoruku("Vreme kraja mora biti posle početka.");
                return;
            }

            var film = new Film
            {
                Naslov = forma.TxtNaslov.Text,
                Zanr = (Žanr)forma.CmbŽanr.SelectedItem,
                Pocetak = pocetak,
                Kraj = kraj,
                TrajanjeMinuti = (int)(kraj - pocetak).TotalMinutes
            };

            var zahtev = new Poruka
            {
                Operacija = Operacija.KreirajFilm,
                Object = film
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            var odgovor = Session.Session.Instance.Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                PrikaziPoruku("Film uspešno dodat!");
                OcistiPolja();
                OsveziFilmove();
            }
            else
            {
                PrikaziPoruku("Greška pri dodavanju filma.");
            }
        }

        public void OsveziFilmove()
        {
            var filmovi = Kontroler.Instance.VratiFilmove();
            forma.DgvFilmovi.DataSource = null;
            forma.DgvFilmovi.DataSource = filmovi;
            forma.DgvFilmovi.Columns[5].Visible = false;
            forma.DgvFilmovi.Columns[6].Visible = false;
            forma.DgvFilmovi.Columns[7].Visible = false;
            forma.DgvFilmovi.Columns[8].Visible = false;
            forma.DgvFilmovi.Columns[9].Visible = false;
            forma.DgvFilmovi.Columns[10].Visible = false;
            forma.DgvFilmovi.Columns[11].Visible = false;
            forma.DgvFilmovi.Columns[12].Visible = false;
            
        }

        private void PrikaziPoruku(string poruka)
        {
            MessageBox.Show(poruka);
        }
        public void PrikaziZanrove(Array zanrovi) { forma.CmbŽanr.DataSource = zanrovi; forma.CmbŽanr.SelectedIndex = -1; }
        private void OcistiPolja()
        {
            forma.TxtNaslov.Clear();
            forma.CmbŽanr.SelectedIndex = -1;
            forma.DateTimePickerPocetak.Value = DateTime.Now;
            forma.DateTimePickerKraj.Value = DateTime.Now.AddHours(2);
        }
    }
}