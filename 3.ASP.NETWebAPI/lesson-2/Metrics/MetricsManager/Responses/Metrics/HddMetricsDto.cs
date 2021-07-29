using System;
using MetricsManager.Responses.Metrics.Interface;

namespace MetricsManager.Responses.Metrics
{
    public class HddMetricsDto : IMetricsDto
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}