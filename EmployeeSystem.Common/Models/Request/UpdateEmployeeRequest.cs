namespace AttendanceSystem.Common.Models.Request
{
    public class UpdateEmployeeRequest
    {
        public int EmployeeID { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Fullname { get; set; }

        public string? Gender { get; set; }

        public string? Role { get; set; }

        public string? Designation { get; set; }

        public string? Email { get; set;}
    }
}
