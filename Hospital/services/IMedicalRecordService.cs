using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IMedicalRecordService
    {
        List<MedicalRecord> GetMedicalRecords();
        MedicalRecord GetMedicalRecordById(int id);
        void InsertMedicalRecord(MedicalRecord MedicalRecord);
        void EditeMedicalRecord(MedicalRecord MedicalRecord);
        void DeleteMedicalRecord(MedicalRecord MedicalRecord);

        SelectList GetListDoctor();
        SelectList GetListPrescription();
    }
}
