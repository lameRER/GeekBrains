using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : BaseMetricsJob<IHddMetricsRepository>, IJob
    {
        private readonly PerformanceCounter _hddNetCounter;
        
        public HddMetricJob(
            IHddMetricsRepository repository,
            ILogger logger)
            : base(
                repository,
                logger)
        {
            _hddNetCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var hddUsageInPercents = Convert.ToInt32(_hddNetCounter.NextValue());
            Repository.Create(new HddMetric { Time = DateTimeOffset.Now, Value = hddUsageInPercents });
            Logger.Debug("Disk {0}% {1}", hddUsageInPercents, DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}