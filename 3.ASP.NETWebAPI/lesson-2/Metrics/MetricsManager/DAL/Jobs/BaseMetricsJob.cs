using AutoMapper;
using MetricsManager.Client.Interface;
using MetricsManager.DAL.Interface;
using NLog;

namespace MetricsManager.DAL.Jobs
{
    public abstract class BaseMetricsJob<TRepository, TMetricsAgentClient> 
    {
        protected readonly TRepository Repository;
        protected readonly IAgentsRepository AgentsRepository;
        protected readonly ILogger Logger;
        protected readonly TMetricsAgentClient AgentClient;
        protected readonly IMapper Mapper;

        protected BaseMetricsJob(TRepository repository, ILogger logger, IAgentsRepository agentsRepository, TMetricsAgentClient agentClient, IMapper mapper)
        {
            Repository = repository;
            Logger = logger;
            AgentsRepository = agentsRepository;
            AgentClient = agentClient;
            Mapper = mapper;
        }
    }
}