using Domen;
using SistemskeOperacije;

namespace SistemskeOperacije
{
    public class SOKreirajGledalac : SOBase
    {
        private readonly Gledalac gledalac;
        public bool Uspeh { get; private set; }

        public SOKreirajGledalac(Gledalac gledalac)
        {
            this.gledalac = gledalac;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Insert(gledalac);
        }
    }
}
