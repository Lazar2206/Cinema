using Domen;
using SistemskeOperacije;

namespace SistemskeOperacije
{
    public class SOKreirajFilm : SOBase
    {
        private readonly Film film;
        public bool Uspeh { get; private set; }

        public SOKreirajFilm(Film film)
        {
            this.film = film;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Insert(film);
        }
    }
}
