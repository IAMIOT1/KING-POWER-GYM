using Microsoft.AspNetCore.Mvc;

namespace GymAPI1.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
