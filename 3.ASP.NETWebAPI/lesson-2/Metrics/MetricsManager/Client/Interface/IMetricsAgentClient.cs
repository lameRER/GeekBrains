namespace MetricsManager.Client.Interface
{
    public interface IMetricsAgentClient<in TRequest, out TResponse>
    {
        TResponse GetMetrics(TRequest request);
    }
}