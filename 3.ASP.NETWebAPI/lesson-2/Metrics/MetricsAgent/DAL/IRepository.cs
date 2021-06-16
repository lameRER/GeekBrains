using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.DAL.Model;
using Microsoft.Extensions.Configuration;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetByPeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
        void Create(T item);
    }
}