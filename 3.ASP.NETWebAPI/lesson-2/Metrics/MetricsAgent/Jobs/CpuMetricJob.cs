using System;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interface;
using Quartz;
using System.Diagnostics;
using MetricsAgent.DAL.Model;
using NLog;

namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : BaseMetricsJob<ICpuMetricsRepository>, IJob
    {
        private readonly PerformanceCounter _cpuCounter;
        
        public CpuMetricJob(
            ICpuMetricsRepository repository,
            ILogger logger) 
            : base(
                repository,
                logger)
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());
            Repository.Create(new CpuMetric { Time = DateTimeOffset.Now, Value = cpuUsageInPercents });
            Logger.Debug("Processor {0}% {1}", cpuUsageInPercents, DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}