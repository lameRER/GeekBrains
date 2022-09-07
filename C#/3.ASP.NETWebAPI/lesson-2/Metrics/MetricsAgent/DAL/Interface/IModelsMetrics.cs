using System;

namespace MetricsAgent.DAL.Interface
{
    public interface IModelsMetrics
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}