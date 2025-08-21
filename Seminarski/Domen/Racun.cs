using Microsoft.Data.SqlClient;
using System;

namespace Domen
{
    public class Racun : DomenskiObjekat
    {
        public int IdRacun { get; set; }
        public DateTime Datum { get; set; }
        public double UkupnaCena { get; set; }
        public int IdBioskop { get; set; }
        public int IdGledalac { get; set; }
        public string VrednostiZaUpdateManual { get; set; }
        public string UslovZaUpdateManual { get; set; }

        public string NazivTabele => "Racun";

        public string InsertKolone => "datum, ukupnaCena, idBioskop, idGledalac";

        public string InsertVrednosti =>
            $"'{Datum:yyyy-MM-dd}', {UkupnaCena}, {IdBioskop}, {IdGledalac}";

        public string UslovZaSelect => $"idRacun = {IdRacun}";

        public string VrednostiZaUpdate =>
            $"datum = '{Datum:yyyy-MM-dd}', ukupnaCena = {UkupnaCena}, idBioskop = {IdBioskop}, idGledalac = {IdGledalac}";

        public string UslovZaUpdate => $"idRacun = {IdRacun}";

        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            return new Racun
            {
                IdRacun = (int)reader["idRacun"],
                Datum = (DateTime)reader["datum"],
                UkupnaCena = Convert.ToDouble(reader["ukupnaCena"]),
                IdBioskop = (int)reader["idBioskop"],
                IdGledalac = (int)reader["idGledalac"]
            };
        }
        public string UslovZaJednog()
        {
            return $"idRacun = {IdRacun}";
        }
        public string VrednostiZaUkupnuCenuUpdate =>
    $"UkupnaCena = {UkupnaCena.ToString(System.Globalization.CultureInfo.InvariantCulture)}";

        public string UslovZaUkupnuCenuUpdate =>
            $"IdRacun = {IdRacun}";

        public string PrimarniKljucKolona => "idRacun";
    }
}
