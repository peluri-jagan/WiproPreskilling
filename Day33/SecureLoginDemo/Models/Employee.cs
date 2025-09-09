using System.ComponentModel.DataAnnotations;

namespace Jagan.EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = default!;

        [Range(0, 100000000)]
        public decimal Salary { get; set; }

        [StringLength(50)]
        public string? Department { get; set; }
    }
}
