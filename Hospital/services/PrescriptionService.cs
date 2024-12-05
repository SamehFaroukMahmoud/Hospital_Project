using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.services
{
    public class PrescriptionService:IPrescriptionService
    {
        private readonly ApplictionContext Context;
        public PrescriptionService(ApplictionContext applictionContext)
        {
            Context = applictionContext;
        }
        public List<Prescription> GetPrescriptions() 
        {
            List<Prescription> prescriptions=Context.prescriptions.
                Include(a=>a.patient).Include(x=>x.doctor).ToList();
            return prescriptions;
        }
        public Prescription GetPrescriptionId(int id) 
        {
            return Context?.prescriptions?.Include(_=>_.doctor).Include(_=>_.patient).FirstOrDefault(_=>_.Id==id)!;
        }
         
        public void InsertPrescription(Prescription prescription) 
        {
           Context.Add(prescription);
            Context.SaveChanges();
        }
        public void UpdatePrescription(Prescription prescription)
        {
           Context.Update(prescription);
            Context.SaveChanges();
        }
        public void DeletePrescription(Prescription prescription)
        {
            var Prescription = GetPrescriptionId(prescription.Id);
            if (Prescription != null)
            {
                Prescription.IsActive = !Prescription.IsActive;
                Context.SaveChanges();
            }
           
          
        }
        




    }
}
