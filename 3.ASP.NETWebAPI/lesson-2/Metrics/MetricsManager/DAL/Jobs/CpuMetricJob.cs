using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.Client.Interface;
using MetricsManager.Client.Requests;
using MetricsManager.DAL.Interface;
using MetricsManager.DAL.Model;
using NLog;
using Quartz;

namespace MetricsManager.DAL.Jobs
{
    public class CpuMetricJob : BaseMetricsJob<ICpuMetricsRepository, ICpuMetricsAgentClient>, IJob
    {
        public CpuMetricJob(
            ICpuMetricsRepository repository,
            ILogger logger,
            IAgentsRepository agentsRepository,
            ICpuMetricsAgentClient agentClient,
            IMapper mapper) 
            : base(repository,
                logger,
                agentsRepository,
                agentClient,
                mapper){ }
        
        public Task Execute(IJobExecutionContext context)
        {
            var enabledAgents = AgentsRepository.GetRegistered().Where(item => item.IsEnabled);
            foreach (var agent in enabledAgents)
            {
                 SyncronizeMetrics(agent);
            }
            return Task.CompletedTask;
        }

        private void SyncronizeMetrics(AgentInfo agent)
        {
            var lastTime = Repository.GetMetricsLastDateFormAgent(agent.AgentId).AddSeconds(1);
            var response = AgentClient.GetMetrics(new CpuMetricsClientRequest
            {
                BaseUrl = agent.AgentAddress,
                FromTime = lastTime,
                ToTime = DateTimeOffset.Now
            });

            if (response == null)
                return;

            foreach (var cpuMetric in response.Metrics.Select(clientMetric => Mapper.Map<CpuMetric>(clientMetric)))
            {
                cpuMetric.AgentId = agent.AgentId;
                Repository.Create(cpuMetric);
            }
        }
    }
}