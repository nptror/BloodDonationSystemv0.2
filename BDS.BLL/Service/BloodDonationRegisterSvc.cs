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

    }
}