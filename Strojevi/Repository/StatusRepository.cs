using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Strojevi.Interfaces;
using Strojevi.Models;
using System.Collections.Generic;
using System.Data;

namespace Strojevi.Repository
{
    public class StatusRepository : IStatus
    {
        private string connectionString;
        public StatusRepository(IConfiguration configuration)
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

        IEnumerable<Status> IStatus.GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Status>("SELECT * FROM status");
            }
        }
    }
}