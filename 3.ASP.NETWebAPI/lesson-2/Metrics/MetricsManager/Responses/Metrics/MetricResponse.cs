using System.Collections.Generic;

namespace MetricsManager.Responses.Metrics
{
    public class MetricResponse<T>
    {
        public List<T> Metrics { get; set; } = new List<T>();
    }
}