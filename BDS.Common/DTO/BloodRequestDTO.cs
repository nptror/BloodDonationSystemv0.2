using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Common.DTO
{
    public class BloodRequestDTO
    {
        public int UserId { get; set; }
        public int BloodTypeId { get; set; }

        // Whole, RBC, Platelet, Plasma
        public string ComponentType { get; set; } = null!;

        public float Quantity { get; set; }

        // Pending, Processing, Fulfilled, Rejected
        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; }

        public int? StaffId { get; set; } // Có thể null lúc tạo
    }
}
