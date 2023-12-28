using AttendanceSystem.Common.Interfaces;
using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profService)
        {
            this.profileService = profService;

        }

        [HttpPost("{empId}")]
        public async Task<AddResponse> AddPhoto(int empId,IFormFile profileImage)
        {            
            var response = await profileService.AddProfile(profileImage, empId);
                if (response.IsSuccess)
                {
                    return new AddResponse { IsSuccess = true, Message = "", Id = 11 };
                }
                return response;
                       
        }

        [HttpDelete("{id}")]
        public async Task<DeleteProfileResponse> DeleteProfilePhoto(DeleteProfileRequest deleteProfile)
        {
            return await profileService.DeleteProfile(deleteProfile);
        }
    }
}
