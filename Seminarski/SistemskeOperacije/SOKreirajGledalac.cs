using Domen;

namespace SistemskeOperacije
{
    public class SOKreirajGledalac : SOBase
    {
        private readonly Gledalac gledalac;

        public SOKreirajGledalac(Gledalac gledalac)
        {
            this.gledalac=gledalac;
        }
        protected override void Execute()
        {
            //broker.KreirajGledalac(gledalac);
        }
    }
}
