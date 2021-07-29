using System;

namespace MetricsManager.DAL.Interface
{
    public interface IMetricsRequest
    {
        public int Value { get; set; }
        
        public DateTimeOffset Time { get; set; }
    }
}