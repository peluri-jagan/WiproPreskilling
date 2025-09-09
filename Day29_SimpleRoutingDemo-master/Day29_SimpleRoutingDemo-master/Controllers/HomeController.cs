using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleRoutingDemo.Models;

namespace SimpleRoutingDemo.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult EvenOnly(int id) => Content($"Even ID: {id} is valid and even.");
    //Works only when id is even

    public IActionResult OddOnly(int id) => Content($"Odd ID: {id} is valid and odd.");
    //Works only when id is odd

    public IActionResult Any(int id) => Content($"Any ID: {id} is valid.");
    //works for all IDs(Normal Fallback)

    public IActionResult SpecialOnly() => Content($"Special route matched dynamically.");
    //Action for special Dynamic route
}
