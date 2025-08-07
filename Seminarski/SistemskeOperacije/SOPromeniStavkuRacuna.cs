using Domen;
using SistemskeOperacije;

public class SOPromeniStavkuRacuna : SOBase
{
    private readonly StavkaRacuna stavka;
    public bool Uspeh { get; private set; }

    public SOPromeniStavkuRacuna(StavkaRacuna stavka)
    {
        this.stavka = stavka;
    }

    protected override void Execute()
    {
        var updateObjekat = new StavkaRacuna
        {
            IdRacun = stavka.IdRacun,
            Rb = stavka.Rb,
            Opis = stavka.Opis,
            Cena = stavka.Cena,
            IdFilm = stavka.IdFilm
        };

        Uspeh = generičkiRepozitorijum.Update(updateObjekat);

        if (Uspeh)
        {
            generičkiRepozitorijum.AzurirajUkupnuCenuRacuna(stavka.IdRacun);
        }
    }
}
