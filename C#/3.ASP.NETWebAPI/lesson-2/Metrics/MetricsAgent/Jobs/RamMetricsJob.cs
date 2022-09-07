using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class RamMetricsJob : BaseMetricsJob<IRamMetricsRepository>, IJob
    {
        private readonly PerformanceCounter _ramCounter;
        
        public RamMetricsJob(IRamMetricsRepository repository, ILogger logger) : base(repository, logger)
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());
            Repository.Create(new RamMetric { Time = DateTimeOffset.Now, Value = ramUsageInPercents });
            Logger.Debug("Ram {0}Mb {1}", ramUsageInPercents, DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}