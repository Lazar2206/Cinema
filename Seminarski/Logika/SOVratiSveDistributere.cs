using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using System.Collections.Generic;

namespace SistemskeOperacije.SistemskeOperacije
{
    public class SOVratiSveDistributere : SOBase
    {
        private readonly Distributer kriterijum;

        public List<Distributer> Rezultat { get; private set; }

        public SOVratiSveDistributere()
        {
            this.kriterijum = kriterijum;
        }

        protected override void Execute()
        {
            GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
            var lista = repo.VratiSvaMesta(new Distributer());

            Rezultat = new List<Distributer>();
            foreach (var d in lista)
            {
                Rezultat.Add(d as Distributer);
            }
        }
    }
}