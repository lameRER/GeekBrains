using System.Collections.Generic;

namespace MetricsAgent.DAL.Responses
{
    public class MetricsResponse<T>
    {
        public List<T> Metrics { get; set; } = new List<T>();
    }
}