using Domen;
using Domen.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
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
                        IdBioskop = (int)reader["idBioskop"],
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
                        Mejl = (string)reader["mejl"]
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

               
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.Transaction = tran;
                cmd0.CommandText = $@"
            DELETE FROM StavkaRacuna 
            WHERE idRacun IN (SELECT idRacun FROM Racun WHERE idGledalac = {gledalac.IdGledalac})";
                cmd0.ExecuteNonQuery();

                
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.Transaction = tran;
                cmd1.CommandText = $"DELETE FROM Racun WHERE idGledalac = {gledalac.IdGledalac}";
                cmd1.ExecuteNonQuery();

            
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

        public bool KreirajMesto(Mesto mesto)
        {
            string upit = "INSERT INTO Mesto (nazivMesta) " +
                          "VALUES (@nazivMesta)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@nazivMesta", mesto.NazivMesta);


                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (KreirajMesto): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public List<Film> VratiFilmove()
        {
            List<Film> filmovi = new List<Film>();
            string upit = "SELECT * FROM Film";

            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Film f = new Film()
                    {
                        IdFilm = (int)reader["idFilm"],
                        Naslov = (string)reader["naslov"],
                        Zanr = Enum.Parse<Žanr>(reader["zanr"].ToString()),
                        Pocetak = (TimeSpan)reader["pocetak"],
                        Kraj = (TimeSpan)reader["kraj"],
                        TrajanjeMinuti = (int)reader["trajanjeMinuti"]
                    };

                    filmovi.Add(f);
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

            return filmovi;
        }

        public bool KreirajFilm(Film film)
        {
            string upit = "INSERT INTO Film (naslov, zanr, pocetak, kraj, trajanjeMinuti) " +
                          "VALUES (@naslov, @zanr, @pocetak, @kraj, @trajanjeMinuti)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@naslov", film.Naslov);
                cmd.Parameters.AddWithValue("@zanr", film.Zanr.ToString());
                cmd.Parameters.AddWithValue("@pocetak", film.Pocetak);
                cmd.Parameters.AddWithValue("@kraj", film.Kraj);
                cmd.Parameters.AddWithValue("@trajanjeMinuti", film.TrajanjeMinuti);

                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (KreirajFilm): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public List<Distributer> VratiDistributere(Distributer kriterijum)
        {
            List<Distributer> distributeri = new List<Distributer>();
            List<string> uslovi = new List<string>();
            SqlCommand cmd = new SqlCommand();

           
            if (!string.IsNullOrWhiteSpace(kriterijum.NazivDistributera))
            {
                uslovi.Add("nazivDistributera LIKE @nazivDistributera");
                cmd.Parameters.AddWithValue("@nazivDistributera", "%" + kriterijum.NazivDistributera + "%");
            }



            string where = uslovi.Count > 0 ? " WHERE " + string.Join(" AND ", uslovi) : "";

            string upit = "SELECT * FROM Distributer" + where;

            try
            {
                PoveziSe();
                cmd.Connection = con;
                cmd.CommandText = upit;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Distributer d = new Distributer()
                    {
                        IdDistributer = (int)reader["idDistributer"],
                        NazivDistributera = (string)reader["nazivDistributera"],

                    };

                    distributeri.Add(d);
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

            return distributeri;
        }

        public bool KreirajDistributera(Distributer distributer)
        {
            string upit = "INSERT INTO Distributer (nazivDistributera) VALUES (@nazivDistributera)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@nazivDistributera", distributer.NazivDistributera);

                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (KreirajDistributera): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public bool ObrisiDistributera(Distributer distributer)
        {
            try
            {
                PoveziSe();
                BeginTranscation();

               
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.Transaction = tran;
                cmd1.CommandText = "DELETE FROM TabelaProjekcija WHERE idDistributer = @idDistributer";
                cmd1.Parameters.AddWithValue("@idDistributer", distributer.IdDistributer);
                cmd1.ExecuteNonQuery();


                SqlCommand cmd2 = con.CreateCommand();
                cmd2.Transaction = tran;
                cmd2.CommandText = "DELETE FROM Distributer WHERE idDistributer = @idDistributer";
                cmd2.Parameters.AddWithValue("@idDistributer", distributer.IdDistributer);
                int uspesno = cmd2.ExecuteNonQuery();

                Commit();
                return uspesno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (ObrisiDistributera): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }


        public bool PromeniDistributera(Distributer d)
        {
            string upit = @"UPDATE Distributer SET 
                    nazivDistributera = @naziv
                WHERE idDistributer = @id";

            try
            {
                PoveziSe();

                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("@naziv", d.NazivDistributera);
                cmd.Parameters.AddWithValue("@id", d.IdDistributer);

                int uspesno = cmd.ExecuteNonQuery();
                return uspesno == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> Greška u ažuriranju distributera: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public List<Gledalac> VratiGledaoce()
        {
            List<Gledalac> gledaoci = new List<Gledalac>();
            List<string> uslovi = new List<string>();
            SqlCommand cmd = new SqlCommand();




            string upit = "SELECT * FROM Gledalac";

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
                        Mejl = (string)reader["mejl"]
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

        public bool DodajStavkuRacuna(StavkaRacuna stavka)
        {
            try
            {
                PoveziSe();
                BeginTranscation();

                int noviRb = VratiSledeciRB(stavka.IdRacun, con, tran); 

                string upit = "INSERT INTO StavkaRacuna (idRacun, rb, cena, opis, idFilm) " +
                              "VALUES (@idRacun, @rb, @cena, @opis, @idFilm)";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@idRacun", stavka.IdRacun);
                cmd.Parameters.AddWithValue("@rb", noviRb);
                cmd.Parameters.AddWithValue("@cena", stavka.Cena);
                cmd.Parameters.AddWithValue("@opis", stavka.Opis);
                cmd.Parameters.AddWithValue("@idFilm", stavka.IdFilm);

                int uspešno = cmd.ExecuteNonQuery();
                Commit();
                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (DodajStavkuRacuna): " + ex.Message);
                Rollback();
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        private int VratiSledeciRB(int idRacun, SqlConnection con, SqlTransaction tran)
        {
            int id = 0;
            string upit = $"select max(rb) from StavkaRacuna where idRacun = @idRacun";

            SqlCommand cmd = new SqlCommand(upit, con, tran);
            cmd.Parameters.AddWithValue("@idRacun", idRacun);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                id = (int)result;
            }

            return ++id;
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

        public List<PrikazRacuna> VratiRacune(Racun kriterijum)
        {
            List<PrikazRacuna> racuni = new List<PrikazRacuna>();
            List<string> uslovi = new List<string>();
            SqlCommand cmd = new SqlCommand();

            if (kriterijum.IdGledalac > 0)
            {
                uslovi.Add("r.idGledalac = @idGledalac");
                cmd.Parameters.AddWithValue("@idGledalac", kriterijum.IdGledalac);
            }

            if (kriterijum.IdBioskop > 0)
            {
                uslovi.Add("r.idBioskop = @idBioskop");
                cmd.Parameters.AddWithValue("@idBioskop", kriterijum.IdBioskop);
            }

            if (kriterijum.Datum != DateTime.MinValue)
            {
                uslovi.Add("CAST(r.datum AS DATE) = @datum");
                cmd.Parameters.AddWithValue("@datum", kriterijum.Datum.Date);
            }

            string where = uslovi.Count > 0 ? " WHERE " + string.Join(" AND ", uslovi) : "";

            string upit = @" SELECT  r.idRacun, r.datum, r.ukupnaCena,  g.ime + ' ' + g.prezime AS ImeGledaoca, b.nazivBioskopa AS NazivBioskopa
                             FROM Racun r
                             JOIN Gledalac g ON r.idGledalac = g.idGledalac
                             JOIN Bioskop b ON r.idBioskop = b.idBioskop  " + where;

            try
            {
                PoveziSe();
                cmd.Connection = con;
                cmd.CommandText = upit;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PrikazRacuna r = new PrikazRacuna
                    {
                        IdRacun = (int)reader["idRacun"],
                        Datum = (DateTime)reader["datum"],
                        UkupnaCena = Convert.ToDouble(reader["ukupnaCena"]),
                        ImeGledaoca = reader["ImeGledaoca"].ToString(),
                        NazivBioskopa = reader["NazivBioskopa"].ToString()
                    };
                    racuni.Add(r);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return racuni;
        }

        public bool IzmeniStavkuRacuna(StavkaRacuna sr)
        {
            try
            {
                PoveziSe(); 

                using (SqlCommand command = new SqlCommand(@"
            UPDATE StavkaRacuna 
            SET Opis = @Opis, 
                Cena = @Cena, 
                IdFilm = @IdFilm
            WHERE IdRacun = @IdRacun AND Rb = @Rb", con))
                {
                    command.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = sr.Opis;
                    command.Parameters.Add("@Cena", SqlDbType.Float).Value = sr.Cena;
                    command.Parameters.Add("@IdFilm", SqlDbType.Int).Value = sr.IdFilm;
                    command.Parameters.Add("@IdRacun", SqlDbType.Int).Value = sr.IdRacun;
                    command.Parameters.Add("@Rb", SqlDbType.Int).Value = sr.Rb;

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">> Greška pri izmeni stavke računa: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju(); // obavezno zatvori konekciju
            }
        }
        public bool AzurirajUkupnuCenuRacuna(int idRacun)
        {
            try
            {
                PoveziSe();

                decimal ukupno = 0;

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT SUM(Cena)
            FROM StavkaRacuna
            WHERE IdRacun = @IdRacun", con))
                {
                    cmd.Parameters.AddWithValue("@IdRacun", idRacun);

                    object result = cmd.ExecuteScalar();
                    ukupno = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                }

                using (SqlCommand cmd2 = new SqlCommand(@"
            UPDATE Racun
            SET UkupnaCena = @UkupnaCena
            WHERE IdRacun = @IdRacun", con))
                {
                    cmd2.Parameters.AddWithValue("@UkupnaCena", ukupno);
                    cmd2.Parameters.AddWithValue("@IdRacun", idRacun);

                    return cmd2.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška pri ažuriranju ukupne cene: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public bool IzmeniRacun(Racun r)
        {
            try
            {
                PoveziSe(); 

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = @"UPDATE Racun 
                                    SET Datum = @Datum, 
                                        IdGledalac = @IdGledalac, 
                                        IdBioskop = @IdBioskop, 
                                        UkupnaCena = @UkupnaCena
                                    WHERE IdRacun = @IdRacun";

                    command.Parameters.AddWithValue("@Datum", r.Datum);
                    command.Parameters.AddWithValue("@IdGledalac", r.IdGledalac);
                    command.Parameters.AddWithValue("@IdBioskop", r.IdBioskop);
                    command.Parameters.AddWithValue("@UkupnaCena", r.UkupnaCena);
                    command.Parameters.AddWithValue("@IdRacun", r.IdRacun);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška pri izmeni računa: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju(); 
            }
        }
        public bool ObrisiRacun(int idRacun)
        {
            try
            {
                PoveziSe();

                using (SqlTransaction transakcija = con.BeginTransaction())
                {
                    
                    using (SqlCommand cmdStavke = new SqlCommand("DELETE FROM StavkaRacuna WHERE IdRacun = @IdRacun", con, transakcija))
                    {
                        cmdStavke.Parameters.AddWithValue("@IdRacun", idRacun);
                        cmdStavke.ExecuteNonQuery();
                    }

                
                    using (SqlCommand cmdRacun = new SqlCommand("DELETE FROM Racun WHERE IdRacun = @IdRacun", con, transakcija))
                    {
                        cmdRacun.Parameters.AddWithValue("@IdRacun", idRacun);
                        int uspesno = cmdRacun.ExecuteNonQuery();

                        transakcija.Commit();
                        return uspesno > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška pri brisanju računa: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public bool ObrisiStavkuRacuna(int idRacun, int rb)
        {
            try
            {
                PoveziSe();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM StavkaRacuna WHERE IdRacun = @IdRacun AND Rb = @Rb", con))
                {
                    cmd.Parameters.AddWithValue("@IdRacun", idRacun);
                    cmd.Parameters.AddWithValue("@Rb", rb);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška pri brisanju stavke računa: " + ex.Message);
                return false;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

      

        public bool DodajBioskop(Bioskop noviBioskop)
        {
            string upit = "INSERT INTO Bioskop (nazivBioskopa, adresaBioskopa, korisnickoIme, sifra) " +
                          "VALUES (@nazivBioskopa, @adresaBioskopa, @korisnickoIme, @sifra)";
            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                cmd.Parameters.AddWithValue("@nazivBioskopa", noviBioskop.NazivBioskopa);
                cmd.Parameters.AddWithValue("@adresaBioskopa", noviBioskop.AdresaBioskopa);
                cmd.Parameters.AddWithValue("@korisnickoIme", noviBioskop.KorisnickoIme);
                cmd.Parameters.AddWithValue("@sifra", noviBioskop.Sifra);
               

                int uspešno = cmd.ExecuteNonQuery();
                Commit();

                return uspešno > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> Greška u brokeru (KreirajFilm): " + ex.Message);
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
