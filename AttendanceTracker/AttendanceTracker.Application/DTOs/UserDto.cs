using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AttendanceTracker.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
       


        public DateTime CreatedAt { get; set; }
    }
}
