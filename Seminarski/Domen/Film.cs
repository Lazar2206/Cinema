using Microsoft.Data.SqlClient;
using System;

namespace Domen
{
    public class Film : DomenskiObjekat
    {
        public int IdFilm { get; set; }
        public string Naslov { get; set; }
        public Žanr Zanr { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }
        public int TrajanjeMinuti { get; set; }

        public string NazivTabele => "Film";

        public string InsertKolone =>
            "Naslov, Zanr, Pocetak, Kraj, TrajanjeMinuti";

        public string InsertVrednosti =>
            $"'{Naslov}', '{Zanr}', '{Pocetak}', '{Kraj}', {TrajanjeMinuti}";

        public string UslovZaSelect => $"IdFilm = {IdFilm}";

        public string VrednostiZaUpdate => "";

        public string UslovZaUpdate => $"idFilm={IdFilm}";

        public string PrimarniKljucKolona => "idFilm";

        public string UslovZaJednog() => $"IdFilm = {IdFilm}";

        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            return new Film
            {
                IdFilm = (int)reader["IdFilm"],
                Naslov = reader["Naslov"].ToString(),
                Zanr = Enum.TryParse(reader["Zanr"].ToString(), out Žanr z) ? z : Žanr.Akcija, 
                Pocetak = (TimeSpan)reader["Pocetak"],
                Kraj = (TimeSpan)reader["Kraj"],
                TrajanjeMinuti = (int)reader["TrajanjeMinuti"]
            };
        }
    }
}
