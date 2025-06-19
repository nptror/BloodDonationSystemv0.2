using BDS.BLL.Service;
using BDS.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    public class BloodRequestController : Controller
    {
        private BloodRequestSvc _bloodRequestSvc;
        public BloodRequestController()
        {
            _bloodRequestSvc = new BloodRequestSvc();
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Tạo bản ghi yêu cầu máu mới
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("register-recipient")]
        public IActionResult CreateRegister([FromBody] BloodRequestDTO req)
        {
            var res = _bloodRequestSvc.Create(req);

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
    }
}
