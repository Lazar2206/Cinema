using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;

public class SOPromeniRacun : SOBase
{
    private readonly Racun racun;
    public bool Uspeh { get; private set; }

    public SOPromeniRacun(Racun racun)
    {
        this.racun = racun;
    }

    protected override void Execute()
    {
        GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
        Uspeh = repo.Update(racun);
    }
}
