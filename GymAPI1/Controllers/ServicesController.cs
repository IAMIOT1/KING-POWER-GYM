using Microsoft.AspNetCore.Mvc;

namespace GymAPI1.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
