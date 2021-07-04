using NLog;

namespace MetricsLogging
{
    public static class Logging
    {
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();
    }
}