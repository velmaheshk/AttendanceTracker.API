using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbcontext _dbcontext;

        public UserRepository(AppDbcontext appDbcontext)
        {
            this._dbcontext = appDbcontext;
        }

        public async Task<IList<User>> GetUser()
        {
            return await this._dbcontext.User.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return this._dbcontext.User.SingleOrDefault(m => m.Id == id);
        }
        public async Task<int> AddUser(User user)
        {
            await _dbcontext.User.AddAsync(user);
            await this._dbcontext.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> UpdateUser(User user)
        {
            _dbcontext.User.Update(user);
            return await this._dbcontext.SaveChangesAsync();
        }
        public async Task<int> DeleteUser(int id)
        {
            User user = _dbcontext.User.FirstOrDefault(m=> m.Id == id);
            if (user == null)
            {
                return 0;
            }
            _dbcontext.User.Remove(user);
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
