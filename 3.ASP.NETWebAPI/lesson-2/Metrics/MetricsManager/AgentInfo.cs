using System;
using System.Collections.Generic;
using MetricsLogging;

namespace MetricsManager
{
    public class AgentInfo
    {
        public int AgentId { get; set; }
        public Uri AgentAddress { get; set; }

        public AgentInfo(int agentId, Uri agentAddress)
        {
            try
            {
                AgentId = agentId;
                AgentAddress = agentAddress;
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
            }
        }
    }
}