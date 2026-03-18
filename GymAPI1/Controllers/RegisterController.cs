using GymAPI1.Data;
using GymAPI1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymAPI1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly GymDbContext _context; // Khai báo DbContext

        // Dùng Constructor để hệ thống tự truyền database vào
        public RegisterController(GymDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // BƯỚC 1: Lưu thông tin vào bảng Users (để đăng nhập)
                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = "Member"
                };
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                // BƯỚC 2: Tự động thêm thông tin vào bảng Members (hội viên)
                var newMember = new Member
                {
                    FullName = model.FullName,
                    Phone = model.Phone,
                    Email = model.Email,
                    JoinDate = DateTime.Now
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Auth");
            }
            return View(model);
        }
    }
}
