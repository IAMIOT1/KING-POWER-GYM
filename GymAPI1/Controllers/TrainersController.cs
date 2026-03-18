using Microsoft.AspNetCore.Mvc;

namespace GymAPI1.Controllers
{
    public class TrainersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
