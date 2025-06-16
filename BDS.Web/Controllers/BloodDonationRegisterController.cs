using Microsoft.AspNetCore.Mvc;

namespace BDS.Web.Controllers
{
    public class BloodDonationRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
