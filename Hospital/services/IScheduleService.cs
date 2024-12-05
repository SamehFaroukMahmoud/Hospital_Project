using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IScheduleService
    {
        List<Schedule> GetSchedules();
        Schedule GetScheduleById(int id);
        void InsertSchedule(Schedule Schedule);
        void EditeSchedule(Schedule Schedule);
        void DeleteSchedule(Schedule Schedule);
        SelectList GetDayOfWeek();
    }
}
