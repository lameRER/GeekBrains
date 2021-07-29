using MetricsManager.DAL.Model;

namespace MetricsManager.DAL.Interface
{
    public interface ICpuMetricsRepository : IRepository<CpuMetric>, IMetricsRepository<CpuMetric>
    {
        
    }
}