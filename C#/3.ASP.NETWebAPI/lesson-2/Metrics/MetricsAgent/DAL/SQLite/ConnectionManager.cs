using System.Data.SQLite;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.SQLite
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConfiguration _configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SQLiteConnection CreateOpenedConnection()
        {
            var conn = new SQLiteConnection(_configuration.GetConnectionString("SqlLite"));
            return conn;
        }
    }
}