using Domen;

namespace SistemskeOperacije
{
    public class SOObrisiGledaoca : SOBase
    {
        private readonly Gledalac gledalac;
        public bool Uspeh { get; private set; }

        public SOObrisiGledaoca(Gledalac g)
        {
            gledalac = g;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Delete(gledalac);
        }
    }
}
