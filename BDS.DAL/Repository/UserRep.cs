using BDS.Common.DAL;
using BDS.DAL.Data;
using BDS.DAL.Models;

namespace BDS.DAL.Repository
{
    public class UserRep : GenericRep<BloodDonationDbContext,User>
    {
        public UserRep()
        {
            // Constructor logic if needed
        }


        //Trả về User (đúng như tên hàm ReadById)
        public override User ReadById(int id)
        {
            var user = GetAll.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        //Trả về SingleRsp(nếu muốn trả cả thông báo lỗi)
        //public override SingleRsp ReadById(int id)
        //{
        //    var res = new SingleRsp();

        //    var user = GetAll.FirstOrDefault(u => u.UserId == id);

        //    if (user != null)
        //    {
        //        res.Data = user;
        //    }
        //    else
        //    {
        //        res.SetError("User not found");
        //    }

        //    return res;
        //}


    }
}
