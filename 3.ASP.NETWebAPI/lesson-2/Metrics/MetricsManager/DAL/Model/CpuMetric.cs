using System;
using MetricsManager.DAL.Interface;

namespace MetricsManager.DAL.Model
{
    public class CpuMetric : IModelsMetrics
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}