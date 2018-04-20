using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class PricingTypeController : ApiController
    {
        PricingTypeDAL obj = new PricingTypeDAL();
        [HttpGet]
        public IEnumerable<PricingTypeClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<PricingTypeClass> GetbyId(int PricingTypeId)
        {
            return obj.GetbyId(PricingTypeId);
        }
        [HttpGet]
        public IEnumerable<PricingTypeClass> Insert(string PricingType, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(PricingType, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<PricingTypeClass> Update(string PricingType, int UpdatedBy, int PricingTypeId)
        {
            return obj.Update(PricingType, UpdatedBy, PricingTypeId);
        }
        [HttpGet]
        public IEnumerable<PricingTypeClass> UpdateStatus(int Status, int UpdatedBy, int PricingTypeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, PricingTypeId);
        }
    }
}
