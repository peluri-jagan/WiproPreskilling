using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models; // Importing the Models namespace to use Product model

namespace MVC_Demo.Controllers
{
    public class ProductsController : Controller
    {
        //Controllers are responsible for handling user requests and returning responses.

        //Get: /Products/Index
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.00M },
                new Product { Id = 2, Name = "Smartphone", Price = 499.99M },
                new Product { Id = 3, Name = "Tablet", Price = 299.99M }
            };
            return View(products); //passing products to the view
        }

        //Get: /Products/Create
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new product
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]//To prevent CSRF Attacks
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                // Here you would typically save the product to a database
                // For demonstration, we will just redirect to the Index action
                return RedirectToAction("Index");
            }
            return View(product); // If model state is invalid, return the same view with the product data
        }
    }
}
