using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class BusinessHoursController : ApiController
    {
        BusinessHoursDAL obj = new BusinessHoursDAL();
        [HttpGet]
        public IEnumerable<BusinessHoursClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
         public IEnumerable<BusinessHoursClass> GetDatabyId(int BusinessHoursId)
        {
            return obj.GetDatabyId(BusinessHoursId);
        }
        [HttpGet]
         public IEnumerable<BusinessHoursClass> Insert(int SalonsId, string Day, int OpeningHours, int ClosingHours, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(SalonsId, Day, OpeningHours, ClosingHours, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<BusinessHoursClass> Update(int SalonsId, string Day, int OpeningHours, int ClosingHours,int IsActive, int UpdatedBy, int BusinessHoursId)
        {
            return obj.Update(SalonsId, Day, OpeningHours, ClosingHours, IsActive,UpdatedBy, BusinessHoursId);
        }
        [HttpGet]
        public IEnumerable<BusinessHoursClass> Delete(int BusinessHoursId)
        {
            return obj.Delete(BusinessHoursId);
        }
        [HttpGet]
         public IEnumerable<BusinessHoursClass> UpdateStatus(int IsActive, int UpdatedBy, int BusinessHoursId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, BusinessHoursId);
        }
        [HttpGet]
        public IEnumerable<BusinessHoursClass> GetDatabySalonId(int SalonsId)
        {
           return obj.GetDatabySalonId(SalonsId);
        }
        [HttpGet]
        public DateTime GetServerDateTime()
        {
            return obj.GetServerDateTime();
        }

        }
}
