using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface IRamMetricsRepository : IRepository<RamMetric>, IMetricsRepository<RamMetric>
    {
        
    }
}