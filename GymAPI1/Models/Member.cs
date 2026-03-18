using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymAPI1.Models
{
    public class Member
    {
        [Key] // Dùng [Key] thay vì [NotMapped]
        public int MemberID { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [NotMapped] // Cái này giữ nguyên vì DB không có cột Password
        public string Password { get; set; } = string.Empty;
        [NotMapped] // Cái này giữ nguyên vì DB không có cột Password
        public int UserID { get; set; }

        // Các cột này nếu trong Database CÓ THÌ GIỮ NGUYÊN, KHÔNG CÓ THÌ MỚI [NotMapped]
        public DateTime JoinDate { get; set; }
        public int? PackageID { get; set; }
        public virtual Package? Package { get; set; }
        public virtual ICollection<Schedule>? Schedules { get; set; }
    }
}