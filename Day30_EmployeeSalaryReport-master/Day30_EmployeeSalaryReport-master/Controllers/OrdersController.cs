using EmployeeSalaryReport.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace EmployeeSalaryReport.Controllers
{
    [Route("orders")]
    [ServiceFilter(typeof(GlobalExceptionFilter))]
    public class OrdersController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Logic to retrieve and display orders
            throw new Exception("Test exception in Index");
        }

        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(LogFilter))]
        public async Task<IActionResult> Get(int id)
        {
            await Task.Delay(50); // simulate I/O
            return Ok(new { Id = id, Status = "OK" });
        }

        [HttpGet("error")]
        public IActionResult ErrorTest()
        {
            throw new Exception("Test exception");
        }
    }
}