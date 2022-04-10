using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OES_Complete_Project.Models
{
    public class Reports
    {
        [Key]
        public string? Exam_ID { get; set; }

        //[ForeignKey("Students")]
        //public string User_ID { get; set; }

        public virtual Students Students { get; set; }  //fk
        public int Marks1 { get; set; }
        public int Marks2 { get; set; }
        public int Marks3 { get; set; }

        //[ForeignKey("Technology")]
        
        public virtual Technology technology { get; set; }  //foreign
        //public string? Technology_ID { get; set; }
    }
}
