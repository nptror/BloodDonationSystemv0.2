using BDS.Common.DAL;
using BDS.Common.Response;
using BDS.DAL.Data;
using BDS.DAL.Models;

namespace BDS.DAL.Repository
{

    public class BloodDonationRegisterRep : GenericRep<BloodDonationDbContext, BloodDonationRegister>
    {
        public BloodDonationRegisterRep()
        { 
            
        }

        public new void Create(BloodDonationRegister m)
        {
            if (m == null)
            {
                throw new ArgumentNullException(nameof(m), "BloodDonationRegister cannot be null");
            }
            base.Create(m);
        }
        public List<BloodDonationRegister> Read(int userId)
        {
            return GetAll
           .Where(r => r.UserId == userId)
           .OrderByDescending(r => r.RegisterDate) // nếu muốn sắp xếp theo ngày đăng ký mới nhất
           .ToList();
        }

    }
}
