using System;

namespace MetricsManager.Client.Requests
{
    public class AgentInfoRequest
    {
        public Uri AgentAddress { get; set; }
        public bool IsEnabled { get; set; }
    }
}