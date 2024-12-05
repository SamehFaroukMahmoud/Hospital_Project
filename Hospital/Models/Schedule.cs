
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Models

{
    public class Schedule
    {
        public int Id { get; set; }
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor? doctor { get; set; } 
        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "Day of the week is required.")]
        [EnumDataType(typeof(DayOfWeek), ErrorMessage = "Please select a valid day of the week.")]
        public DayOfWeek DayOfWeek { get; set; }
        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.Time, ErrorMessage = "Please provide a valid time.")]
        public TimeSpan StartTime { get; set; }
        [Required(ErrorMessage = "End time is required.")]
        [DataType(DataType.Time, ErrorMessage = "Please provide a valid time.")]
        public TimeSpan EndTime { get; set; }
    }
}




