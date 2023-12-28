using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DataAccess.Common.Entities
{
    public class LoginEntity
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("EmpId")]
        public int EmployeeId { get; set; }
        public virtual EmployeeEntity? Employee { get; set; }

        [Column("Username")]
        public string? Username { get; set; }

        [Column("OldPassword")]
        public string? OldPassword { get; set; }

        [Column("NewPassword")]
        public string? NewPassword { get; set; }

        [Column("PasswordHash")]
        public string? PasswordHash { get; set; }
        
    }
}
