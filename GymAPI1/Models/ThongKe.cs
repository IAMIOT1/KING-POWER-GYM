namespace GymAPI1.Models
{
    public class ThongKe
    {
        public int TongHoiVien { get; set; }
        public int TongGoiTap { get; set; }
        public decimal TongDoanhThu { get; set; }
        public List<PackageThongKe> TopGoiTap { get; set; } = new List<PackageThongKe>();
        public List<HoiVienChiTiet> DanhSachHoiVien { get; set; } = new List<HoiVienChiTiet>();
    }

    public class PackageThongKe
    {
        public int PackageID { get; set; }
        public string TenGoi { get; set; } = string.Empty;
        public int SoLuongDangKy { get; set; }
    }

    public class HoiVienChiTiet
    {
        public string TenHoiVien { get; set; } = "";
        public string TenGoiTap { get; set; } = "";
        public decimal GiaGoi { get; set; }

        // Thêm 2 dòng này để hết lỗi CS0117 trong ProfileController
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
    }
}