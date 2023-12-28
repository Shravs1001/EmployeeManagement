using EmployeeManagement.Common.Interfaces;
using EmployeeManagement.Common.Models.Request;
using EmployeeManagement.DataAccess.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
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
