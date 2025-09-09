using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_ADO_Demo.Data;
using System.Data;

namespace Mvc_ADO_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            //Invoking getProducts method for retrieving all products from the database
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, decimal price)
        {
            //Here we can call insertProduct defined in repository class
            if (price >= 0 && ModelState.IsValid)
            {
                int newProductId = _productsRepository.InsertProduct(name, price);
                //Inserting the product and getting the new product id
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productsRepository.DeleteProduct(id);
            //Calling the delete method from repository
            return RedirectToAction("Index");
        }
    }
}