using EmployeeSalaryReport.Filters;
using EmployeeSalaryReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSalaryReport.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Logic to retrieve and display products
            return View();
        }

        [HttpGet("product/{id:int}")]
        [ServiceFilter(typeof(ProductCacheResourceFilter))]
        public IActionResult Get(int id)
        {
            ContentResult contentResult = new ContentResult
            {
                Content = $"Details for product id: {id} fetched at " + DateTime.UtcNow,
                ContentType = "text/plain"
            };
            return contentResult;
        }
    }
}