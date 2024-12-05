using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IPatientService
    {

        List<Patient> GetPatients(string? search);
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient  GitById(int Id);
        void DeletePatient(Patient patient);
        SelectList GetListGender();

    }
}
