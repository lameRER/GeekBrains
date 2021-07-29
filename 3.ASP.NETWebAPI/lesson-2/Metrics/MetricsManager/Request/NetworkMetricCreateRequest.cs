using System;
using MetricsManager.DAL.Interface;

namespace MetricsManager.Request
{
    public class NetworkMetricCreateRequest : IMetricsRequest
    {
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}
