
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Hospital.Models.Enums;

namespace Hospital.services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplictionContext Context;
        public DoctorService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }

        public List<Doctor> GetDoctors( string? search)
        {
            if(search == null)
            {
                List<Doctor> doctor = Context.doctors.ToList();
                return doctor;

            }
           List<Doctor> doctors=Context.doctors.Where(a=>a.Name.Contains(search)).ToList();
            return doctors;
        }
        public Doctor GetDoctorById(int id)
        {

            return Context?.doctors?.Find(id)!;
        }
       

        public SelectList GetListSpecialization()
        {
            var specializations = Enum.GetValues(typeof(Specialization))
                                      .Cast<Specialization>()
                                      .Select(x => new { Id = (int)x, Name = x.ToString() })
                                      .ToList();

            return new SelectList(specializations, "Id", "Name");
        }

        public void InsertDoctor(Doctor doctor)
        {

            Context.Add(doctor);
            Context.SaveChanges();
        }
        public void EditeDoctor(Doctor doctor)
        {

            Context.Update(doctor);
            Context.SaveChanges();
        }
        public void DeleteDoctor(Doctor doctor)
        {
            var doc = GetDoctorById(doctor.Id); 

            if (doc != null) {
                doc.IsActive = !doc.IsActive;
                Context.SaveChanges();
            }
            
        }
       

    }
}
