using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Models;


namespace EmployeeManagement.DataAccess.Common.Interfaces
{
    public interface IProfileDataAccessor
    {
        Task<ProfileEntity> GetProfile(int empId);
        Task<AddResponse> UploadProfile(ProfileEntity entity);
        Task<DeleteProfileResponse> RemoveProfile(ProfileEntity profile);
        
    }
}

