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

        public SingleRsp Create(BloodDonationRegisterDTO req)
        {
            
            var res = new SingleRsp();

            try
            {
                // 1. Kiểm tra UserId có tồn tại không
                var user = _userRep.Read(u => u.UserId == req.UserId).FirstOrDefault();
                if (user == null)
                {
                    res.SetError("User not found");
                    return res;
                }

                // 2. (Tuỳ chọn) Kiểm tra người dùng này có đăng ký trong vòng 90 ngày gần nhất không
                var recentRegister = _rep.Read(r => r.UserId == req.UserId &&
                                                     r.RegisterDate > DateOnly.FromDateTime(DateTime.Now.AddDays(-90)))
                                         .FirstOrDefault();
                if (recentRegister != null)
                {
                    res.SetError("User already registered within last 90 days");
                    return res;
                }

                // 3. Tạo bản ghi mới
                var now = DateTime.Now;
                var register = new BloodDonationRegister
                {
                    UserId = req.UserId,
                    RegisterDate = DateOnly.FromDateTime(now),
                    AvailableDate = DateOnly.FromDateTime(now.AddDays(90)),
                    Notes = req.Notes,
                    DonationAddress = req.DonationAddress,
                    Status = "Pending"
                };

                _rep.Create(register);
            }
            catch (Exception ex)
            {
                res.SetError("Error creating donation register: " + ex.Message);
            }

            return res;
        }


    }
}
