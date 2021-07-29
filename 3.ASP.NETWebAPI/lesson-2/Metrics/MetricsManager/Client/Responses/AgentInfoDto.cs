using System;

namespace MetricsManager.Client.Responses
{
    public class AgentInfoDto
    {
        public int AgentId { get; set; }
        public Uri AgentAddress { get; set; }
        public bool IsEnabled { get; set; }
    }
}