using BDS.Common.BLL;
using BDS.Common.DTO;
using BDS.Common.Response;
using BDS.DAL;
using BDS.DAL.Models;

namespace BDS.BLL
{
    public class BloodRequestSvc : GenericSvc<BloodRequestRep, BloodRequest>
    {
        private BloodRequestRep _bloodRequestRep;
        private UserRep _userRep = new UserRep();
        public BloodRequestSvc()
        {
            _bloodRequestRep = new BloodRequestRep();
        }

        public SingleRsp Create(BloodRequestDTO req)
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

                //// 2. Kiểm tra BloodTypeId có tồn tại không
                //var bloodType = _bloodTypeRep.Read(b => b.BloodTypeId == req.BloodTypeId).FirstOrDefault();
                //if (bloodType == null)
                //{
                //    res.SetError("Blood type not found");
                //    return res;
                //}

                //// 3. Nếu có StaffId thì kiểm tra luôn
                //if (req.StaffId.HasValue)
                //{
                //    var staff = _userRep.Read(u => u.UserId == req.StaffId.Value && u.Role != "Member").FirstOrDefault();
                //    if (staff == null)
                //    {
                //        res.SetError("Staff not found or invalid role");
                //        return res;
                //    }
                //}

                // 4. Tạo bản ghi BloodRequest
                var request = new BloodRequest
                {
                    UserId = req.UserId,
                    BloodTypeId = req.BloodTypeId,
                    ComponentType = req.ComponentType,
                    Quantity = req.Quantity,
                    RequestDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "Pending",
                    StaffId = req.StaffId
                };

                _rep.Create(request);
            }
            catch (Exception ex)
            {
                res.SetError("Error creating blood request: " + ex.Message);
            }

            return res;
        }

    }
}
