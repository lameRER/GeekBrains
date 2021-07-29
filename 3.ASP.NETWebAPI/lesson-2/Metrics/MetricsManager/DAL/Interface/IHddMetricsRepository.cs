using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface IHddMetricsRepository : IRepository<HddMetric>, IMetricsRepository<HddMetric>
    {
        
    }
}