using System;
using System.Collections.Generic;
using System;

namespace MetricsManager
{
    public class AgentInfo
    {
        public int AgentId { get; set; }
        
        public Uri AgentAddress { get; set; }

        public bool IsEnabled { get; set; }
    }
}