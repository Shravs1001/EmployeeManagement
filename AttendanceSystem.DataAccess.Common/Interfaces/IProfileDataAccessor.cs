using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.AspNetCore.Http;

namespace AttendanceSystem.DataAccess.Common.Interfaces
{
    public interface IProfileDataAccessor
    {
        Task<ProfileEntity> GetProfile(int empId);
        Task<AddResponse> UploadProfile(ProfileEntity entity);
        Task<DeleteProfileResponse> RemoveProfile(ProfileEntity profile);
        
    }
}

