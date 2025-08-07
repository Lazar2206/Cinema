using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOVratiSledeciRB: SOBase   
    {
        public int RB { get; private set; }
        public int id { get; private set; }
        public SOVratiSledeciRB(int id)
        {
            this.id = id;
        }

        protected override void Execute()
        {
            RB = generičkiRepozitorijum.VratiSledeciRB(id);
            
        }
    }
}
