using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOObrisiRacun:SOBase
    {
        private readonly Racun racun;
        public bool Uspeh { get; private set; }

        public SOObrisiRacun(Racun racun)
        {
            this.racun = racun;
        }

        protected override void Execute()
        {
            var stavkaTemplate = new StavkaRacuna { IdRacun = racun.IdRacun };
            generičkiRepozitorijum.DeleteWhere(stavkaTemplate);
            Uspeh = generičkiRepozitorijum.Delete(racun);
        }
    }
}
