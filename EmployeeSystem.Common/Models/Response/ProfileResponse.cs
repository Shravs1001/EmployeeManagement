using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Common.Models.Response
{
    public class ProfileResponse
    {
        public bool IsSuccess { get; set; }
        public int FileId { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
