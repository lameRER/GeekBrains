using System;
using MetricsManager.DAL.Interface;

namespace MetricsManager.Request
{
    public class CpuMetricCreateRequest : IMetricsRequest
    {
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}
