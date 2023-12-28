namespace EmployeeManagement.Common.Models.Response
{
    public class UpdateResponse
    {
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
