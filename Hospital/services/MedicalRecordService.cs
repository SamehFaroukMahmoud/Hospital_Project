using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.services
{
    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly ApplictionContext Context;
        public MedicalRecordService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }

        public List<MedicalRecord> GetMedicalRecords()
        {

            List<MedicalRecord> MedicalRecord = Context.medicalRecords.Include(z=>z.doctor)
                .Include(a=>a.patient).Include(v=>v.prescription).ToList();
            return MedicalRecord;
        }
       
        public SelectList GetListDoctor()
        {
            var ListDoctor = Context.doctors.ToList();
            return new SelectList(ListDoctor, "Id","Name");
        }
        public SelectList GetListPrescription()
        {
            var GetListPrescription = Context.prescriptions.ToList();
            return new SelectList(GetListPrescription, "Id", "DosageInstructions");
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {

            return Context.medicalRecords.Include(a => a.doctor).Include(s => s.patient)
                .Include(d => d.prescription).FirstOrDefault(w => w.Id == id);
        }
        public void InsertMedicalRecord(MedicalRecord MedicalRecord)
        {

            Context.Add(MedicalRecord);
            Context.SaveChanges();
        }
        public void EditeMedicalRecord(MedicalRecord MedicalRecord)
        {

            Context.Update(MedicalRecord);
            Context.SaveChanges();
        }
        public void DeleteMedicalRecord(MedicalRecord MedicalRecord)
        {
            var medicalRecord = GetMedicalRecordById(MedicalRecord.Id);
            if (medicalRecord != null)
            {
                medicalRecord.IsActive=!medicalRecord.IsActive;
                Context.SaveChanges();
            }
           
        }

    }
}
