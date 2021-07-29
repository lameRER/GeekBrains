using System.Collections.Generic;

namespace MetricsManager.DAL.Interface
{
    public interface IAgentsRepository : IRepository<AgentInfo>
    {
        IList<AgentInfo> GetRegistered();

        void EnableById(int agentId);

        void DisableById(int agentId);
    }
}