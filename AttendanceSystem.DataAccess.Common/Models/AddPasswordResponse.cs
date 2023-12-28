namespace EmployeeManagement.DataAccess.Common.Models
{
    public class AddPasswordResponse
    {
        public bool IsSuccess { get; set; }
        
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
