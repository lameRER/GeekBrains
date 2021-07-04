using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public class DotNetMetricsRepository : BaseMetricsRepository, IDotNetMetricsRepository
    {
        private readonly ILogger _logger;
        public DotNetMetricsRepository(IConfiguration configuration, ILogger logger) : base(configuration)
        {
            _logger = logger;
        }

        public List<DotNetMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM DotNetMetric WHERE Time >= ({fromTime} AND Time <= {toTime}"
            };
            
            var result = new List<DotNetMetric>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new DotNetMetric
                {
                    Id = (int)reader["Id"], 
                    Value = (int)reader["Value"], 
                    Time = (DateTimeOffset)reader["Time"]
                });
            }
            
            return result;
        }

        public void Create(DotNetMetric item)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"INSERT INTO DotNetMetric(value, Time) VALUES({item.Value}, {item.Time.ToUnixTimeSeconds()})"
            };
            _logger.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}