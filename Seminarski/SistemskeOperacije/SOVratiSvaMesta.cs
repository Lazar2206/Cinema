using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOVratiSvaMesta : SOBase
    {
        public List<Mesto> Rezultat { get; private set; }

        protected override void Execute()
        {
            var domObjekti = generičkiRepozitorijum.VratiSvaMesta(new Mesto());
            Rezultat = new List<Mesto>();
            foreach (var obj in domObjekti)
            {
                Rezultat.Add(obj as Mesto);
            }
        }
    }
}
