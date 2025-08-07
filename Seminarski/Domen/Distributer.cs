using Domen;
using Microsoft.Data.SqlClient;

public class Distributer : DomenskiObjekat
{
    public int IdDistributer { get; set; }
    public string NazivDistributera { get; set; }

    public string NazivTabele => "Distributer";
    public string InsertKolone => "NazivDistributera";
    public string InsertVrednosti => $"'{NazivDistributera}'";

    public string UslovZaSelect =>
    string.IsNullOrWhiteSpace(NazivDistributera)
        ? "1=1"
        : $"NazivDistributera LIKE '%{NazivDistributera}%'";

    public string VrednostiZaUpdate => $"nazivDistributera='{NazivDistributera}'";

    public string UslovZaUpdate => $"idDistributer={IdDistributer}";

    public  DomenskiObjekat ReadRow(SqlDataReader reader)
    {
        return new Distributer
        {
            IdDistributer = (int)reader["idDistributer"],
            NazivDistributera = (string)reader["nazivDistributera"]
        };
    }

    public string UslovZaJednog()
    {
        throw new NotImplementedException();
    }
}
