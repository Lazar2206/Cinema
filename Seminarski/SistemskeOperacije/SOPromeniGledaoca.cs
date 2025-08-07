using Domen;

namespace SistemskeOperacije
{
    public class SOPromeniGledaoca : SOBase
    {
        private readonly Gledalac gledalac;
        public bool Uspeh { get; private set; }

        public SOPromeniGledaoca(Gledalac g)
        {
            gledalac = g;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Update(gledalac);
        }
    }
}
