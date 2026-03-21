using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Infrastructure.Repository
{
    public class AttendanceRepository:IAttendanceRepository
    {
        private readonly AppDbcontext dbContext;

        public AttendanceRepository(AppDbcontext dbContext)
        {             this.dbContext = dbContext;
        }
        public async Task<int> Add(Attendance attendance)
        {
            await dbContext.Attendance.AddAsync(attendance);
            await dbContext.SaveChangesAsync();
            return attendance.AttendanceID;
        }

        public async Task<int> Delete(int id)
        {
            Attendance attendance = dbContext.Attendance.FirstOrDefault(r => r.AttendanceID == id);
            if (attendance != null)
            {
                dbContext.Attendance.Remove(attendance);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Attendance>> GetAll()
        {
            return await dbContext.Attendance.ToListAsync();
        }

        public Task<Attendance> GetById(int attendanceID)
        {
            return dbContext.Attendance.FirstOrDefaultAsync(r => r.AttendanceID == attendanceID);
        }

        public async Task<int> Update(Attendance attendance)
        {
            dbContext.Attendance.Update(attendance);
            return await dbContext.SaveChangesAsync();
        }
    }
}
