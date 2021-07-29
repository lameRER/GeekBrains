using System;
using System.Collections.Generic;
using MetricsManager.DAL.SQLite;
using Microsoft.Extensions.Configuration;
using NLog;

namespace MetricsManager.DAL.Repository
{
    public abstract class BaseMetricRepository
    {
        private readonly IConfiguration _configuration;

        protected readonly IConnectionManager ConnectionManager;

        private readonly ILogger _logger;

        protected BaseMetricRepository(IConnectionManager connectionManager,
            ILogger logger, IConfiguration configuration)
        {
            ConnectionManager = connectionManager;
            _logger = logger;
            _configuration = configuration;
        }
    }
}