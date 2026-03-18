using GymAPI1.Data;
using GymAPI1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class MembersController : Controller
{
    private readonly GymDbContext _context;
    public MembersController(GymDbContext context) { _context = context; }

    private bool IsAdmin() => HttpContext.Session.GetString("role") == "Admin";

    // HIỂN THỊ DANH SÁCH (Sửa lỗi ảnh 1)
    public IActionResult Index()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Auth");
        return View(_context.Members.ToList());
    }

    // FORM THÊM
    public IActionResult Create()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Auth");
        ViewBag.Action = "Create";
        return View("Form", new Member()); // Gọi file Form.cshtml
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Member member)
    {
        member.JoinDate = DateTime.Now;
        _context.Members.Add(member);
        _context.SaveChanges(); // <-- Dòng này để lưu vào SQL
        return RedirectToAction(nameof(Index));
    }
    // FORM SỬA
    public IActionResult Edit(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Auth");
        var member = _context.Members.Find(id);
        if (member == null) return NotFound();

        ViewBag.Action = "Edit";
        return View("Form", member); // Gọi file Form.cshtml
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Member member)
    {
        _context.Update(member);
        _context.SaveChanges(); // <-- Dòng này để lưu vào SQL
        return RedirectToAction(nameof(Index));
    }

    // XOÁ
    public IActionResult Delete(int id)
    {
        var member = _context.Members.Find(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}