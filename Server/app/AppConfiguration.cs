using Microsoft.Data.SqlClient;

namespace ems.Server.app
{
    public abstract class AppConfiguration
    {
       
        public SqlConnection Connection(IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("default");
            return new SqlConnection(connString);
        }
    }
}
