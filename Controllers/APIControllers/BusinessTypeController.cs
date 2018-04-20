using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class BusinessTypeController : ApiController
    {
        BusinessTypeDAL obj = new BusinessTypeDAL();
        [HttpGet]
        public IEnumerable<BusinessTypeClass> Getdata()
        {
            return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> GetbyId(int BusinessTypeId)
        {
            return obj.GetbyId(BusinessTypeId);
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> Insert(string BusinessTypeName, int IsActive, int CreatedBy)
        {
            return obj.Insert(BusinessTypeName, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> Update(string BusinessTypeName, int UpdatedBy, int BusinessTypeId)
        {
            return obj.Update(BusinessTypeName, UpdatedBy, BusinessTypeId);
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> Delete(int BusinessTypeId)
        {
            return obj.Delete(BusinessTypeId);
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> UpdateStatus(int Status, int UpdatedBy, int BusinessTypeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, BusinessTypeId);
        }
        [HttpGet]
        public IEnumerable<BusinessTypeClass> GetdataByIsActive()
        {
            return obj.GetdataByIsActive();
        }
    }
}
