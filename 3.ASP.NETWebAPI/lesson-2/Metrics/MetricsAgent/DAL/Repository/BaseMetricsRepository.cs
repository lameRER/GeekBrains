using MetricsAgent.DAL.SQLite;
using Microsoft.Extensions.Configuration;
using NLog;

namespace MetricsAgent.DAL.Repository
{
    public abstract class BaseMetricsRepository
    {
        protected readonly IConfiguration Configuration;

        protected readonly IConnectionManager ConnectionManager;

        protected readonly ILogger Logger;

        protected BaseMetricsRepository(IConfiguration configuration, IConnectionManager connectionManager,
            ILogger logger)
        {
            Configuration = configuration;
            ConnectionManager = connectionManager;
            Logger = logger;
        }
    }
}