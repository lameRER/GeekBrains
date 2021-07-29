using System;

namespace MetricsManager.Client.Interface
{
    public interface IAgentMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}