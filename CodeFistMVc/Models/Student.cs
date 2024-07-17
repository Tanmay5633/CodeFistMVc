using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFistMVc.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("studentName", TypeName= "varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("studentGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public int? standard { get; set; }


    }
}
