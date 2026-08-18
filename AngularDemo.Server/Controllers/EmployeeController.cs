using AngularDemo.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularDemo.Server.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [Authorize]
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Employee employee)
        {
            return objemployee.AddEmployee(employee);
        }
    }

}
