using AttendanceTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Domain.Interfaces.IRepository
{
    public interface IRoleRepository
    {
        Task<IList<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<int> AddRole(Role role);
        Task<int> UpdateRole(Role role);
        Task<int> DeleteRole(int id);
    }
}
