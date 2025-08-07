using DBBroker;
using Domen;
using Domen.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repozitorijumi.GeneričkiRepozitorijumi
{
    public class GeneričkiRepozitorijum
    {
        private readonly Broker broker = Broker.Instance;

        public void PoveziSe() => broker.PoveziSe();
        public void ZatvoriKonekciju() => broker.ZatvoriKonekciju();
        public void BeginTransakcija() => broker.BeginTranscation();
        public void Commit() => broker.Commit();
        public void Rollback() => broker.Rollback();

        public List<DomenskiObjekat> VratiSve(DomenskiObjekat domenskiObjekat)
        {
            var lista = new List<DomenskiObjekat>();
            var komanda = broker.CreateCommand();

            komanda.CommandText = $"SELECT * FROM {domenskiObjekat.NazivTabele}";
            var reader = komanda.ExecuteReader();
            while (reader.Read())
                lista.Add(domenskiObjekat.ReadRow(reader));
            reader.Close();
            return lista;
        }

        public DomenskiObjekat VratiJednog(DomenskiObjekat kriterijum)
        {
            var komanda = broker.CreateCommand();
            komanda.CommandText = $"SELECT * FROM {kriterijum.NazivTabele} WHERE {kriterijum.UslovZaSelect}";
            var reader = komanda.ExecuteReader();
            if (reader.Read())
            {
                var obj = kriterijum.ReadRow(reader);
                reader.Close();
                return obj;
            }
            reader.Close();
            return null;
        }
        public DomenskiObjekat SelectOne(DomenskiObjekat kriterijum)
        {
            SqlCommand command = broker.CreateCommand();
            command.CommandText = $"SELECT * FROM {kriterijum.NazivTabele} WHERE {kriterijum.UslovZaJednog()}";

            SqlDataReader reader = command.ExecuteReader();
            DomenskiObjekat rezultat = null;

            if (reader.Read())
            {
                rezultat = kriterijum.ReadRow(reader);
            }

            reader.Close();
            return rezultat;
        }
        public List<DomenskiObjekat> VratiSvaMesta(DomenskiObjekat objekat)
        {
            List<DomenskiObjekat> lista = new List<DomenskiObjekat>();

            SqlCommand command = broker.CreateCommand();
            command.CommandText = $"SELECT * FROM {objekat.NazivTabele}";

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(objekat.ReadRow(reader));
            }

            reader.Close();
            return lista;
        }
        public bool Insert(DomenskiObjekat objekat)
        {
            SqlCommand command = broker.CreateCommand();
            

            string upit = $"INSERT INTO {objekat.NazivTabele} ({objekat.InsertKolone}) " +
                          $"VALUES ({objekat.InsertVrednosti})";

            command.CommandText = upit;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public List<DomenskiObjekat> VratiPoUslovu(DomenskiObjekat kriterijum)
        {
            List<DomenskiObjekat> lista = new List<DomenskiObjekat>();

            SqlCommand command = broker.CreateCommand();
            command.CommandText = $"SELECT * FROM {kriterijum.NazivTabele} WHERE {kriterijum.UslovZaSelect}";

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(kriterijum.ReadRow(reader));
            }

            reader.Close();
            return lista;
        }
        public bool Update(DomenskiObjekat objekat)
        {
            SqlCommand command = broker.CreateCommand();

            string upit = $"UPDATE {objekat.NazivTabele} SET {objekat.VrednostiZaUpdate} WHERE {objekat.UslovZaUpdate}";
            Debug.WriteLine(">> UPDATE UPIT: " + upit);

            command.CommandText = upit;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public bool Delete(DomenskiObjekat objekat)
        {
            SqlCommand command = broker.CreateCommand();
            string upit = $"DELETE FROM {objekat.NazivTabele} WHERE {objekat.UslovZaUpdate}";
            Debug.WriteLine(">> DELETE upit: " + upit);

            command.CommandText = upit;
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public bool AzurirajUkupnuCenuRacuna(int idRacun)
        {
            try
            {
                string upit = @"
            UPDATE Racun
            SET ukupnaCena = (
                SELECT SUM(cena)
                FROM StavkaRacuna
                WHERE idRacun = @idRacun
            )
            WHERE idRacun = @idRacun";

                SqlCommand command = broker.CreateCommand();
                command.CommandText = upit;
                command.Parameters.AddWithValue("@idRacun", idRacun);

                return command.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }
        public int VratiSledeciRB(int idRacun)
        {
            try
            {
                broker.PoveziSe(); // otvori konekciju ako nije već otvorena

                string upit = "SELECT MAX(Rb) FROM StavkaRacuna WHERE IdRacun = @idRacun";
                using (SqlCommand cmd = new SqlCommand(upit, broker.VratiKonekciju()))
                {
                    cmd.Parameters.AddWithValue("@idRacun", idRacun);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return Convert.ToInt32(result) + 1;
                    }

                    return 1; // ako nema nijedne stavke
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška prilikom određivanja sledećeg RB stavke računa.", ex);
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }
        public List<PrikazRacuna> VratiRacune(Racun kriterijum)
        {
            List<PrikazRacuna> lista = new List<PrikazRacuna>();

            try
            {
                SqlCommand command = broker.CreateCommand();

                List<string> uslovi = new List<string>();

                if (kriterijum.IdGledalac > 0)
                {
                    uslovi.Add("r.idGledalac = @idGledalac");
                    command.Parameters.AddWithValue("@idGledalac", kriterijum.IdGledalac);
                }

                if (kriterijum.IdBioskop > 0)
                {
                    uslovi.Add("r.idBioskop = @idBioskop");
                    command.Parameters.AddWithValue("@idBioskop", kriterijum.IdBioskop);
                }

                if (kriterijum.Datum != DateTime.MinValue)
                {
                    uslovi.Add("CAST(r.datum AS DATE) = @datum");
                    command.Parameters.AddWithValue("@datum", kriterijum.Datum.Date);
                }

                string whereClause = uslovi.Count > 0 ? " WHERE " + string.Join(" AND ", uslovi) : "";

                string upit = $@"
            SELECT 
                r.idRacun,
                r.datum,
                r.ukupnaCena,
                g.ime + ' ' + g.prezime AS ImeGledaoca,
                b.nazivBioskopa AS NazivBioskopa
            FROM Racun r
            JOIN Gledalac g ON r.idGledalac = g.idGledalac
            JOIN Bioskop b ON r.idBioskop = b.idBioskop
            {whereClause}";

                command.CommandText = upit;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PrikazRacuna pr = new PrikazRacuna
                        {
                            IdRacun = (int)reader["idRacun"],
                            Datum = (DateTime)reader["datum"],
                            UkupnaCena = Convert.ToDouble(reader["ukupnaCena"]),
                            ImeGledaoca = reader["ImeGledaoca"].ToString(),
                            NazivBioskopa = reader["NazivBioskopa"].ToString()
                        };

                        lista.Add(pr);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška u VratiRacune: " + ex.Message);
            }

            return lista;
        }
    }
}
