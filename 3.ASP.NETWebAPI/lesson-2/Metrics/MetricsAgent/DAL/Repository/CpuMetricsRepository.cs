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
    public class CpuMetricsRepository : BaseMetricsRepository, ICpuMetricsRepository
    {
        private readonly ILogger _logger;
        public CpuMetricsRepository(IConfiguration configuration, ILogger logger) : base(configuration)
        {
            _logger = logger;
        }

        public List<CpuMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var cmd = new SQLiteCommand(connection)
            {
                CommandText = $"SELECT * FROM CpuMetrics WHERE Time >= {fromTime.ToUnixTimeSeconds()} AND Time <= {toTime.ToUnixTimeSeconds()}"
            };
            _logger.Debug(cmd.CommandText);
            
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
            _logger.Debug(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
    }
}