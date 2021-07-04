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
    public class NetworkMetricsRepository : BaseMetricsRepository, INetworkMetricsRepository
    {
        public NetworkMetricsRepository(
            IConfiguration configuration,
            IConnectionManager connectionManager,
            ILogger logger)
            : base(
                configuration,
                connectionManager,
                logger) { }

        public List<NetworkMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM NetworkMetric WHERE Time >= ({fromTime} AND Time <= {toTime}"
            };
            
            var result = new List<NetworkMetric>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new NetworkMetric
                {
                    Id = (int)reader["Id"], 
                    Value = (int)reader["Value"], 
                    Time = (DateTimeOffset)reader["Time"]
                });
            }
            
            return result;
        }

        public void Create(NetworkMetric item)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"INSERT INTO NetworkMetric(value, Time) VALUES({item.Value}, {item.Time.ToUnixTimeSeconds()})"
            };
            Logger.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}