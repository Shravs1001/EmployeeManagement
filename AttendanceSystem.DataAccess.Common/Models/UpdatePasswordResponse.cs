namespace EmployeeManagement.Common.Models.Request
{
    public class UpdatePasswordResponse
    {
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string? Message { get; set; }
        public string? HashPassword { get; set; }
    }
}
