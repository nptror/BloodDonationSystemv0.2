using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDS.DAL.Models;
using BDS.Common.DAL;
using BDS.DAL.Data;
namespace BDS.DAL.Repository
{
    public class BloodDonationRegisterRep : GenericRep<BloodDonationDbContext, BloodDonationRegister>
    {
        public BloodDonationRegisterRep()
        {

        }
        /// <summary>
        /// Tạo bản ghi đăng ký hiến máu mới
        /// </summary>
        /// <param name="m"></param>
        /// <exception cref="ArgumentNullException"></exception>
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