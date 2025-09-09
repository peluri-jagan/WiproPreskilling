using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
