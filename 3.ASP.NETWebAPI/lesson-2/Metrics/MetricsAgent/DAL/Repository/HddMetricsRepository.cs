using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using MetricsAgent.DAL.SQLite;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public class HddMetricsRepository : BaseMetricsRepository, IHddMetricsRepository
    {
        public HddMetricsRepository(
            IConfiguration configuration, 
            IConnectionManager connectionManager,
            ILogger logger) 
            : base(
                configuration, 
                connectionManager,
                logger) { }

        public List<HddMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM HddMetric WHERE Time >= ({fromTime} AND Time <= {toTime}"
            };
            
            var result = new List<HddMetric>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new HddMetric
                {
                    Id = (int)reader["Id"], 
                    Value = (int)reader["Value"], 
                    Time = (DateTimeOffset)reader["Time"]
                });
            }
            
            return result;
        }

        public void Create(HddMetric item)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"INSERT INTO HddMetric(value, Time) VALUES({item.Value}, {item.Time.ToUnixTimeSeconds()})"
            };
            Logger.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}