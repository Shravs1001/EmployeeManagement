using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.Common.Models.Response;

namespace EmployeeManagement.Common.Interfaces
{
    public interface ILoginService
    {
        Task<CreatePasswordResponse> AddPassword(int employeeId, string username, string password);
        Task<UpdateResponse> ChangePassword(ChangePasswordRequest request);
        string HashPassword(string password);
    }
}
