using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }
        public int UserID { get; set; } 
        public User user { get; set; }

        public DateOnly Date {  get; set; }

        public string Status { get; set; }
        public string Course { get; set; }

        public int RecordedBy { get; set; }
        public User Users { get; set; }


        
    }
}
