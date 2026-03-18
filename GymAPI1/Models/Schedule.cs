namespace GymAPI1.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int MemberID { get; set; }
        public int TrainerID { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string WorkoutTime { get; set; } = "";

        // THÊM DÒNG NÀY: Để C# biết đường chạy sang bảng Members
        public virtual Member? Member { get; set; }
    }
}