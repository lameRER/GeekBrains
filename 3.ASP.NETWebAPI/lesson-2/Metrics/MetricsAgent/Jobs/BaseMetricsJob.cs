using System.Diagnostics;
using NLog;

namespace MetricsAgent.Jobs
{
    public abstract class BaseMetricsJob<T> where T : class
    {
        protected readonly T Repository;
        protected readonly ILogger Logger;

        protected BaseMetricsJob(T repository, ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }
    }
}