using AttendanceTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttendanceTracker.Domain
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }


        public int UserID { get; set; }//Foreignkey
        public User user { get; set; }
      
        public string FullName { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }  
        public int Year { get; set; }


    }
}
