using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDS.Common.BLL;
using BDS.Common.Response;
using BDS.DAL.Models;
using BDS.DAL.Repository;

namespace BDS.BLL.Service
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep _userRep;

        public UserSvc()
        {
            _userRep = new UserRep();
        }

        public override SingleRsp ReadById(int id)
        {
            var res = new SingleRsp();
            res.Data = _userRep.ReadById(id);
            return res;
            //var res = new SingleRsp();
            //var user = _userRep.ReadById(id);
            //if (user != null)
            //{
            //    res.Data = user;
            //}
            //else
            //{
            //    res.SetError("User not found");
            //}

        }

    }
}
