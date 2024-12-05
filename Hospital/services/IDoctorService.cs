using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctors(string? search);
        Doctor GetDoctorById(int id);
        void InsertDoctor(Doctor doctor);
        void EditeDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        SelectList GetListSpecialization();
       // void searhOfDoctor(string searh);
    }
}
