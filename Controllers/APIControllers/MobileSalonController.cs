using SalonAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using static SalonAPI.Models.MobileSalonDAL;

namespace SalonAPI.Controllers
{
    public class MobileSalonController : ApiController
    {
        MobileSalonDAL obj = new MobileSalonDAL();

        [HttpGet]
        public IEnumerable<SalonsDAL.tblSalons> GetActiveSalons(int? UserId = null)
        {
            return obj.GetActiveSalons(UserId);
        }

        [HttpGet]
        public IEnumerable<SalonsDAL.tblSalons> GetSalonsbyTreatmentTitle(int? TreatmentTitle = null, int? UserId = null)
        {
            return obj.GetSalonsbyTreatmentTitle(TreatmentTitle, UserId);
        }

        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDatabySalonsIdIsActive(int SalonsId, int UserId)
        {
            return obj.GetDatabySalonsIdIsActive(SalonsId, UserId);
        }
    }
}