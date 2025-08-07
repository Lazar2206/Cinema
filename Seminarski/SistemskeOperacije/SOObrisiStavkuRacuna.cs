using Domen;
using SistemskeOperacije;

public class SOObrisiStavkuRacuna : SOBase
{
    private readonly StavkaRacuna stavka;
    public bool Uspeh { get; private set; }

    public SOObrisiStavkuRacuna(StavkaRacuna stavka)
    {
        this.stavka = stavka;
    }

    protected override void Execute()
    {
        Uspeh = generičkiRepozitorijum.Delete(stavka);

        if (Uspeh)
        {
            generičkiRepozitorijum.AzurirajUkupnuCenuRacuna(stavka.IdRacun);
        }
    }
}

