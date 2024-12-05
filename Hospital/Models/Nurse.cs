using System.ComponentModel.DataAnnotations;
using static Hospital.Models.Enums;

namespace Hospital.Models
{
    public class Nurse:BaseClass
    {
        [Required]
        public Shift Shift { get; set; }
        public bool IsActive { get; set; } = true;


    }
}


