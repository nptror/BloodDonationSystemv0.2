using BDS.BLL.Service;
using BDS.Common.Request;
using BDS.Common.Response;
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
    }
    
}
