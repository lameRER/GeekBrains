using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : BaseMetricsJob<IDotNetMetricsRepository>, IJob
    {
        private readonly PerformanceCounter _dotNetCounter;
        
        public DotNetMetricJob(IDotNetMetricsRepository repository, ILogger logger) : base(repository, logger)
        {
            _dotNetCounter = new PerformanceCounter(".NET CLR Memory", "gen 1 heap size", "_Global_");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            var dotNetUsageInPercents = Convert.ToInt32(_dotNetCounter.NextValue())/1024/1024;
            Repository.Create(new DotNetMetric { Time = DateTimeOffset.Now, Value = dotNetUsageInPercents });
            Logger.Debug("NET CLR Memory size {0}Mb {1}", dotNetUsageInPercents, DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}