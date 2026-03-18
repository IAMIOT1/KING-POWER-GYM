using Microsoft.AspNetCore.Mvc;

namespace GymAPI1.Controllers
{
    public class RewardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
