using System.Data.SQLite;

namespace MetricsAgent.DAL.SQLite
{
    public interface IConnectionManager
    {
        SQLiteConnection CreateOpenedConnection();
    }
}