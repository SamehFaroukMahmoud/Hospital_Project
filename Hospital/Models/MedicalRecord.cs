using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        [ForeignKey("patient")]
        public int PatientId { get; set; }
        public Patient? patient { get; set; } 
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public  Doctor? doctor { get; set; } 
        public bool IsActive { get; set; } = true;
        [MaxLength(300)]
        public string Diagnosis { get; set; } 
        [MaxLength(300)]
        public string TreatmentPlan { get; set; } 
        [ForeignKey("prescription")]
        public int PrescriptionId { get; set; }
        public  Prescription? prescription { get; set; } 

    }
}

