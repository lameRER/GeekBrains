using System.Data.SQLite;

namespace MetricsManager.DAL.SQLite
{
    public interface IConnectionManager
    {
        SQLiteConnection CreateOpenedConnection();
    }
}