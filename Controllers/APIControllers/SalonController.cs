using System.Collections.Generic;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers.APIControllers
{
    public class SalonController : ApiController
    {
        SalonDAL obj = new SalonDAL();
        [HttpGet]
        public IEnumerable<SalonAPI.Models.SalonDAL.salonAutoService> GetAutoServicesData(string servicename)
        {
            return obj.GetAutoServicesData(servicename);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.SalonDAL.HairSalonDetails> GetSalonsList(string servicename)
        {
           return obj.GetSalonsList(servicename);
        }

      

    }
}
