using System;
using MetricsAgent.DAL.Interface;

namespace MetricsAgent.Request
{
    public class CpuMetricCreateRequest : IMetricsRequest
    {
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}
