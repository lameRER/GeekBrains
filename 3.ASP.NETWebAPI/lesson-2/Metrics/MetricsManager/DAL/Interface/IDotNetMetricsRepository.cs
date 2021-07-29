using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>, IMetricsRepository<DotNetMetric>
    {
        
    }
}