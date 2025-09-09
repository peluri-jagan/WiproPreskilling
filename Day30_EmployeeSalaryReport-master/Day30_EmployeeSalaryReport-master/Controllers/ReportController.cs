using EmployeeSalaryReport.Filters;
using EmployeeSalaryReport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeSalaryReport.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Report/Salary")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Salary() => Content("Salary report: [confidential]");
    }
}