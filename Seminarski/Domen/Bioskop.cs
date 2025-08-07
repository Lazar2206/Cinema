using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Bioskop : DomenskiObjekat
    {
        public int IdBioskop { get; set; }
        public string NazivBioskopa { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string AdresaBioskopa { get; set; }  

        public string NazivTabele => "Bioskop";

        string DomenskiObjekat.UslovZaSelect => "";

        public string InsertKolone => "NazivBioskopa, KorisnickoIme, Sifra, AdresaBioskopa";

        public string InsertVrednosti =>
            $"'{NazivBioskopa}', '{KorisnickoIme}', '{Sifra}', '{AdresaBioskopa}'";

        public string VrednostiZaUpdate => "";

        public string UslovZaUpdate => $"idBioskop={IdBioskop}";

        public string PrimarniKljucKolona => "idBioskop";

        public string UslovZaJednog()
        {
            return $"KorisnickoIme = '{KorisnickoIme}' AND Sifra = '{Sifra}'";
        }
        public  string UslovZaSelect()
        {
            return $"KorisnickoIme = '{KorisnickoIme}' AND Sifra = '{Sifra}'";
        }
         


        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            return new Bioskop
            {
                IdBioskop = (int)reader["IdBioskop"],
                NazivBioskopa = reader["NazivBioskopa"].ToString(),
                KorisnickoIme = reader["KorisnickoIme"].ToString(),
                Sifra = reader["Sifra"].ToString(),
                AdresaBioskopa = reader["AdresaBioskopa"].ToString()
            };
        }
    }

}
