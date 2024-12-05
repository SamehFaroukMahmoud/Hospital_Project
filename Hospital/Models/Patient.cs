using System.ComponentModel.DataAnnotations;
using static Hospital.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Models
{
    public class Patient : BaseClass
    {
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }=DateTime.MinValue;
        [Required(ErrorMessage = "Gender required.")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Please select a valid Gender")]
        public Gender Gender { get; set; }
        public bool IsActive { get; set; } = true;
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string? Address { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid time.")]
        public string EmergencyContact { get; set; }= string.Empty;
        [Display(Name= "ProfilePicture")]
        public byte[]  ProfilePicture { get; set; }

        public ICollection<Appointment> ?appointments { get; set; } 
        public ICollection<MedicalRecord>? medicalRecords { get; set; }
        public ICollection<Billing>? billings { get; set; } 
        public ICollection<Prescription>? prescriptions { get; set; } 
    }
}



