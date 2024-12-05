using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using static Hospital.Models.Enums;

namespace Hospital.Models
{
    public class Doctor : BaseClass
    {
        [Required(ErrorMessage = "Day of the week is required.")]
        [EnumDataType(typeof(Specialization), ErrorMessage = "Please select a valid Specialization.")]
        public Specialization Specialization { get; set; }
        [Required(ErrorMessage = "Room Number is required.")]
        public string RoomNumber { get; set; }=string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Schedule>? AvailableSchedules { get; set; } 
        public ICollection<Appointment>? appointments { get; set; } 
        public ICollection<MedicalRecord>? medicalRecords{ get; set; }
    }
}








