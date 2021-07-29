using System;

namespace MetricsManager.Responses.Metrics.Interface
{
    public interface IMetricsDto
    {
        int Id { get; set; }
        int AgentId { get; set; }
        int Value { get; set; }
        DateTimeOffset Time { get; set; }
    }
}