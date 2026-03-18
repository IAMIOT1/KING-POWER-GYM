using GymAPI1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymAPI1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Club()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();

        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Recruit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
