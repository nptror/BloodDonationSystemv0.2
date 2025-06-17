using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDS.Common.BLL;
using BDS.Common.Helpers;
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

        // đăng kí
        public SingleRsp Register(UserRegisterReq req)
        {
            var rsp = new SingleRsp();
            try
            {
                if (string.IsNullOrWhiteSpace(req.PhoneNumber) || !Validations.IsValidPhone(req.PhoneNumber))
                {
                    rsp.SetError("Invalid phone number format");
                    return rsp;
                }
                
                if (string.IsNullOrWhiteSpace(req.Password) || !Validations.IsStrongPassword(req.Password))
                {
                    rsp.SetError("Password must be at least 8 characters long, contain uppercase, lowercase, number, and special character");
                    return rsp;
                }

                if (string.IsNullOrEmpty(req.FullName))
                {
                    rsp.SetError("Full name is required");
                    return rsp;
                }

                // kiểm tra số điện thoại đã tổn tại (= linq)
                if (_userRep.GetAll.Any(u => u.PhoneNumber == req.PhoneNumber))
                {
                    rsp.SetError("Phone number already exists");
                    return rsp;
                }

                // tạo user mới nếu hợp lệ 
                var user = new User
                {
                    FullName = req.FullName,
                    PhoneNumber = req.PhoneNumber,
                    Password = req.Password, 
                    Role = "Member" // role mặc định là member
                };

                _userRep.Create(user);
                rsp.SetMessage("User registered successfully");
                return rsp;
            }
            catch (Exception ex)
            {
                rsp.SetError($"An error occurred while registering the user: {ex.Message}");
                return rsp;
            }
        }

        // đăng nhập
        public SingleRsp Login(UserLoginReq rep)
        {
            var rsp = new SingleRsp();
            try
            {
                if (string.IsNullOrWhiteSpace(rep.PhoneNumber) || string.IsNullOrWhiteSpace(rep.Password))
                {
                    rsp.SetError("Phone number and password are required");
                    return rsp;
                }
                // kiểm tra số điện thoại có tồn tại trong hệ thống hay không
                var user = _userRep.GetAll.FirstOrDefault(u => u.PhoneNumber == rep.PhoneNumber);
                if (user == null)
                {
                    rsp.SetError("User not found");
                    return rsp;
                }
                rsp.SetMessage("Login successful");
                // trả về thông tin người dùng nếu đăng nhập thành công
                rsp.Data = new { user.UserId, user.FullName, user.Role };
                return rsp;

            }
            catch (Exception ex)
            {
                rsp.SetError($"An error occurred during login: {ex.Message}");
                return rsp;
            }
        }

    }
}