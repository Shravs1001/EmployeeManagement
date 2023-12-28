using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.DataAccess.Common.Models
{
    public class AddPasswordResponse
    {
        public bool IsSuccess { get; set; }
        
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
