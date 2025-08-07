using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Gledalac : DomenskiObjekat
    {
        public int IdGledalac { get; set; }
      
        public int IdMesto { get; set; }    
        public string Ime { get; set; }
        public string Prezime { get; set; }
   
        public string Mejl { get; set; }
        public string Prikaz => $"{Ime} {Prezime}";

        public string NazivTabele => "Gledalac";

        public string UslovZaSelect
        {
            get
            {
                List<string> uslovi = new List<string>();

                if (!string.IsNullOrWhiteSpace(Ime))
                    uslovi.Add($"ime LIKE '%{Ime}%'");

                if (IdMesto > 0)
                    uslovi.Add($"idMesto = {IdMesto}");

                if (uslovi.Count == 0)
                    return "1=1"; // da ne padne WHERE deo

                return string.Join(" AND ", uslovi);
            }
        }

        public string VrednostiZaUpdate => $"ime = '{Ime}', prezime = '{Prezime}', idMesto = {IdMesto}, mejl = '{Mejl}'";

       

        public string InsertKolone => "ime, prezime, mejl, idMesto";

        public string InsertVrednosti =>
            $"'{Ime}', '{Prezime}', '{Mejl}', {IdMesto}";

        public string UslovZaUpdate => $"idGledalac = {IdGledalac}";

        public string UslovZaJednog() => $"{IdGledalac}, '{IdMesto}'," +
            $"'{Ime}', {Prezime}, '{Mejl}'  ";

        public DomenskiObjekat ReadRow(SqlDataReader reader)
        {
            Gledalac g = new Gledalac();
            g.Ime=(string)reader["Ime"];
            g.Prezime = (string)reader["Prezime"];
            g.IdMesto = (int)reader["IdMesto"];
            g.Mejl = (string)reader["Mejl"];
            g.IdGledalac = (int)reader["IdGledalac"];
            return g;
        }
    }

}
