using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace MetricsManager.DAL.Jobs
{
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider _provider;

        public SingletonJobFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _provider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job) { }
    }
}