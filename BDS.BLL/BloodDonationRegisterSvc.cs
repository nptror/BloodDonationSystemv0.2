using BDS.Common.BLL;
using BDS.Common.Response;
using BDS.DAL;
using BDS.DAL.Models;

namespace BDS.BLL
{

    public class BloodDonationRegisterSvc : GenericSvc<BloodDonationRegisterRep, BloodDonationRegister>
    {
        private BloodDonationRegisterRep _bloodDonationRegisterRsp;
        public BloodDonationRegisterSvc()
        {
            _bloodDonationRegisterRsp = new BloodDonationRegisterRep();
        }

        
    }
}
