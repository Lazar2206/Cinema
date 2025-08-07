using Domen;
using SistemskeOperacije;

namespace SistemskeOperacije
{
    public class SOVratiIdNajnovijegRacuna : SOBase
    {
        public int Id { get; private set; }

        protected override void Execute()
        {
            Id = generičkiRepozitorijum.VratiNajnovijiId(new Racun());
        }
    }
}
