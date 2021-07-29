using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;

namespace MetricsManager.Client.Interface
{
    public interface IDotNetMetricsAgentClient : IMetricsAgentClient<CpuMetricsClientRequest, AgentMetricsResponse<
        AgentCpuMetricDto>>
    {

    }
}