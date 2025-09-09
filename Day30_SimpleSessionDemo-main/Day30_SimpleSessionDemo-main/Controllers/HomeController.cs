using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleSessionDemo.Models;

namespace SimpleSessionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //Get the current visit count from session
        int visitCount = HttpContext.Session.GetInt32("VisitCount") ?? 0; // ?? is used to provide a default value , called null-coalescing operator
        visitCount++;//Increase the visit count by 1
        HttpContext.Session.SetInt32("VisitCount", visitCount);//Storing the new visit count to session
        //Passing the count to the view
        return View(visitCount);

        //If we dont want to pass the count to the view , we can simply return the view without any model
        //using inbuilt key value variables i.e ViewBag and ViewData
        //Both can be used to pass data from controller to view
        //Ex:
        // ViewBag.VisitCount = visitCount; //Dynamic Property
        // Or
        // ViewData["VisitCount"] = visitCount; //Key Value Pair   
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

    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear(); //Clears all session data

        HttpContext.Session.Remove("VisitCount"); //Removes specific session data
        
        return RedirectToAction("Index"); //Redirects to Index action
        //We have other way also to redirect/transfer server session using server.Transfer()
    }
}
