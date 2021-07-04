using MetricsAgent.DAL.SQLite;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public abstract class BaseMetricsRepository
    {
        protected readonly IConfiguration Configuration;

        protected readonly IConnectionManager ConnectionManager;

        protected BaseMetricsRepository(IConfiguration configuration, IConnectionManager connectionManager)
        {
            Configuration = configuration;
            ConnectionManager = connectionManager;
        }
    }
}