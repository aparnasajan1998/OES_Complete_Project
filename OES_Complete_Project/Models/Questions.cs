using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OES_Complete_Project.Models
{
    public class Questions
    {
        [Key]
        public string Question_ID { get; set; }

        [Required]
        public string Question { get; set; }
        public string Option_1 { get; set; }
        public string Option_2 { get; set; }
        public string Option_3 { get; set; }
        public string Option_4 { get; set; }

        [Required]
        public int Level { get; set; }

        //[ForeignKey("Technology_ID")]
        
        public virtual Technology technology { get; set; }      //foreign attribute
        public string Correct_Answer { get; set; }
    }
}

