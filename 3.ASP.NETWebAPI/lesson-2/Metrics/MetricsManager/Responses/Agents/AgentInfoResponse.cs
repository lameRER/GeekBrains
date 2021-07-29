using System.Collections.Generic;

namespace MetricsManager.Responses.Agents
{
    public class AgentInfoResponse
    {
        public List<AgentInfoDto> Agengs { get; set; } = new();
    }
}