using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije
{
    public class SOVratiSveFilmove : SOBase
    {
        public List<Film> Rezultat { get; private set; }

        protected override void Execute()
        {
            GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
            var domObjekti = repo.VratiSve(new Film());
            Rezultat = domObjekti.Cast<Film>().ToList(); 
        }
    }
}
