using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOLogin : SOBase
    {
        private readonly string korisnickoIme;
        private readonly string sifra;
        public Bioskop Result { get; private set; }
        public BindingList<Bioskop> PrijavljeniBioskopi { get; }

        public SOLogin(string korisnickoIme, string sifra, BindingList<Bioskop> prijavljeniBioskopi)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
            PrijavljeniBioskopi = prijavljeniBioskopi;
        }

        protected override void Execute()
        {
            
            var pronadjenBioskop = generičkiRepozitorijum.SelectOne(new Bioskop
            {
                KorisnickoIme = korisnickoIme,
                Sifra = sifra
            }) as Bioskop;

            if (pronadjenBioskop != null)
            {
                
                bool vecPrijavljen = PrijavljeniBioskopi.Any(b => b.IdBioskop == pronadjenBioskop.IdBioskop);
                if (!vecPrijavljen)
                {
                    PrijavljeniBioskopi.Add(pronadjenBioskop);
                    Result = pronadjenBioskop;
                }
                else
                {
                    
                    Result = null;
                }
            }
            else
            {
                Result = null; 
            }
        }
    }
}
