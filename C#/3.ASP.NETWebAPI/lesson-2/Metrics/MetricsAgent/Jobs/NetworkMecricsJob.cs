using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using NLog;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class NetworkMecricsJob : BaseMetricsJob<INetworkMetricsRepository>, IJob
    {
        private readonly PerformanceCounter _networkCounter;
        
        public NetworkMecricsJob(
            INetworkMetricsRepository repository,
            ILogger logger)
            : base(
                repository,
                logger)
        {
            var netWork = new PerformanceCounterCategory("Network Interface").GetInstanceNames();
            _networkCounter = new PerformanceCounter("Network Interface", "bytes sent/sec", netWork[0]);
        }

        public Task Execute(IJobExecutionContext context)
        {
            var netWorkUsageInPercents = Convert.ToInt32(_networkCounter.NextValue());
            Repository.Create(new NetworkMetric { Time = DateTimeOffset.Now, Value = netWorkUsageInPercents });
            Logger.Debug("NET CLR Memory size {0}Mb {1}", netWorkUsageInPercents, DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}