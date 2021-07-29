using System;

namespace MetricsManager.DAL.Interface
{
    public interface IMetricsResponses
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}