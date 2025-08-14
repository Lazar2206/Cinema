using Domen;
using System.Collections.Generic;

namespace SistemskeOperacije
{
    public class SOVratiRacunePoGledaocu : SOBase
    {
        private readonly int gledalacId;
        public List<Racun> Rezultat { get; private set; }

        public SOVratiRacunePoGledaocu(int gledalacId)
        {
            this.gledalacId = gledalacId;
        }

        protected override void Execute()
        {
            Rezultat = generičkiRepozitorijum.VratiRacunePoGledalcu(gledalacId);
        }
    }
}
