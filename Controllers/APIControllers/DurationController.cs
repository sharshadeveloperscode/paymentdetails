using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class DurationController : ApiController
    {
        DurationDAL obj = new DurationDAL();
        [HttpGet]
        public IEnumerable<DurationClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<DurationClass> GetbyId(int DurationId)
        {
            return obj.GetbyId(DurationId);
        }
        [HttpGet]
        public IEnumerable<DurationClass> Insert(string Duration, int IsActive, int CreatedBy)
        {
            return obj.Insert(Duration, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<DurationClass> Update(string Duration, int UpdatedBy, int DurationId)
        {
            return obj.Update(Duration, UpdatedBy, DurationId);
        }
        [HttpGet]
        public IEnumerable<DurationClass> UpdateStatus(int Status, int UpdatedBy, int DurationId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, DurationId);
        }
    }
}
