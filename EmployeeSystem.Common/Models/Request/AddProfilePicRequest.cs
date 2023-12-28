using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Common.Models.Request
{
    public class AddProfilePicRequest
    {
        public int Id { get; set; }
       
        public IFormFile? FileThumbnail { get; set;}
       
    }
}
