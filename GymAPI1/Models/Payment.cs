using System;

namespace GymAPI1.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int MemberID { get; set; }

        public int PackageID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}