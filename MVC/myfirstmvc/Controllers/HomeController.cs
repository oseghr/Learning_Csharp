using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfirstmvc.Models;

namespace myfirstmvc.Controllers;

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
}










// class Person
// {

//     public Person() //constructor
//     {
//         // Logic
//     }
//     private string name; //field

//     public string Name //property
//     {
//         get { return name; }
//         set { name = value; }
//     }

//     public void MethodName()  //method
//     {
//         //Logic
//     }
// }