using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.Common.Models.Response;

namespace AttendanceSystem.Common.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeesResponse> GetEmployees();
        EmployeesResponse GetEmployeeById(int employeeId);
        Task<CreateResponse> CreateEmployee(AddEmployeeRequest model);
        Task<UpdateResponse> UpdateEmployee(UpdateEmployeeRequest update);
        Task<DeleteResponse> RemoveEmployee(DeleteEmployeeRequest remove);
    }
}
