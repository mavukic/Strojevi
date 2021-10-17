using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Strojevi.Interfaces;
using Strojevi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Strojevi.Repository
{
    public class StrojRepository : IStroj
    {
        private string connectionString;
        public StrojRepository(IConfiguration configuration)
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


        public void Dodaj(Stroj stroj)
        {
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute("INSERT INTO stroj (naziv) VALUES(@Naziv)", stroj);
                }
                catch(Exception ex)
                {

                    Console.WriteLine("Something went wrong, and you'll know it");
                }
            }
        }

        void IStroj.Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM stroj WHERE id = @Id", new { Id = id });
            }
        }

        IEnumerable<Stroj> IStroj.Get(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Stroj>("SELECT * FROM stroj WHERE id = @Id", new { Id = id });
            }
        }

        IEnumerable<Stroj> IStroj.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Stroj>("SELECT * FROM stroj");
            }
        }

        IEnumerable<Kvar> IStroj.GetKvarovi()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kvar>("select opis,imeStroja,vrijemepocetka,vrijemezavrsetka from kvar inner join stroj on kvar.imestroja= stroj.naziv");


            }
        }

        void IStroj.Update(int id, Stroj stroj)
        {
            using (IDbConnection dbConnection = Connection)
            {

                dbConnection.Open();
                dbConnection.Query<Stroj>("UPDATE stroj SET  naziv='" + stroj.Naziv +
               "' WHERE id=" + stroj.Id);
            }
        }
    }
}
