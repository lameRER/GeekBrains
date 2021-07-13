using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using MetricsAgent.DAL.SQLite;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public class RamMetricsRepository : BaseMetricsRepository, IRamMetricsRepository
    {
        public RamMetricsRepository(
            IConfiguration configuration,
            IConnectionManager connectionManager,
            ILogger logger)
            : base(
                configuration,
                connectionManager,
                logger) { }

        public List<RamMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            var result = connectionString.Query<RamMetric>(
                "SELECT * FROM RamMetrics WHERE Time >= @fromTime AND Time <= @toTime",
                new
                {
                    fromTime,
                    toTime
                }).ToList();
            return result;
        }

        public void Create(RamMetric item)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            connectionString.Execute(
                "INSERT INTO RamMetrics(value, Time) VALUES(@Value, @Time)",
                new
                {
                    item.Value,
                    item.Time
                });
        }
    }
}