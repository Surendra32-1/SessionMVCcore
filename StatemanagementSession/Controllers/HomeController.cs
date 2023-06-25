using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatemanagementSession.Models;
using System.Diagnostics;

namespace StatemanagementSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //adding Data in session 
            HttpContext.Session.SetInt32("age", 30);
            HttpContext.Session.SetString("name", "Riddhasoft");
            return View();
        }

        public IActionResult Privacy()
        {
            //receiving data from session 
            ViewBag.Name=HttpContext.Session.GetString("name");
            ViewBag.Age=HttpContext.Session.GetInt32("age");
            return View();
        }
        public IActionResult About()
        {
            //receiving data from session 
            ViewBag.Name = HttpContext.Session.GetString("name");
            ViewBag.Age = HttpContext.Session.GetInt32("age");
            //clear session for age
            HttpContext.Session.Remove("age");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}