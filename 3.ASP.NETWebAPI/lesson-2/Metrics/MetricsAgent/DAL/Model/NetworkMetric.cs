using System;
using MetricsAgent.DAL.Interface;

namespace MetricsAgent.DAL.Model
{
    public class NetworkMetric : IModelsMetrics
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}