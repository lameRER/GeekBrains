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
    public class CpuMetricsRepository : BaseMetricsRepository, ICpuMetricsRepository
    {
        public CpuMetricsRepository(
            IConfiguration configuration, 
            IConnectionManager connectionManager, 
            ILogger logger) 
            : base(
                configuration, 
                connectionManager, 
                logger) { }

        public List<CpuMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();// Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM CpuMetrics WHERE Time >= {fromTime.ToUnixTimeSeconds()} AND Time <= {toTime.ToUnixTimeSeconds()}"
            };
            Logger.Debug(cmd.CommandText);
            
            var result = new List<CpuMetric>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new CpuMetric
                {
                    Id = reader.GetInt32(0), 
                    Value = reader.GetInt32(1), 
                    Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(2)).ToOffset(TimeZoneInfo.Local.BaseUtcOffset)
                });
            }
            
            return result;
        }

         public void Create(CpuMetric item)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"INSERT INTO CpuMetrics(value, Time) VALUES({item.Value}, {item.Time.ToUnixTimeSeconds()})"
            };
            Logger.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}