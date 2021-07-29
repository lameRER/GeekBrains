using System;

namespace MetricsManager.DAL.Model
{
    public class AgentInfo
    {
        public int AgentId { get; set; }
        public Uri AgentAddress { get; set; }
        public bool IsEnabled { get; set; }
    }
}