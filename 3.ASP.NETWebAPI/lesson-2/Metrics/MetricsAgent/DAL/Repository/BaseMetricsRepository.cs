using MetricsAgent.DAL.SQLite;
using Microsoft.Extensions.Configuration;
using NLog;

namespace MetricsAgent.DAL.Repository
{
    public abstract class BaseMetricsRepository
    {
        private readonly IConfiguration _configuration;

        protected readonly IConnectionManager ConnectionManager;

        private readonly ILogger _logger;

        protected BaseMetricsRepository(IConfiguration configuration, IConnectionManager connectionManager,
            ILogger logger)
        {
            _configuration = configuration;
            ConnectionManager = connectionManager;
            _logger = logger;
        }
    }
}