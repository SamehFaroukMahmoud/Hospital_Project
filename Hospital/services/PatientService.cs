using Hospital.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data.OleDb;
using static Hospital.Models.Enums;

namespace Hospital.services
{
    public class PatientService:IPatientService
    {
        private readonly ApplictionContext Context;
        public PatientService(ApplictionContext applictionContext)
        {
            Context = applictionContext;
     
        }
        public List<Patient> GetPatients(string?search)
        {
            if(search==null)
            {
                List<Patient> patient = Context.patients.ToList();
                return patient;

            }
           var patients = Context.patients.Where(x => x.Name.Contains(search)).ToList();

            return patients;

        }

        public Patient GitById(int Id)
        {
            return Context?.patients?.Find(Id)!; 
        
        }
       


        public void InsertPatient(Patient patient)
        {
            Context.patients.Add(patient);
            Context.SaveChanges();

        }
        public void UpdatePatient(Patient patient) 
        {
            Context.Update(patient);
            Context.SaveChanges();

        }
        public void DeletePatient(Patient patient)
        {
            var Patient = GitById(patient.Id);
            if (Patient != null)
            {
                Patient.IsActive = !Patient.IsActive;
                Context.SaveChanges();
            }
        }
        public SelectList GetListGender()
        {
            var Gender = Enum.GetValues(typeof(Gender))
                                      .Cast<Gender>()
                                      .Select(x => new { Id = (int)x, Name = x.ToString() })
                                      .ToList();

            return new SelectList(Gender, "Id", "Name");
        }


    }
}
