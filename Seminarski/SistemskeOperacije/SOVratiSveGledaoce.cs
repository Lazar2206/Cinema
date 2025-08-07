using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOVratiSveGledaoce : SOBase
    {
        public List<Gledalac> Rezultat { get; private set; }
        protected override void Execute()
        {
            var domObjekti = generičkiRepozitorijum.VratiSvaMesta(new Gledalac());
            Rezultat = new List<Gledalac>();
            foreach (var obj in domObjekti)
            {
                Rezultat.Add(obj as Gledalac);
            }
        }
    }
}
