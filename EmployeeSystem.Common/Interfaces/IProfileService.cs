using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.AspNetCore.Http;

namespace AttendanceSystem.Common.Interfaces
{
    public interface IProfileService
    {

        byte[] GetThumbnailImage(IFormFile profileImage);
        Task<AddResponse> AddProfile(IFormFile profileImage, int empId);
        Task<DeleteProfileResponse> DeleteProfile(DeleteProfileRequest delete);
    }
}
