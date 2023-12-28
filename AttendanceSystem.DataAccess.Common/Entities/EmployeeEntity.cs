using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.DataAccess.Common.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key]
        [Column("EmpId")]
        public int EmployeeId { get; set; }

        [Column("Firstname")]
        public string? Firstname { get; set; }

        [Column("Lastname")]
        public string? Lastname { get; set; }

        [Column("Fullname")]
        public string? Fullname { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("Designation")]
        public string? Designation { get; set; }

        [Column("Role")]
        public string? Role { get; set; }
      
        [Column("Email")]
        public string? Email { get; set;}

    }
}   
