using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int TrainerID { get; set; }

        public Trainer? Trainer { get; set; }//fk to trainer class
    }
}
