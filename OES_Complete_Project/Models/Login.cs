using System.ComponentModel.DataAnnotations;

namespace OES_Complete_Project.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "User Email")]
        public string Email { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
