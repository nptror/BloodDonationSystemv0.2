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
    }
}
