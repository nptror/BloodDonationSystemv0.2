using BDS.Common.DAL;
using BDS.DAL.Data;
using BDS.DAL.Models;

namespace BDS.DAL.Repository
{
    public class BloodRequestRep : GenericRep<BloodDonationDbContext, BloodRequest>
    {
        public BloodRequestRep()
        {
            // Constructor logic if needed
        }

        public new void Create(BloodRequest m)
        {
            if (m == null)
            {
                throw new ArgumentNullException(nameof(m), "BloodRequest cannot be null");
            }
            base.Create(m);
        }
    }
}
