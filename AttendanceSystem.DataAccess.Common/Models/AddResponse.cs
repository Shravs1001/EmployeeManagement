namespace EmployeeManagement.DataAccess.Common.Models
{
    public class AddResponse
    {
        public bool IsSuccess { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
