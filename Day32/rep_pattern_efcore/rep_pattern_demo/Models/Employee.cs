using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rep_pattern_demo.Models
{
    [Table("Employee")] // Maps to SQL table "Employee"
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; }

        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string EmailId { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Joining Date is required")]
        public DateTime DateOfJoining { get; set; }

        [Display(Name = "Salary")]
        [Range(10000, 100000, ErrorMessage = "Salary must be between ₹10,000 and ₹1,00,000")]
        public decimal Salary { get; set; }
    }
}
