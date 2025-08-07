using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;

public class SOObrisiDistributera : SOBase
{
    private readonly Distributer distributer;
    public bool Uspeh { get; private set; }

    public SOObrisiDistributera(Distributer distributer)
    {
        this.distributer = distributer;
    }

    protected override void Execute()
    {
        Uspeh = generičkiRepozitorijum.Delete(distributer);
    }
}
