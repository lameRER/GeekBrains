using System;
using System.Collections.Generic;

namespace MetricsManager
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
    }
}