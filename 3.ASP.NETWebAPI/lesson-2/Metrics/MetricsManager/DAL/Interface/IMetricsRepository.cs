using System;
using System.Collections.Generic;
using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface IMetricsRepository<T>
    {
        List<T> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime);

        List<T> GetByPeriodFormAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime);

        DateTimeOffset GetMetricsLastDateFormAgent(int agentId);
    }
}