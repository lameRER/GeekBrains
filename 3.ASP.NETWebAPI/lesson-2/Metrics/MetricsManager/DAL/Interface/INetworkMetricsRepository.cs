using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>, IMetricsRepository<NetworkMetric>
    {
        
    }
}