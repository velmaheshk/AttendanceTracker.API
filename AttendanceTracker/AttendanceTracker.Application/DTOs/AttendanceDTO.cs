using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.DTOs
{
    public class AttendanceDTO
    {
        public int AttendanceID { get; set; }
        public int UserID { get; set; }
        public DateOnly Date { get; set; }

        public string Status { get; set; }
        public string Course { get; set; }

        public int RecordedBy { get; set; }
    }
}
