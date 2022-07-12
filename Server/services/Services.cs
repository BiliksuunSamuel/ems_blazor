using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
namespace ems.Server.services
{
    public class Services
    {

        public List<T>FetchData<T,U>(string cmd,U parameters,SqlConnection connection)
        {
            using (IDbConnection con=connection)
            {
                List<T> data = con.Query<T>(cmd, parameters).ToList();
                return data;
            }
        }
    }
}
