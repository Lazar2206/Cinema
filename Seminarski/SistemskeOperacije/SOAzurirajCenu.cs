using Domen;
using SistemskeOperacije;

namespace SistemskeOperacije
{
    public class SOAzurirajCenu : SOBase
    {
        private readonly Racun racun;
        public bool Uspeh { get; private set; }

        public SOAzurirajCenu(Racun racun)
        {
            this.racun = racun;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Update(racun);
        }
    }
}