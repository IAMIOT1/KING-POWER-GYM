using Microsoft.AspNetCore.Mvc;
using GymAPI1.Data;
using GymAPI1.Models;
using System.Linq;

namespace GymAPI1.Controllers
{
    public class AuthController : Controller
    {
        private readonly GymDbContext _context;

        public AuthController(GymDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }


        // XỬ LÝ LOGIN
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                TempData["Error"] = "Sai tài khoản hoặc mật khẩu!";
                return RedirectToAction("Login");
            }

            // ✅ ĐĂNG NHẬP THÀNH CÔNG
            HttpContext.Session.SetString("User", user.Username);
            HttpContext.Session.SetString("role", user.Role);

            // 🔥 SỬA DÒNG NÀY: Dùng UserID thay vì Id
            HttpContext.Session.SetInt32("MemberID", user.UserID);

            TempData["Success"] = "Đăng nhập thành công!";
            return RedirectToAction("Index", "Home");
        }

        // XỬ LÝ REGISTER
        [HttpPost]
        public IActionResult Register(string username, string password, string confirm)
        {
            if (password != confirm)
            {
                TempData["Error"] = "Mật khẩu không khớp!";
                return RedirectToAction("Index", "Home");
            }

            // 🔥 check tồn tại
            var existing = _context.Users.FirstOrDefault(x => x.Username == username);
            if (existing != null)
            {
                TempData["Error"] = "Tài khoản đã tồn tại!";
                return RedirectToAction("Index", "Home");
            }

            // 🔥 tạo user mới
            var user = new User
            {
                Username = username,
                Password = password,
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Success"] = "Đăng ký thành công!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}