using DBBroker;
using Domen;
using SistemskeOperacije;

public class SOVratiDistributere : SOBase
{
    private readonly Distributer kriterijum;
    public List<Distributer> Rezultat { get; private set; }

    public SOVratiDistributere(Distributer d)
    {
        kriterijum = d;
    }

    protected override void Execute()
    {
        var lista = generičkiRepozitorijum.VratiSvaMesta(new Distributer());
        Rezultat = lista.Cast<Distributer>().ToList();
    }
}
