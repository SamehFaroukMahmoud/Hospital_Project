using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class BaseClass
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The email not valid  ")]
        public string Email { get; set; }
        [MinLength(11), MaxLength(11)]
        [Required(ErrorMessage = "The Contact Number field is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string ContactNumber { get; set; } = string.Empty;
    }
}
