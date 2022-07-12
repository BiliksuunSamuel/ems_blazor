using ems.Server.app;
using ems.Server.model;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using ems.Server.Utilities;

namespace ems.Server.services
{
    public class EmployeeServices:AppConfiguration
    {
        //AppConfiguration appConfig = new AppConfiguration();
        Services services = new Services();

        public List<EmployeeModel> GetEmployees(IConfiguration configuration)
        {
            try
            {
                string cmd = "select * from Employees";
                var data = services.FetchData<EmployeeModel, DynamicParameters>(cmd,new DynamicParameters(),Connection(configuration));
                return data;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<EmployeeModel>();
            }
        }

        public void AddEmployee(IConfiguration configuration,EmployeeModel model)
        {
            try
            {
                model.Id = Utils.generateOTP();
                if (model.Name != null)
                {
                    model.Name = model.Name.ToUpper();
                }
                using (IDbConnection con = Connection(configuration))
                {
                    string command = "insert into Employees(Id,Name,Phone,Email,Address,Role,Status,ProfileImage,Salary) values(@Id,@Name,@Phone,@Email,@Address,@Role,@Status,@ProfileImage,@Salary)";
                    con.Execute(command, model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
