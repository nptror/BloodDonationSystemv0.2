using BDS.Common.BLL;
using BDS.Common.DTO;
using BDS.Common.Response;
using BDS.DAL.Models;
using BDS.DAL.Repository;

namespace BDS.BLL.Service
{
    public class BloodDonationRegisterSvc : GenericSvc<BloodDonationRegisterRep, BloodDonationRegister>
    {
        private BloodDonationRegisterRep _bloodDonationRegisterRsp;
        private UserRep _userRep = new UserRep();
        public BloodDonationRegisterSvc()
        {
            _bloodDonationRegisterRsp = new BloodDonationRegisterRep();
        }

        /// <summary>
        /// Tạo bản ghi đăng ký hiến máu mới
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
       
    }
}