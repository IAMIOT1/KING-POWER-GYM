using Microsoft.AspNetCore.Mvc;
using GymAPI1.Data;
using GymAPI1.Models; // Để nhận diện class ThongKe
using System.Linq;

namespace GymAPI1.Controllers
{
    public class ThongkeController : Controller
    {
        private readonly GymDbContext _context;

        public ThongkeController(GymDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = new ThongKe();
            // Lấy chi tiết từng người dùng và tên gói họ tập qua JOIN
            data.DanhSachHoiVien = (from m in _context.Members
                                    join p in _context.Packages on m.PackageID equals p.PackageID
                                    select new HoiVienChiTiet
                                    {
                                        TenHoiVien = m.FullName, // Hãy thay FullName bằng tên cột đúng của bạn
                                        TenGoiTap = p.PackageName,
                                        GiaGoi = p.Price
                                    }).ToList();

            data.TongHoiVien = _context.Members.Count();
            data.TongDoanhThu = data.DanhSachHoiVien.Sum(x => x.GiaGoi);
            return View(data);
        }
    }
}