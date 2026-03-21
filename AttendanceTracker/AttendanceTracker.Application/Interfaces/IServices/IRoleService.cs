using AttendanceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Interfaces.IServices
{
    public interface IRoleService
    {
        Task<int> AddRole(RoleDto roleDto);
        Task<int> UpdateRole(RoleDto roleDto);
        Task<int> DeleteRole(int id);
        Task<RoleDto> GetRoleById(int id);
        Task<IList<RoleDto>> GetAllRoles();
    }
}
