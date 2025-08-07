using Domen;
using SistemskeOperacije;

namespace SistemskeOperacije
{
    public class SOKreirajRacun : SOBase
    {
        private readonly Racun racun;
        public bool Uspeh { get; private set; }

        public SOKreirajRacun(Racun racun)
        {
            this.racun = racun;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Insert(racun);
        }
    }
}
