using System.ComponentModel.DataAnnotations;

namespace OES_Complete_Project.Models
{
    public class Technology
    {
        [Key]
        public string Technology_ID { get; set; }
        [Required]
        public string Technology_Name { get; set; }
    }
}
