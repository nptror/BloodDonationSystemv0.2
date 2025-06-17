using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDS.Common.Helpers
{
    public class Validations
    {
        public static bool IsValidPhone(string phoneNumber)
        {
            // xác thực các đầu số việt nam
            var validPhone = new Regex(@"^0(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-6|8|9]|9[0-9])\d{7}$");
            return validPhone.IsMatch(phoneNumber);
        }

        public static bool IsStrongPassword(string password)
        {   
            // kiểm tra mật khẩu mạnh
            var strongPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$%^@$!%*?&])[A-Za-z\d#$%^@$!%*?&]{8,}$");
            return strongPassword.IsMatch(password);
        }
    }
}
