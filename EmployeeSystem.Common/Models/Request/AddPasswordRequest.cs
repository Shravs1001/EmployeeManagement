namespace EmployeeManagement.Common.Models.Request
{
    public class AddPasswordRequest
    {
        public int employeeId { get; set; }
        
        public string? Username { get; set; }
        public string? Password { get; set; }
        
    }
}
