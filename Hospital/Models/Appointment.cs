using Hospital.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hospital.Models.Enums;

namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [ForeignKey("patient")]
        public int PatientId { get; set; } 
        public Patient? patient { get; set; } 
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor? doctor  { get; set; } 
        [Required]
        public Statusenum Status { get; set; }
        public bool IsActive { get; set; } = true;

        public Billing? billing { get; set; } 


    }
}





