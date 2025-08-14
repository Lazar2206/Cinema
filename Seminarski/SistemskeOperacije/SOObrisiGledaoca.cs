using Domen;
using System.Linq;

namespace SistemskeOperacije
{
    public class SOObrisiGledaoca : SOBase
    {
        private readonly Gledalac gledalac;
        public bool Uspeh { get; set; }
        public string Poruka { get; private set; }

        public SOObrisiGledaoca(Gledalac g)
        {
            gledalac = g;
        }

        protected override void Execute()
        {
           
            var racuni = generičkiRepozitorijum.VratiRacunePoGledalcu(gledalac.IdGledalac);

            if (racuni != null && racuni.Count > 0)
            {
                Uspeh = false;
                Poruka = "Ne možete da obrišete gledaoca dok za njega postoji račun.";
                return; 
            }

           
            Uspeh = generičkiRepozitorijum.Delete(gledalac);
            Poruka = Uspeh ? "Sistem je obrisao gledaoca." : "Sistem ne može da obriše gledaoca.";
        }
    }
}
