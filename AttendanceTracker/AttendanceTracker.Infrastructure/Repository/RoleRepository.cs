using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Infrastructure.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private readonly AppDbcontext dbContext;

        public RoleRepository(AppDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddRole(Role role)
        {
            await dbContext.Role.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role.RoleID;
        }

        public async Task<int> DeleteRole(int id)
        {
            Role role = dbContext.Role.FirstOrDefault(r => r.RoleID == id);
            if (role != null)
            {
                dbContext.Role.Remove(role);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Role>> GetAllRoles()
        {
            return await dbContext.Role.ToListAsync();
        }

        public Task<Role> GetRoleById(int id)
        {
            return dbContext.Role.FirstOrDefaultAsync(r => r.RoleID == id);
        }

        public async Task<int> UpdateRole(Role role)
        {
            dbContext.Role.Update(role);
            return await dbContext.SaveChangesAsync();
        }
    }
}
