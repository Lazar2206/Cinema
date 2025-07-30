using Domen;

namespace SistemskeOperacije
{
    public class SOKreirajMesto : SOBase
    {
        private readonly Mesto mesto;
        public bool Uspeh { get; private set; }

        public SOKreirajMesto(Mesto mesto)
        {
            this.mesto = mesto;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Insert(mesto);
        }
    }
}
