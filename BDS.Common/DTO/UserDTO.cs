using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Common.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateOnly? DayOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string BloodType { get; set; } // Lấy từ bảng BloodType
    }
}
