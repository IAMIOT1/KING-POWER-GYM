using Microsoft.AspNetCore.Mvc;
using GymAPI1.Data;
using GymAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI1.Controllers
{
    public class ProfileController : Controller
    {
        private readonly GymDbContext _context;

        public ProfileController(GymDbContext context)
        {
            _context = context;
        }
        public IActionResult GetProfile()
        {
            var user = HttpContext.Session.GetString("User");

            if (user == null)
                return Json(null);

            var member = _context.Members
                .Include(x => x.Package) // 🔥 QUAN TRỌNG
                .Where(x => x.Email == user || x.Phone == user)
                .Select(x => new {
                    x.FullName,
                    x.Phone,
                    x.Email,
                    PackageName = x.Package != null ? x.Package.PackageName : "Chưa đăng ký"
                })
                .FirstOrDefault();

            return Json(member);
        }


        // 1. Hàm để mở giao diện UpdateInfo.cshtml
        // 1. Hàm này để MỞ TRANG (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateInfo()
        {
            var memberId = HttpContext.Session.GetInt32("MemberID");
            if (memberId == null) return RedirectToAction("Login", "Auth");

            var member = await _context.Members.FindAsync(memberId);
            if (member == null) return NotFound();

            return View(member); // Sẽ tìm file UpdateInfo.cshtml
        }

        // 2. Hàm này để LƯU DỮ LIỆU (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInfo(Member model)
        {
            var member = await _context.Members.FindAsync(model.MemberID);
            if (member != null)
            {
                member.FullName = model.FullName;
                member.Phone = model.Phone;
                member.Email = model.Email;
                // Thêm các trường khác nếu cần

                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật thành công!";
            }
            return RedirectToAction("Index"); // Lưu xong quay về trang cá nhân
        }
        // POST
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var memberId = HttpContext.Session.GetInt32("MemberID");
            if (memberId == null) return RedirectToAction("Login", "Auth");

            var member = await _context.Members.FindAsync(memberId);

            if (member == null)
            {
                TempData["Error"] = "Không tìm thấy tài khoản!";
                return RedirectToAction("Index");
            }

            if (member.Password != oldPassword)
            {
                TempData["Error"] = "Mật khẩu cũ không đúng!";
                return View();
            }

            if (newPassword != confirmPassword)
            {
                TempData["Error"] = "Xác nhận mật khẩu không khớp!";
                return View();
            }

            member.Password = newPassword;
            await _context.SaveChangesAsync();

            TempData["Success"] = "Đổi mật khẩu thành công!";
            return RedirectToAction("Index");
        }

    }
}