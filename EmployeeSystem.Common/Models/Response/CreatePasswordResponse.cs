namespace EmployeeManagement.Common.Models.Response
{
    public class CreatePasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string? HashPassword { get; set; }
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
