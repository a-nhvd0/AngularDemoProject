using AngularDemo.Server.Models;
using AngularDemo.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularDemo.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly JwtService _jwt;

        public AuthController(JwtService jwt)
        {
            _jwt = jwt;
        }

        [HttpPost]
        [Route("api/auth/")]
        public IActionResult Login([FromBody] Employee employee)
        {
            // TODO: доделать авторизацию через JWT
            // возможно, хранить JWT для возможности их отозвать, вынести проверку в EmployeeDataAccessLayer
            if (employee.Password == "Testpwd")
            {
                var token = _jwt.GenerateToken("TestToken");
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }

}