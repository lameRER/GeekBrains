using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MetricsManager.DAL.Interface;
using MetricsManager.DAL.SQLite;
using NLog;

namespace MetricsManager.DAL.Repository
{
    public class AgentsRepository : IAgentsRepository
    {
        private readonly IConnectionManager _connectionManager;
        private readonly ILogger _logger;

        public AgentsRepository(
            IConnectionManager connectionManager,
            ILogger logger)
        {
            _connectionManager = connectionManager;
            _logger = logger;
        }

        public void Create(AgentInfo item)
        {
            var connectionString = _connectionManager.CreateOpenedConnection();
            connectionString.Execute("INSERT INTO  Agents (AgentAddress, IsEnabled) VALUES (@AgentAddress, @IsEnabled)",
                new
                {
                    item.AgentAddress,
                    item.IsEnabled
                });
        }

        private void SetStateById(int agentId, bool state)
        {
            var connectionString = _connectionManager.CreateOpenedConnection();
            connectionString.Execute("UPDATE Agents SET IsEnabled = @state WHERE AgentId = @agentId",
                new
                {
                    agentId,
                    state
                });
        }

        public IList<AgentInfo> GetRegistered()
        {
            var connectionString = _connectionManager.CreateOpenedConnection();
            var result = connectionString.Query<AgentInfo>("SELECT AgentId, AgentAddress, IsEnabled FROM Agents").ToList();
            return result;
        }

        public void EnableById(int agentId)
        {
            SetStateById(agentId, true);
        }
        
        public void DisableById(int agentId)
        {
            SetStateById(agentId, false);
        }
    }
}