using BDS.BLL.Service;
using BDS.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BloodDonationRegisterController : ControllerBase
    {
        private BloodDonationRegisterSvc _bloodDonationRegisterScv;
        public BloodDonationRegisterController()
        {

            _bloodDonationRegisterScv = new BloodDonationRegisterSvc();
        }


        /// <summary>
        /// Tạo bản ghi đăng ký hiến máu mới
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lấy danh sách các bản ghi đăng ký hiến máu của người dùng theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("get-registers/{userId}")]
        public IActionResult GetRegisters(int userId)
        {
            var res = _bloodDonationRegisterScv.Read(userId);
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

        /// <summary>
        /// Lấy thông tin bản ghi đăng ký hiến máu theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("get-register/{userId}")]
        public IActionResult GetRegisterById(int userId)
        {
            var res = _bloodDonationRegisterScv.ReadById(userId);
            if (res == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No donation register found for this user"
                });
            }
            return Ok(new
            {
                success = true,
                data = res
            });
        }

        /// <summary>
        /// Xoá bản ghi đăng ký hiến máu theo RegisterId
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [HttpDelete("delete-register/{registerId}")]
        public IActionResult DeleteRegister(int registerId)
        {
            var res = _bloodDonationRegisterScv.Delete(registerId);
            if (!res.Success)
            {
                return NotFound(new
                {
                    success = false,
                    message = res.Message
                });
            }
            return Ok(new
            {
                success = true,
                message = "Donation register deleted successfully"
            });
        }


        /// <summary>
        /// USER Cập nhật thông tin bản ghi đăng ký hiến máu
        ///  STAFF cập nhật trạng thái đơn đăng ký hiến máu
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("update-register")]
        public IActionResult UpdateRegister([FromBody] BloodDonationRegisterDTO req)
        {
            var res = _bloodDonationRegisterScv.Update(req);
            if (!res.Success)
            {
                return BadRequest(new
                {
                    success = false,
                    message = res.Message
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
