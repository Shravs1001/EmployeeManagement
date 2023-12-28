namespace EmployeeManagement.Common.Models.Response
{
    public class CreateResponse
    {
        public bool IsSuccess { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
