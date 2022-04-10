using System.ComponentModel.DataAnnotations;

namespace OES_Complete_Project.Models
{
    public class Students
    {
        [Key]
        [Display(Name = "User_ID")]
        [Required(ErrorMessage = "User Id is required")]
        public string User_ID { get; set; }

        [Display(Name = "User Full Name")]
        [Required(ErrorMessage = "User Full Name is required")]
        public string Full_Name { get; set; }

        [Display(Name = "User email_id")]
        [Required(ErrorMessage = "Email-Id is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string? City { get; set; }

        [Display(Name = "Mobileno")]
        [Required(ErrorMessage = "*")]
        public string Mobile_No { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Qualification { get; set; }
        [Required]
        public int YearOfCompletion { get; set; }
    }
}
