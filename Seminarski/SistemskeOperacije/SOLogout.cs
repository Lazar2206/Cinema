using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOLogout : SOBase
    {
        private readonly Bioskop prijavljeniBioskop;
        private readonly BindingList<Bioskop> prijavljeniBioskopi;

        public SOLogout(Bioskop prijavljeniBioskop, BindingList<Bioskop> prijavljeniBioskopi)
        {
            this.prijavljeniBioskop = prijavljeniBioskop;
            this.prijavljeniBioskopi = prijavljeniBioskopi;
        }

        protected override void Execute()
        {
            var bioskopZaUklanjanje = prijavljeniBioskopi
                .FirstOrDefault(b => b.IdBioskop == prijavljeniBioskop.IdBioskop);

            if (bioskopZaUklanjanje != null)
            {
                prijavljeniBioskopi.Remove(bioskopZaUklanjanje);
            }
        }
    }
}
