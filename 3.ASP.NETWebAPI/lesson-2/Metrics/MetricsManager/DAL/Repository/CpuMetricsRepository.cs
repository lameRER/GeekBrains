using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MetricsManager.DAL.Interface;
using MetricsManager.DAL.Model;
using MetricsManager.DAL.SQLite;
using Microsoft.Extensions.Configuration;
using NLog;

namespace MetricsManager.DAL.Repository
{
    public class CpuMetricsRepository : BaseMetricRepository, ICpuMetricsRepository
    {
        public CpuMetricsRepository(
            IConnectionManager connectionManager,
            ILogger logger,
            IConfiguration configuration)
            : base(
                connectionManager,
                logger, configuration) { }

        public void Create(CpuMetric item)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            connectionString.Execute("INSERT INTO CpuMetrics(AgentId, Value, Time) VALUES (@AgentId, @Value, @Time)",
                new
                {
                    item.AgentId,
                    item.Value,
                    item.Time
                });
        }

        public List<CpuMetric> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            var result = connectionString.Query<CpuMetric>("SELECT Id, AgentId, Value, Time FROM CpuMetrics WHERE Time >= @FromTime AND Time <= @ToTime",
                new
                {
                    FromTime = fromTime,
                    ToTime = toTime
                }).ToList();
            
            return result;
        }

        public List<CpuMetric> GetByPeriodFormAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            var result = connectionString.Query<CpuMetric>("SELECT Id, AgentId, Value, Time FROM CpuMetrics WHERE Time >= @FromTime AND Time <= @ToTime AND AgentId = @AgentId",
                new
                {
                    AgentId = agentId,
                    FromTime = fromTime,
                    ToTime = toTime
                }).ToList();

            return result;
        }
        
        public DateTimeOffset GetMetricsLastDateFormAgent(int agentId)
        {
            var connectionString = ConnectionManager.CreateOpenedConnection();
            var result = connectionString.ExecuteScalar<DateTimeOffset>("SELECT Max(Time) FROM CpuMetrics WHERE AgentId = @AgentId",
                new
                {
                    AgentId = agentId
                });

            return result;
        }
    }
}