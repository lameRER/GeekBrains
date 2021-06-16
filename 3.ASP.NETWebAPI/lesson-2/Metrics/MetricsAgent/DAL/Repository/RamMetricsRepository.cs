using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsLogging;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public class RamMetricsRepository : BaseMetricsRepository, IRamMetricsRepository
    {
        public RamMetricsRepository(IConfiguration configuration) : base(configuration) { }

        public List<RamMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM RamMetric WHERE Time >= ({fromTime} AND Time <= {toTime}"
            };
            
            var result = new List<RamMetric>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new RamMetric
                {
                    Id = (int)reader["Id"], 
                    Value = (int)reader["Value"], 
                    Time = (DateTimeOffset)reader["Time"]
                });
            }
            
            return result;
        }

        public void Create(RamMetric item)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"INSERT INTO RamMetric(value, Time) VALUES({item.Value}, {item.Time.ToUnixTimeSeconds()})"
            };
            Logging.Log.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}