using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class SOLogin: SOBase
    {
        private readonly string korisnickoIme;
        private readonly string sifra;
        public Bioskop Result { get; private set; }
        public SOLogin(string korisnickoIme, string sifra) 
        { 
                this.korisnickoIme = korisnickoIme;
                this.sifra = sifra; 
        }

        protected override void Execute()
        {
            Result = generičkiRepozitorijum.SelectOne(new Bioskop
            {
                KorisnickoIme = korisnickoIme,
                Sifra = sifra
            }) as Bioskop;
        }
    }
}
