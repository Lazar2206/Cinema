using Domen.DTO;
using Domen;
using Repozitorijumi.GeneričkiRepozitorijumi;
using SistemskeOperacije;

public class SOPretraziRacune : SOBase
{
    private readonly Racun kriterijum;
    public List<PrikazRacuna> Rezultat { get; private set; }

    public SOPretraziRacune(Racun kriterijum)
    {
        this.kriterijum = kriterijum;
    }

    protected override void Execute()
    {
        GeneričkiRepozitorijum repo = new GeneričkiRepozitorijum();
        Rezultat = repo.VratiRacune(kriterijum); 
    }
}

