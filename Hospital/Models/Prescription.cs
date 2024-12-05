using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        [ForeignKey("patient")]
      
        public int PatientId { get; set; }
        public Patient? patient { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor? doctor { get; set; } 
        [MaxLength(200)]
        public string Medication { get; set; } 
        [MaxLength(300)]
        public string DosageInstructions { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime EndDate { get; set; }
        public List<MedicalRecord>? medicalRecords { get; set; }
    }
}






