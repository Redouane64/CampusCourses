using System.ComponentModel.DataAnnotations;

namespace CampusCourses.WebApi.Identity.Models
{

    public class Register
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
