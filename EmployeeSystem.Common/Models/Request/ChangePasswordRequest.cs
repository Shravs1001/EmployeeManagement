namespace EmployeeManagement.Common.Models.Request
{
    public class ChangePasswordRequest
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
       
    }
}
