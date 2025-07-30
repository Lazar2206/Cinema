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
            forma.PrikaziZanrove(Enum.GetValues(typeof(Žanr)));
        }

        public void DodajFilm(string naslov, object zanrObj, DateTime pocetakDT, DateTime krajDT)
        {
            if (string.IsNullOrWhiteSpace(naslov) || zanrObj == null)
            {
                forma.PrikaziPoruku("Popunite sva polja!");
                return;
            }

            TimeSpan pocetak = pocetakDT.TimeOfDay;
            TimeSpan kraj = krajDT.TimeOfDay;

            if (kraj <= pocetak)
            {
                forma.PrikaziPoruku("Vreme kraja mora biti posle početka.");
                return;
            }

            var film = new Film
            {
                Naslov = naslov,
                Zanr = (Žanr)zanrObj,
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
                forma.PrikaziPoruku("Film uspešno dodat!");
                forma.OčistiPolja();
                OsveziFilmove();
            }
            else
            {
                forma.PrikaziPoruku("Greška pri dodavanju filma.");
            }
        }

        public void OsveziFilmove()
        {
            var filmovi = Kontroler.Instance.VratiFilmove();
            forma.PrikaziFilmove(filmovi);
        }
    }
}