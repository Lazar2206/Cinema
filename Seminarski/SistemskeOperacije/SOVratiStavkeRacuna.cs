using Domen.DTO;
using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;
using System.Collections.Generic;

public class SOVratiStavkeRacuna : SOBase
{
    private readonly int idRacun;
    public List<PrikazStavkeRacuna> Rezultat { get; private set; }

    public SOVratiStavkeRacuna(int idRacun)
    {
        this.idRacun = idRacun;
    }

    protected override void Execute()
    {
        Rezultat = generičkiRepozitorijum.VratiStavkeRacuna(idRacun);
    }
}
