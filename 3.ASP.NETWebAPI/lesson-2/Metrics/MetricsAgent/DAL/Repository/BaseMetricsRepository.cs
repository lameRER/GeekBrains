using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL.Repository
{
    public abstract class BaseMetricsRepository
    {
        protected readonly IConfiguration Configuration;

        protected BaseMetricsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}