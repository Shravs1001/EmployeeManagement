using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Common.Interfaces;
using EmployeeManagement.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeManagement.DataAccess.DataAccessors
{
    public class ProfileDataAccessor : IProfileDataAccessor
    {
        private readonly DataDbContext profileContext;      

        public ProfileDataAccessor(DataDbContext dataDbContext)
        {
            profileContext = dataDbContext;    
        }

        public async Task<ProfileEntity> GetProfile(int empId)
        {            
            return await profileContext.Profile.FirstOrDefaultAsync(x => x.Id == empId);
        }

        public async Task<AddResponse> UploadProfile(ProfileEntity entity)
        {
            var addResponse = new AddResponse();
            await profileContext.AddAsync(entity);
            try
            {
                await profileContext.SaveChangesAsync();
                addResponse.IsSuccess = true;
                addResponse.Id = entity.Id;
            }
            catch (DbUpdateConcurrencyException)
            {
                return new AddResponse()
                {
                    IsSuccess = false,
                    Message = "Error uploading profile",
                    ErrorCode = 500                   
                };
                
            }
            return addResponse;

        }
      

        public async Task<DeleteProfileResponse> RemoveProfile(ProfileEntity profile)
        {
            var response = new DeleteProfileResponse();
            profileContext.Remove(profile);
            try
            {
                await profileContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.ErrorCode = (int)HttpStatusCode.OK;
            }
            catch (DbUpdateConcurrencyException)
            {
                response.IsSuccess = false;
                response.Message = "Error occured while deleting the profile";
                response.ErrorCode = 500;
            }
            return response;
        }

        

    }
}
