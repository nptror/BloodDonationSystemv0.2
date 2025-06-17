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
            var validPhone = new Regex(@"^(0|84)(2(0[3-9]|1[0-689]|2[0-25-9]|3[2-9]|4[0-9]|5[124-9]|6[0369]|7[0-7]|8[0-9]|9[012346789])|3[2-9]|5[25689]|7[06-9]|8[0-9]|9[012346789])([0-9]{7})$");
            return validPhone.IsMatch(phoneNumber);
        }

        public static bool IsStrongPassword(string password)
        {
            var strongPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            return strongPassword.IsMatch(password);
        }
    }
}
