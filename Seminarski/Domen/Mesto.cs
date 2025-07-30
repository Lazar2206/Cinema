using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace Domen
{
    public class Mesto: DomenskiObjekat
    {
        public int IdMesto { get; set; }
        public string NazivMesta { get; set; }

        public override string ToString()
        {
            return NazivMesta;
        }
        [Browsable(false)]
        public string NazivTabele => "Mesto";

        [Browsable(false)]
        public string UslovZaSelect => "1=1";

        public string InsertKolone => "nazivMesta";

        public string InsertVrednosti => $"'{NazivMesta}'";

     

        [Browsable(false)]
        public string UslovZaJednog() => $"idMesto = {IdMesto}";
        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            return new Mesto
            {
                IdMesto = (int)reader["idMesto"],
                NazivMesta = (string)reader["nazivMesta"]
            };
        }
    }
}
