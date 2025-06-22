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
       
        
        
    }
}
