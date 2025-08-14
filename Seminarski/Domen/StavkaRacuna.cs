using Microsoft.Data.SqlClient;

namespace Domen
{
    public class StavkaRacuna : DomenskiObjekat
    {
        public int IdRacun { get; set; }
        public int Rb { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
        public int IdFilm { get; set; }
       

        public string NazivTabele => "StavkaRacuna";

        public string InsertKolone => "idRacun, rb, cena, opis, idFilm";

        public string InsertVrednosti =>
            $"{IdRacun}, {Rb}, {Cena}, '{Opis}', {IdFilm}";

        public string UslovZaSelect => $"idRacun = {IdRacun} ";

        public string VrednostiZaUpdate =>
            $"cena = {Cena}, opis = '{Opis}', idFilm = {IdFilm}";

        public string UslovZaUpdate => $"idRacun = {IdRacun} AND rb = {Rb}";

        public string PrimarniKljucKolona => "rb";

        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            return new StavkaRacuna
            {
                IdRacun = (int)reader["idRacun"],
                Rb = (int)reader["rb"],
                Cena = Convert.ToDouble(reader["cena"]),
                Opis = (string)reader["opis"],
                IdFilm = (int)reader["idFilm"]
            };
        }

        public string UslovZaJednog()
        {
            return $"idRacun = {IdRacun} AND rb = {Rb}";
        }
    }
}
