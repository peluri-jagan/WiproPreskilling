using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int TrainerID { get; set; }

        // [EmailAddress]
        // public string Email { get; set; }
    }
}
