using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;

namespace SistemskeOperacije
{
    public class SOKreirajBioskop : SOBase
    {
        private readonly Bioskop bioskop;
        public bool Uspeh { get; private set; }

        public SOKreirajBioskop(Bioskop bioskop)
        {
            this.bioskop = bioskop;
        }

        protected override void Execute()
        {
            GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
            Uspeh = repo.Insert(bioskop);
        }
    }
}
