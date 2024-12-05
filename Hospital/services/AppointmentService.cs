using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Hospital.Models.Enums;

namespace Hospital.services
{
    public class AppointmentService : IAppointmentService   
    {
        private readonly ApplictionContext Context;
        public  AppointmentService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }
        
        public List<Appointment> GetAppointmentsWithDetails()
        { 
            var Appointments = Context.appointments
                                      .Include(a => a.doctor)  
                                      .Include(p => p.patient) 
                                      //.Include(b => b.billing)  
                                      //.Where(a => a.Date >= DateTime.Now)  
                                      .OrderBy(a => a.Date)  
                                      .ToList();
            return Appointments;
        }


        public Appointment GitById(int Id)
        {
            return Context?.appointments?.Include(_=>_.doctor).Include(_=>_.patient).FirstOrDefault(_=>_.Id==Id)!;

        }



        public void InsertAppointment( Appointment  Appointment)
        {
            
                Context.appointments.Add(Appointment);
                Context.SaveChanges();
            
        }
        public void UpdateAppointment( Appointment  Appointment)
        {
            
                Context.Update(Appointment);
                Context.SaveChanges();
          
           

        }
        public void DeleteAppointment( Appointment  Appointment)
        {
           var appointment= GitById(Appointment.Id);
            if (appointment != null)
            {
                appointment.IsActive=!appointment.IsActive;
                Context.SaveChanges();
            }
           
        }
        public SelectList GetListStatus()
        {
            var Status = Enum.GetValues(typeof(Statusenum))
                                      .Cast<Statusenum>()
                                      .Select(x => new { Id = (int)x, Name = x.ToString() })
                                      .ToList();

            return new SelectList(Status, "Id", "Name");
        }

       
    }
}
