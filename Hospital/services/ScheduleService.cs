using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.services
{
    public class ScheduleService:IScheduleService
    {
        private readonly ApplictionContext Context;
        public ScheduleService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }

        public List<Schedule> GetSchedules()
        {
            List<Schedule> Schedules = Context.schedules.Include(a=>a.doctor).ToList();
            return Schedules;
        }
        public Schedule GetScheduleById(int id)
        {

            return Context?.schedules?.Include(_=>_.doctor).FirstOrDefault(_=>_.Id==id)!;
        }
        public SelectList GetDayOfWeek()
        {
            var daysOfWeek = Enum.GetValues(typeof(DayOfWeek))
                                 .Cast<DayOfWeek>()
                                 .Select(d => new { Id = (int)d, Name = d.ToString() })
                                 .ToList();

            return new SelectList(daysOfWeek, "Id", "Name");
        }

        public void InsertSchedule(Schedule Schedule)
        {

            Context.Add(Schedule);
            Context.SaveChanges();
        }
        public void EditeSchedule(Schedule Schedule)
        {

            Context.Update(Schedule);
            Context.SaveChanges();
        }
        public void DeleteSchedule(Schedule Schedule)
        {
            var schedule = GetScheduleById(Schedule.Id);

            if (schedule != null)
            {
                schedule.IsActive = !schedule.IsActive;
                Context.SaveChanges();

            }
           
        }

    }
}
