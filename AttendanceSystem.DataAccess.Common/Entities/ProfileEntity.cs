using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DataAccess.Common.Entities
{
    public class ProfileEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int EmployeeId { get; set; }
        public virtual EmployeeEntity? Employee { get; set; }

        [Column("File_thumbnail")]
        public byte[]? FileThumbnail { get; set; }

        
    }
}
