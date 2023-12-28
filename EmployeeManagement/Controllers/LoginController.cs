using AttendanceSystem.Common.Interfaces;
using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.API.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet("hashpassword/{id}")]
        public IActionResult HashPassword(string password)
        {
            string hashedPassword = loginService.HashPassword(password);
            return Ok(hashedPassword);
        }

        [HttpPost("password/{employeeId}")]
        public Task<CreatePasswordResponse> CreatePassword(int employeeId, string username, string password)
        {
            return loginService.AddPassword(employeeId, username, password);
        }
            
        [HttpPut("reset/{id}")]
        public Task<UpdateResponse> UpdatePassword(ChangePasswordRequest changePassword)
        {
            return loginService.ChangePassword(changePassword);
        }

        
    }
}
