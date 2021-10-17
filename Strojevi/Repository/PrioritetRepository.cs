using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Strojevi.Interfaces;
using Strojevi.Models;
using System.Collections.Generic;
using System.Data;

namespace Strojevi.Repository
{
    public class PrioritetRepository : IPrioritet
    {
        private string connectionString;
        public PrioritetRepository(IConfiguration configuration)
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

        IEnumerable<Prioritet> IPrioritet.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
              return  dbConnection.Query<Prioritet>("SELECT * FROM prioritet");
            }
        }
    }
}