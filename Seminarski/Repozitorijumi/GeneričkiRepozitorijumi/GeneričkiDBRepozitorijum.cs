using DBBroker;
using Domen;
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

    }
}
