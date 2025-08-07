using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    using Domen;
    using Repozitorijumi.GeneričkiRepozitorijumi;
    using System.Collections.Generic;

    namespace SistemskeOperacije
    {
        public class SOPretražiGledaoce : SOBase
        {
            private readonly Gledalac kriterijum;
            public List<Gledalac> Rezultat { get; private set; }

            public SOPretražiGledaoce(Gledalac kriterijum)
            {
                this.kriterijum = kriterijum;
            }

            protected override void Execute()
            {
                GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
                var lista = repo.VratiPoUslovu(kriterijum);
                Rezultat = new List<Gledalac>();
                foreach (var g in lista)
                    Rezultat.Add(g as Gledalac);
            }
        }
    }
}
