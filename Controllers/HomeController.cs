using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Oggetti_Usati.Models;

namespace Oggetti_Usati.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private string isAuthenticated = "OK";

    public IActionResult Index()
    {
        ViewBag.logged = false;
        //string? isAuthenticated = HttpContext.Session.GetString("isAuthenticated");
        return View();
    }

    public IActionResult Privacy()
    {
        //string? isAuthenticated = HttpContext.Session.GetString("isAuthenticated");
        if (isAuthenticated == "OK")
            return View();
        return Redirect("\\home\\Login");
        
    }
    public IActionResult ChiSiamo()
    {
        return View( );
    }

    public IActionResult SignUp()
    {
        return View( );
    }


    public ActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(Login L)
    {
        // Check if the entered credentials match the stored sign-up credentials
        if (L.Nome_Utente == "q" && L.Password == "q")
        {
            ViewBag.logged = true;
            return RedirectToAction("IndexAuth"); // Redirect to the homepage
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
            return View();
        }
    }

    public IActionResult IndexAuth()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
