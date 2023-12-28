using AttendanceSystem.Common.Interfaces;
using AttendanceSystem.Common.Models.Request;
using AttendanceSystem.DataAccess.Common.Entities;
using AttendanceSystem.DataAccess.Common.Interfaces;
using AttendanceSystem.DataAccess.Common.Models;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using Image = SixLabors.ImageSharp.Image;
using Size = SixLabors.ImageSharp.Size;

namespace AttendanceSystem.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileDataAccessor profileDataAccessor;
      
        public ProfileService(IProfileDataAccessor dataAccesor) 
        { 
            this.profileDataAccessor = dataAccesor;
        }

        public byte[] GetThumbnailImage(IFormFile profileImage)
        {
            try
            {
                using (Stream stream = profileImage.OpenReadStream())
                using (var originalImage = Image.Load(stream))
                {
                    // Resize the image to create a thumbnail
                    originalImage.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(32, 32), // Adjust the size as needed
                        Mode = ResizeMode.Max
                    }));

                    // Convert the thumbnail to a byte array
                    using (MemoryStream thumbnailStream = new MemoryStream())
                    {
                        originalImage.Save(thumbnailStream, new JpegEncoder());
                        return thumbnailStream.ToArray();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<AddResponse> AddProfile(IFormFile profileImage, int empId)
        {
            var addResponse = new AddResponse();
            try
            {
                var result = await profileDataAccessor.GetProfile(empId);

                if (profileImage != null && profileImage.Length > 0 && result != null)
                {
                    byte[] thumbnail = GetThumbnailImage(profileImage);
                    result.FileThumbnail = thumbnail;
                    result.Id = empId;

                    var updateResponse = await profileDataAccessor.UploadProfile(result);
                    addResponse.IsSuccess = updateResponse.IsSuccess;
                    addResponse.ErrorCode = updateResponse.ErrorCode;
                    addResponse.Message = updateResponse.Message;
                    addResponse.Id = empId;
                }
                else
                {
                    throw new Exception("No profile image found or profile not found");
                }
            }
            catch (Exception ex)
            {
                addResponse.IsSuccess = false;
                addResponse.ErrorCode = 500;
                addResponse.Message = $"Error adding profile: {ex.Message}";
                addResponse.Id = empId;
            }

            return addResponse;
        }

        public async Task<DeleteProfileResponse> DeleteProfile(DeleteProfileRequest delete)
        {
            var profile = new ProfileEntity
            {
                EmployeeId = delete.Id,
                FileThumbnail = delete.FileId
            };
            var delResponse = await profileDataAccessor.RemoveProfile(profile);
            DeleteProfileResponse response = new DeleteProfileResponse
            {
                IsSuccess = delResponse.IsSuccess,
                ErrorCode = delResponse.ErrorCode,
                Message = delResponse.Message,
            };
            return response;
        }





    }
}
