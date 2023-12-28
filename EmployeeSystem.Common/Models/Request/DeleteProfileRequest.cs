namespace EmployeeManagement.Common.Models.Request
{
    public class DeleteProfileRequest
    {
        public int Id { get; set; }
        public byte[]? FileId { get; set; }
    }
}
