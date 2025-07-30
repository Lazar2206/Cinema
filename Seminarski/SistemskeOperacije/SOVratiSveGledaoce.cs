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
        public List<Gledalac> Result { get; private set; }
        protected override void Execute()
        {
           // Result = repository.VratiSve(new Gledalac()).ofType<Gledalac>().ToList();
        }
    }
}
