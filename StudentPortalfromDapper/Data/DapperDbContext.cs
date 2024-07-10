using System.Data;
using System.Data.SqlClient;

namespace StudentPortalfromDapper.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = configuration.GetConnectionString("StudentPortal")!;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connection);
    }
}
