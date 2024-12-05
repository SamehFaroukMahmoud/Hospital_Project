using Hospital.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hospital.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Models
{
    public class Billing
    {
        public int Id { get; set; }
        [ForeignKey("patient")]
       
        public int PatientId { get; set; }
        public Patient? patient { get; set; } 
        [DataType(DataType.Currency, ErrorMessage = "Total Amount should be a valid currency format.")]
        [Range(0, 10000, ErrorMessage = "Total Amount must be between 0 and 10,000.")]
        public decimal? TotalAmount { get; set; }
        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "Payment Status is required.")]
        [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid Payment Status.")]
        public PaymentStatus PaymentStatus { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime? DateGenerated { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime? DueDate { get; set; } 

        [ForeignKey("AppointmentId")]
        
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; } 
    }
}





