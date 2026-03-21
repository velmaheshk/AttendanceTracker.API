using AttendanceTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Domain.Interfaces.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IList<Attendance>> GetAll();
        Task<Attendance> GetById(int id);
        Task<int> Add(Attendance attendance);
        Task<int> Update(Attendance attendance);
        Task<int> Delete(int id);
    }
}
