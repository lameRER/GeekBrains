using System;
using MetricsManager.Client.Interface;

namespace MetricsManager.Client.Responses
{
    public class DotNetMetricsDto : IAgentMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}