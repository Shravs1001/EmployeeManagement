
using EmployeeManagement.Common.Interfaces;
using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;


        public EmployeeController(IEmployeeService empService)
        {
            employeeService = empService;
        }

        [HttpGet]
        public List<EmployeesResponse> GetEmployeeList()
        {
            return employeeService.GetEmployees();
        }

        [HttpGet("emp/{id}")]
        public IActionResult GetbyId(int id)
        {
            var employeeDetails = employeeService.GetEmployeeById(id);
            if (employeeDetails != null)
            {
                return Ok(employeeDetails);
            }
            return BadRequest();
        }

        [HttpPost]
        public Task<CreateResponse> AddEmployee(AddEmployeeRequest employee)
        {
            return employeeService.CreateEmployee(employee);
        }

        [HttpPut("emp/{id}")]
        public Task<UpdateResponse> UpdateEmployee(UpdateEmployeeRequest update)
        {
            return employeeService.UpdateEmployee(update);
        }

        [HttpDelete("emp/{id}")]
        public Task<DeleteResponse> DeleteEmployees(DeleteEmployeeRequest deleteEmployee)
        {
            return employeeService.RemoveEmployee(deleteEmployee);
        }


    }
}
