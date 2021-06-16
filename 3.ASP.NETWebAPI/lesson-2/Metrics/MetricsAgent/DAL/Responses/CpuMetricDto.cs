using System;
using MetricsAgent.DAL.Interface;

namespace MetricsAgent.DAL.Responses
{
    public class CpuMetricDto : IMetricsResponses
    {
        public int Id { get; set; }
        
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}