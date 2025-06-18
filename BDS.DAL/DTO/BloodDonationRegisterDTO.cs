using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Common.DTO
{
    public class BloodDonationRegisterDTO
    {
        public int UserId { get; set; }
        public DateOnly? RegisterDate { get; set; }
        public string? Notes { get; set; }
        public string DonationAddress { get; set; } = string.Empty;

        
    }
}
