using Domen;
using SistemskeOperacije;

public class SODodajStavkuRacuna : SOBase
{
    private readonly StavkaRacuna stavka;
    public bool Uspeh { get; private set; }

    public SODodajStavkuRacuna(StavkaRacuna stavka)
    {
        this.stavka = stavka;
    }

    protected override void Execute()
    {

        int sledeciRb = generičkiRepozitorijum.VratiSledeciRB(stavka.IdRacun);
        stavka.Rb = sledeciRb;

   
        Uspeh = generičkiRepozitorijum.Insert(stavka);

        
        if (Uspeh)
        {
            generičkiRepozitorijum.AzurirajUkupnuCenuRacuna(stavka.IdRacun);
        }
    }
}
