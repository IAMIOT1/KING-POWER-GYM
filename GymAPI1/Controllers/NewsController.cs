using Microsoft.AspNetCore.Mvc;

namespace GymAPI1.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
