using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Strojevi.Interfaces;
using Strojevi.Models;
using System.Collections.Generic;
using System.Data;

namespace Strojevi.Repository
{
    public class KvarRepository : IKvar
    {
        private string connectionString;
        public KvarRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }


        public void Dodaj(Kvar kvar)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO kvar (opis,imeStroja,vrijemepocetka,vrijemezavrsetka,status,prioritet) VALUES(@Opis,@ImeStroja,@VrijemePocetka,@VrijemeZavrsetka,@Status,@Prioritet)", kvar);
            }
        }  
      


        IEnumerable<Kvar> IKvar.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kvar>("SELECT * FROM kvar");
            }
        }

        void IKvar.Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM kvar WHERE id = @Id", new { Id = id });
            }
        }

        IEnumerable<Kvar> IKvar.Get(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kvar>("SELECT * FROM kvar WHERE id = @Id", new { Id = id });
            }
        }

        void IKvar.Update(int id, Kvar kvar)
        {
            using (IDbConnection dbConnection = Connection)
            {

                dbConnection.Open();
                dbConnection.Query<Kvar>("UPDATE kvar SET  opis='" + kvar.Opis +
               "',imeStroja='" + kvar.ImeStroja +
               "',vrijemepocetka='" + kvar.VrijemePocetka +
               "',vrijemezavrsetka = '" + kvar.VrijemeZavrsetka +
               "',status='" + kvar.status +
               "', prioritet='" + kvar.prioritet +
               "' WHERE id=" + kvar.Id);
            }
        }
    }
    }

