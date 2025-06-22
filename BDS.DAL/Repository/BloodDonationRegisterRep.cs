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

        /// <summary>
        /// Trả về BloodDonationRegister theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public override BloodDonationRegister ReadById(int registerId)
        {
            return GetAll.Where(r => r.RegisterId == registerId).OrderByDescending(r => r.RegisterDate).FirstOrDefault();
        }


        /// <summary>
        /// Trả về danh sách BloodDonationRegister theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BloodDonationRegister> Read(int userId)
        {
            return GetAll
           .Where(r => r.UserId == userId)
           .OrderByDescending(r => r.RegisterDate) // nếu muốn sắp xếp theo ngày đăng ký mới nhất
           .ToList();
        }
        /// <summary>
        /// Xoá bản ghi đăng ký hiến máu
        /// </summary>
        /// <param name="m"></param>
        ///  <exception cref="ArgumentNullException"></exception>
        public void Delete(BloodDonationRegister m)
        {
            if (m == null)
            {
                throw new ArgumentNullException(nameof(m), "BloodDonationRegister cannot be null");
            }
            base.Delete(m);
        }


        /// <summary>
        ///  USER Cập nhật  1 SỐ THÔNG TIN bản ghi đăng ký hiến máu
        /// </summary>
        /// <param name="old"></param>
        /// <param name="new"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(BloodDonationRegister @new)
        {
            if (@new == null)
            {
                throw new ArgumentNullException("BloodDonationRegister cannot be null");
            }
            base.Update(@new);
        }

       
    }
}
