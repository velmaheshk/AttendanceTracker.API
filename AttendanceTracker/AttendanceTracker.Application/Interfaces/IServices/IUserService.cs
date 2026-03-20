using AttendanceTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IList<User>> GetUser();
        Task<User> GetById(int id);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
    }
}
