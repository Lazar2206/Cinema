using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;

public class SOPromeniDistributera : SOBase
{
    private readonly Distributer distributer;
    public bool Uspeh { get; private set; }

    public SOPromeniDistributera(Distributer d)
    {
        distributer = d;
    }

    protected override void Execute()
    {
        Uspeh = generičkiRepozitorijum.Update(distributer);
    }
}
