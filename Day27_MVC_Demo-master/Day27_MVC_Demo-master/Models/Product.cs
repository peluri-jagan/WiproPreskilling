//Adding Data Annotations for validation purposes
using System.ComponentModel.DataAnnotations;
namespace MVC_Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        public decimal Price { get; set; }
    }
}
