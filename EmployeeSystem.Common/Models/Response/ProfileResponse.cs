namespace EmployeeManagement.Common.Models.Response
{
    public class ProfileResponse
    {
        public bool IsSuccess { get; set; }
        public int FileId { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
