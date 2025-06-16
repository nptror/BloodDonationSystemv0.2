using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    public class BloodRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
