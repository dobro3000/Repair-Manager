using System.Configuration;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    /// <summary>
    /// Содержит методы для подключения к БД.
    /// </summary>
    public class BaseDao
    {
        protected static SqlConnection GetConnection() { return new SqlConnection(GetConnectionString()); }

        private static string GetConnectionString() { return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString; }
    }

}
