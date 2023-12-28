using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Models;

namespace EmployeeManagement.DataAccess.Common.Interfaces
{
    public interface ILoginDataAccessor
    {
        Task<AddPasswordResponse> CreatePassword(LoginEntity login);
        Task<UpdatePasswordResponse> UpdatePassword(LoginEntity entity);
        Task<LoginEntity> GetUser(int userId);

    }
}
