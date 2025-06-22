using BDS.BLL.Service;
using BDS.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    public class BloodDonationRegisterController : Controller
    {
        private BloodDonationRegisterSvc _bloodDonationRegisterScv;
        public BloodDonationRegisterController()
        {

            _bloodDonationRegisterScv = new BloodDonationRegisterSvc();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("register-donation")]
        public IActionResult CreateRegister([FromBody] BloodDonationRegisterDTO req)
        {
            var res = _bloodDonationRegisterScv.Create(req);

            if (!res.Success)
            {
                // Trả lỗi kèm message đã set ở BLL
                return BadRequest(new
                {
                    success = false,
                    message = res.Equals("User not found") ? "Người dùng không tồn tại" : res.Message
                });
            }

            return Ok(new
            {
                success = true,
                data = res.Data
            });
        }
        
         [HttpGet("get-registers/{userId}")]
        public IActionResult GetRegisters(int userId)
        {
            var res = _bloodDonationRegisterScv.ReadById(userId);
            if (res == null || !res.Any())
            {
                return NotFound(new
                {
                    success = false,
                    message = "No donation registers found for this user"
                });
            }
            return Ok(new
            {
                success = true,
                data = res
            });
        }
    }
}
