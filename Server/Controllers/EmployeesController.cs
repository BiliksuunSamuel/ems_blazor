using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ems.Server.services;
using ems.Server.model;
namespace ems.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]

   
    public class EmployeesController : ControllerBase
    {
        EmployeeServices services = new EmployeeServices();
        private IConfiguration configuration;
        public EmployeesController(IConfiguration _configuraiton)
        {
            configuration = _configuraiton ;
        }


        /// <summary>
        /// GET ALL EM0PLOYEES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
                return (services.GetEmployees(configuration));
            
        }

        [HttpPost("employee/add")]
        public JsonResult AddEmployee(EmployeeModel model)
        {
            try
            {
                services.AddEmployee(configuration, model);
                return new JsonResult("Employee Added Successfully");
            }
            catch (Exception ex)
            {

               return HandleError(ex);
            }
        }


        /// <summary>
        /// HANDLE ERROR RESPONSE
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private JsonResult HandleError(Exception ex)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return new JsonResult(ex.Message);
        }
    }
}
