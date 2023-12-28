
namespace EmployeeManagement.DataAccess.Common.Interfaces
{
    public interface ILoginDataAccessor
    {
        Task<AddPasswordResponse> CreatePassword(LoginEntity login);
        Task<UpdatePasswordResponse> UpdatePassword(LoginEntity entity);
        Task<LoginEntity> GetUser(int userId);

    }
}
