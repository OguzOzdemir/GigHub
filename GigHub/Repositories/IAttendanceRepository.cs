using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}
