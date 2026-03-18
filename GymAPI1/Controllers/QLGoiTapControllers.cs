using Microsoft.AspNetCore.Mvc;
using GymAPI1.Data;
using GymAPI1.Models;
using System.Linq;

namespace GymAPI1.Controllers
{
    public class QLGoiTapController : Controller
    {
        private readonly GymDbContext _context;

        public QLGoiTapController(GymDbContext context)
        {
            _context = context;
        }

        // Trang danh sách gói tập
        public IActionResult Index()
        {
            var list = _context.Packages.ToList();
            return View(list);
        }

        // Gọi Form để Thêm mới
        public IActionResult Create()
        {
            return View("Form", new Package());
        }

        [HttpPost]
        public IActionResult Create(Package obj)
        {
            _context.Packages.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Gọi Form để Chỉnh sửa
        public IActionResult Edit(int id)
        {
            var obj = _context.Packages.Find(id);
            if (obj == null) return NotFound();
            return View("Form", obj);
        }

        [HttpPost]
        public IActionResult Edit(Package obj)
        {
            _context.Packages.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var package = _context.Packages.Find(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}