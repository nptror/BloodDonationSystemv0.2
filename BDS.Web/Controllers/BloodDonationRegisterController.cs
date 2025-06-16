using BDS.BLL;
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

        
    }
}
