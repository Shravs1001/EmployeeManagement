using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Models;

namespace AttendanceSystem.DataAccess.Common.Interfaces
{
    public interface ILoginDataAccessor
    {
        Task<AddPasswordResponse> CreatePassword(LoginEntity login);
        Task<UpdatePasswordResponse> UpdatePassword(LoginEntity entity);
        Task<LoginEntity> GetUser(int userId);

    }
}
