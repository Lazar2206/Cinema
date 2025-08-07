using Domen;
using Domen.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Transactions;

namespace DBBroker
{
    public class Broker
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9SCJBQ\\SQLEXPRESS;Initial Catalog=seminarski;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlTransaction tran;
        private static Broker instance;
        public SqlCommand CreateCommand()
        {
            var command = con.CreateCommand();
            if (tran != null)
            {
                command.Transaction = tran;
            }
            return command;
        }
        public SqlConnection VratiKonekciju()
        {
            return con;
        }

        public static Broker Instance
        {
            get
            {
                if (instance == null)
                    instance = new Broker();
                return instance;
            }
        }
       
        public void PoveziSe()
        {
            con.Open();
            Debug.WriteLine(">>>>Uspesno povezivanje sa bazom");
            
        }

        public void ZatvoriKonekciju()
        {
            con.Close();
            Debug.WriteLine(">>>Uspesno zatvaranje konekcije sa bazom");
        }
        public void BeginTranscation()
        {
            tran = con.BeginTransaction();
        }

        public void Commit()
        {
            tran.Commit();
        }

        public void Rollback()
        {
            tran.Rollback();
        }
       
        public int VratiSledeciRB(int idRacun)
        {
            int sledeciRb = 1; // podrazumevano ako nema nijedne stavke

            try
            {
                
                {
                    con.Open();

                    string upit = "SELECT MAX(Rb) FROM StavkaRacuna WHERE IdRacun = @idRacun";
                    using (SqlCommand cmd = new SqlCommand(upit, con))
                    {
                        cmd.Parameters.AddWithValue("@idRacun", idRacun);

                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            sledeciRb = Convert.ToInt32(result) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Po želji možeš logovati grešku
                throw new Exception("Greška prilikom određivanja sledećeg rednog broja stavke.", ex);
            }

            return sledeciRb;
        }



        public List<PrikazStavkeRacuna> VratiStavkeRacuna(int idRacun)
        {
            List<PrikazStavkeRacuna> stavke = new List<PrikazStavkeRacuna>();

            string upit = @"
    SELECT sr.rb, sr.opis, sr.cena, f.naslov
    FROM StavkaRacuna sr
    JOIN Film f ON sr.idFilm = f.idFilm
    WHERE sr.idRacun = @idRacun";

            try
            {
                PoveziSe();
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("@idRacun", idRacun);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var stavka = new PrikazStavkeRacuna
                    {
                        Rb = (int)reader["rb"],
                        Opis = reader["opis"].ToString(),
                        Cena = (double)reader["cena"],
                        NaslovFilma = reader["naslov"].ToString()
                    };
                    stavke.Add(stavka);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">> Greška: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return stavke;
        }
        public bool KreirajRacun(Racun racun)
        {
            string upit = @"INSERT INTO Racun (datum, ukupnaCena, idBioskop, idGledalac)
                    VALUES (@datum, @ukupnaCena, @idBioskop, @idGledalac)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@datum", racun.Datum);
                cmd.Parameters.AddWithValue("@ukupnaCena", racun.UkupnaCena);
                cmd.Parameters.AddWithValue("@idBioskop", racun.IdBioskop);
                cmd.Parameters.AddWithValue("@idGledalac", racun.IdGledalac);

                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> Greška u brokeru (KreirajRacun): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public int VratiIdNajnovijegRacuna()
        {
            int id = 0;
            string upit = "SELECT MAX(idRacun) FROM Racun";
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    id = (int)result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> Greška u brokeru (VratiIdNajnovijegRacuna): " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return id;
        }
        public bool AzurirajUkupnuCenu(int idRacun, double novaCena)
        {
            string upit = "UPDATE Racun SET ukupnaCena = @ukupnaCena WHERE idRacun = @idRacun";
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@ukupnaCena", novaCena);
                cmd.Parameters.AddWithValue("@idRacun", idRacun);

                int uspesno = cmd.ExecuteNonQuery();
                return uspesno == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> Greška u brokeru (AzurirajUkupnuCenu): " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
    }
}
