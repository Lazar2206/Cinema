using Domen;
using Domen.DTO;
using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;
using System.Collections.Generic;

public class SOVratiStavkeRacuna : SOBase
{
    private readonly int idRacun;
    public List<PrikazStavkeRacuna> Rezultat { get; private set; }

    public SOVratiStavkeRacuna(int id)
    {
        this.idRacun = id;
    }

    protected override void Execute()
    {
        var lista = generičkiRepozitorijum.VratiStavkeRacuna(idRacun);
        Rezultat = lista.Cast<PrikazStavkeRacuna>().ToList();
    }
}
