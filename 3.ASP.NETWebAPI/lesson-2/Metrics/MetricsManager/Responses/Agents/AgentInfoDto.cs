using System;

namespace MetricsManager.Responses.Agents
{
    public class AgentInfoDto
    {
        public int AgentId { get; set; }
        public Uri AgentAddress { get; set; }
        public bool IsEnabled { get; set; }
    }
}