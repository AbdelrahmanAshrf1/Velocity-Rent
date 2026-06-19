using System.Configuration;
using System.Data.SqlClient;

namespace Velocity_Rent_DAL
{
    public class DbConnectionFactory
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["VelocityRentDB"].ConnectionString;
        public static SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
