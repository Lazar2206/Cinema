using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOVratiSveBioskope : SOBase
    {
        public List<Bioskop> Rezultat { get; private set; }

        protected override void Execute()
        {
            var lista = generičkiRepozitorijum.VratiSve(new Bioskop());
            Rezultat = lista.Cast<Bioskop>().ToList();
        }
    }
}
