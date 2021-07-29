using System;
using System.Security.Policy;

namespace MetricsManager.Client.Requests
{
    public class CpuMetricsClientRequest
    {
        public Uri BaseUrl { get; set; }
        
        public DateTimeOffset FromTime { get; set; }
        
        public DateTimeOffset ToTime { get; set; }
    }
}