using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;

namespace MetricsManager.Client.Interface
{
    public interface ICpuMetricsAgentClient : IMetricsAgentClient<CpuMetricsClientRequest, AgentMetricsResponse<AgentCpuMetricDto>>
    {
        
    }
}