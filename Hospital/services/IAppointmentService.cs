using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IAppointmentService
    {
        //List< Appointment> GetAppointments();
        void InsertAppointment( Appointment  Appointment);
        void UpdateAppointment( Appointment  Appointment);
         Appointment GitById(int Id);
        void DeleteAppointment( Appointment  Appointment);
        SelectList GetListStatus();
        List<Appointment> GetAppointmentsWithDetails();
    }
}
