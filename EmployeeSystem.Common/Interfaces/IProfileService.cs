using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.DataAccess.Common.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Common.Interfaces
{
    public interface IProfileService
    {

        byte[] GetThumbnailImage(IFormFile profileImage);
        Task<AddResponse> AddProfile(IFormFile profileImage, int empId);
        Task<DeleteProfileResponse> DeleteProfile(DeleteProfileRequest delete);
    }
}
