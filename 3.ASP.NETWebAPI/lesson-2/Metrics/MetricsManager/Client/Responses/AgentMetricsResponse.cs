using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public abstract class AgentMetricsResponse<T>
    {
        public List<T> Metrics { get; set; } = new();
    }
}