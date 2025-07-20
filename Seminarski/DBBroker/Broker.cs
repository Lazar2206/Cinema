using Domen;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DBBroker
{
    public class Broker
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9SCJBQ\\SQLEXPRESS;Initial Catalog=seminarski;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlTransaction tran;
        private static Broker instance;

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
        public List<Bioskop> VratiSveBioskope()
        {
            List<Bioskop> bioskopi = new List<Bioskop>();
            string upit = "select* from bioskop";
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop p = new Bioskop()
                    {
                        NazivBioskopa = (string)reader["nazivBioskopa"],
                        AdresaBioskopa = (string)reader["adresaBioskopa"],
                        KorisnickoIme = (string)reader["korisnickoIme"],
                        Sifra = (string)reader["sifra"],
                        
                    };
                    bioskopi.Add(p);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>>>Greska u brokeru: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }
            return bioskopi;

        }

        public List<Mesto> VratiMesta()
        {
            List<Mesto> mesta = new List<Mesto>();
            string upit = "SELECT * FROM Mesto";

            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;
                

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mesto m = new Mesto()
                    {
                        IdMesto = (int)reader["idMesto"],
                        NazivMesta = (string)reader["nazivMesta"],
                    };

                    mesta.Add(m);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>Greška u brokeru: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return mesta;

        }

        public List<Gledalac> VratiGledaoce(Gledalac kriterijum)
        {
            List<Gledalac> gledaoci = new List<Gledalac>();
            List<string> uslovi = new List<string>();
            SqlCommand cmd = new SqlCommand();

            // Dinamičko dodavanje uslova
            if (!string.IsNullOrWhiteSpace(kriterijum.Ime))
            {
                uslovi.Add("ime LIKE @ime");
                cmd.Parameters.AddWithValue("@ime", "%" + kriterijum.Ime + "%");
            }

            if (kriterijum.IdMesto != 0)
            {
                uslovi.Add("idMesto = @idMesto");
                cmd.Parameters.AddWithValue("@idMesto", kriterijum.IdMesto);
            }

            string where = uslovi.Count > 0 ? " WHERE " + string.Join(" AND ", uslovi) : "";

            string upit = "SELECT * FROM Gledalac" + where;

            try
            {
                PoveziSe();
                cmd.Connection = con;
                cmd.CommandText = upit;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gledalac g = new Gledalac()
                    {
                        IdGledalac = (int)reader["idGledalac"],
                        IdMesto = (int)reader["idMesto"],
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        Mejl=(string)reader["mejl"]
                    };

                    gledaoci.Add(g);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>Greška u brokeru: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return gledaoci;
        }

        public bool PromeniGledaoca(Gledalac g)
        {
            string upit = @"UPDATE Gledalac SET 
                        ime = @ime,
                        prezime = @prezime,
                        idMesto = @idMesto,
                        mejl = @mejl
                    WHERE idGledalac = @idGledalac";

            try
            {
                PoveziSe();

                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("@ime", g.Ime);
                cmd.Parameters.AddWithValue("@prezime", g.Prezime);
                cmd.Parameters.AddWithValue("@idMesto", g.IdMesto);
                cmd.Parameters.AddWithValue("@idGledalac", g.IdGledalac);
                cmd.Parameters.AddWithValue("@mejl", g.Mejl);

                int uspesno = cmd.ExecuteNonQuery();
                return uspesno == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> Greška u azuriranju gledaoca: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public bool ObrišiGledalac(Gledalac gledalac)
        {
            try
            {
                PoveziSe();
                BeginTranscation();

                // 1. Obriši stavke svih računa gledaoce
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.Transaction = tran;
                cmd0.CommandText = $@"
            DELETE FROM StavkaRacuna 
            WHERE idRacun IN (SELECT idRacun FROM Racun WHERE idGledalac = {gledalac.IdGledalac})";
                cmd0.ExecuteNonQuery();

                // 2. Obriši sve račune gledaoce
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.Transaction = tran;
                cmd1.CommandText = $"DELETE FROM Racun WHERE idGledalac = {gledalac.IdGledalac}";
                cmd1.ExecuteNonQuery();

                // 3. Obriši samog gledaoca
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.Transaction = tran;
                cmd2.CommandText = $"DELETE FROM Gledalac WHERE idGledalac = {gledalac.IdGledalac}";
                int uspešno = cmd2.ExecuteNonQuery();

                Commit();
                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>>Greska u brokeru: " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public bool KreirajGledalac(Gledalac gledalac)
        {
            string upit = "INSERT INTO Gledalac (ime, prezime, mejl, idMesto) " +
                          "VALUES (@ime, @prezime, @mejl, @idMesto)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@ime", gledalac.Ime);
                cmd.Parameters.AddWithValue("@prezime", gledalac.Prezime);
                cmd.Parameters.AddWithValue("@mejl", gledalac.Mejl);
                cmd.Parameters.AddWithValue("@idMesto", gledalac.IdMesto);

                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (KreirajGledaoca): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
    }
}
