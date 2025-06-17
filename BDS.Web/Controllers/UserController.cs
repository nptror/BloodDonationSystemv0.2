using BDS.BLL.Service;
using BDS.Common.Request;
using BDS.Common.Response;
using BDS.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    public class UserController : Controller
    {
        private UserSvc _UserSvc;
        public IActionResult Index()
        {
            return View();
        }

        public UserController()
        {
            _UserSvc = new UserSvc();
        }

        [HttpPost("GetById")]
        public IActionResult GetById([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = _UserSvc.ReadById(simpleReq.Id);
            return Ok(res);
        }

        // đăng kí
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegisterReq req)
        {
            var rsp = _UserSvc.Register(req);
            if (!rsp.Success) return BadRequest(rsp);
            return Ok(rsp);
        }

        // đăng nhập
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginReq req)
        {
            var rsp = _UserSvc.Login(req);
            if (!rsp.Success) return BadRequest(rsp);
            // lưu userId vào session
            HttpContext.Session.SetString("UserId", rsp.Data.ToString());
            return Ok(rsp);
        }

        //đăng xuất
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // xóa userId khỏi session
            HttpContext.Session.Remove("UserId");
            return Ok(new { messgae = " Logged out successfully" });

        }
    }
}
