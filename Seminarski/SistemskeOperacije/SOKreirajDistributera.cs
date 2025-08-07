using Domen;

namespace SistemskeOperacije
{
    public class SOKreirajDistributera : SOBase
    {
        private readonly Distributer distributer;
        public bool Uspeh { get; private set; }

        public SOKreirajDistributera(Distributer d)
        {
            distributer = d;
        }

        protected override void Execute()
        {
            Uspeh = generičkiRepozitorijum.Insert(distributer);
        }
    }
}