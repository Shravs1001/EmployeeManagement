using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.Common.Models.Response;
using AttendanceSystem.DataAccess.Common.Entities;

namespace AttendanceSystem.Common.Interfaces
{
    public interface ILoginService
    {
        Task<CreatePasswordResponse> AddPassword(int employeeId, string username, string password);
        Task<UpdateResponse> ChangePassword(ChangePasswordRequest request);
        string HashPassword(string password);
    }
}
