using System;

namespace MetricsAgent.DAL.Interface
{
    public interface IMetricsRequest
    {
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}