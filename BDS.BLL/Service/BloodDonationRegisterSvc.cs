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
      public SingleRsp Create(BloodDonationRegisterDTO req)
{
    var res = new SingleRsp();

    try
    {
        if (req != null)
        {
            if (_userRep != null)
            {
                var user = _userRep.Read(u => u.UserId == req.UserId).FirstOrDefault();
                if (user != null)
                {
                    if (req.RegisterDate != null)
                    {
                        var isWithin90Days = req.RegisterDate >= DateOnly.FromDateTime(DateTime.Now.AddDays(-90));
                        if (isWithin90Days)
                        {
                            if (_rep != null)
                            {
                                var now = DateTime.Now;
                                var register = new BloodDonationRegister
                                {
                                    UserId = req.UserId,
                                    RegisterDate = req.RegisterDate,
                                    AvailableDate = req.RegisterDate?.AddDays(90),
                                    Notes = req.Notes,
                                    DonationAddress = req.DonationAddress,
                                    Status = "Pending"
                                };

                                _rep.Create(register);
                            }
                            else
                            {
                                res.SetError("_rep is null");
                            }
                        }
                        else
                        {
                            res.SetError("Register date must be within the last 90 days.");
                        }
                    }
                    else
                    {
                        res.SetError("RegisterDate is required.");
                    }
                }
                else
                {
                    res.SetError("User not found");
                }
            }
            else
            {
                res.SetError("_userRep is null");
            }
        }
        else
        {
            res.SetError("Request is null");
        }
    }
    catch (Exception ex)
    {
        res.SetError("Error creating donation register: " + ex.Message);
    }

    return res;
}

        /// <summary>
        /// Trả về BloodDonationRegister theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SingleRsp ReadById(int userId)
        {
            var res = new SingleRsp();
            try
            {
                var register = _bloodDonationRegisterRsp.ReadById(userId);
                if (register == null)
                {
                    res.SetError("No donation register found for the given user ID.");
                }
                else
                {
                    res.Data = register;
                }
            }
            catch (Exception ex)
            {
                res.SetError("Error reading donation register: " + ex.Message);
            }
            return res;
        }


        /// <summary>
        ///  USER Cập nhật thông tin đơn đăng ký hiến máu đã tạo trước đó
        ///  STAFF cập nhật trạng thái đơn đăng ký hiến máu
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SingleRsp Update(BloodDonationRegisterDTO req)
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
                // 2. Tìm bản ghi cần cập nhật
                var register = _bloodDonationRegisterRsp.ReadById(req.RegisterId);
                if (register == null)
                {
                    res.SetError("No donation register found for the given user ID.");
                    return res;
                }
                // 3. Cập nhật thông tin
                register.RegisterDate = req.RegisterDate;
                register.AvailableDate = req.RegisterDate?.AddDays(90);
                register.DonationAddress = req.DonationAddress;
                register.Status = req.Status ?? register.Status; // Giữ nguyên nếu không có giá trị mới
                register.Notes = req.Notes;
                _rep.Update(register);
            }
            catch (Exception ex)
            {
                res.SetError("Error updating donation register: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Xóa bản ghi đăng ký hiến máu theo RegisterId
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        public SingleRsp Delete(int registerId)
        {
            var res = new SingleRsp();
            try
            {
                // 1. Kiểm tra UserId có tồn tại không
                //var user = _userRep.Read(u => u.UserId == req.UserId).FirstOrDefault();
                //if (user == null)
                //{
                //    res.SetError("User not found");
                //    return res;
                //}
                // 2. Tìm bản ghi cần xóa
                var register = _bloodDonationRegisterRsp.ReadById(registerId);
                if (register == null)
                {
                    res.SetError("No donation register found for the given user ID.");
                    return res;
                }
                // 3. Xóa bản ghi
                _bloodDonationRegisterRsp.Delete(register);
            }
            catch (Exception ex)
            {
                res.SetError("Error deleting donation register: " + ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Trả về danh sách các bản ghi đăng ký hiến máu của người dùng theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BloodDonationRegister> Read(int userId)
        {
            return _bloodDonationRegisterRsp.Read(userId);
        }


    }
}
