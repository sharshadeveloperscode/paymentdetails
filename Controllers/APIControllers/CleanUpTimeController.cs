using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class CleanUpTimeController : ApiController
    {
        CleanUpTimeDAL obj = new CleanUpTimeDAL();
        [HttpGet]
        public IEnumerable<CleanUpTimeClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<CleanUpTimeClass> GetbyId(int CleanUpTimeId)
        {
            return obj.GetbyId(CleanUpTimeId);
        }
        [HttpGet]
        public IEnumerable<CleanUpTimeClass> Insert(string CleanUpTime, int IsActive, int CreatedBy)
        {
            return obj.Insert(CleanUpTime, IsActive, CreatedBy);

        }
        [HttpGet]
        public IEnumerable<CleanUpTimeClass> Update(string CleanUpTime, int UpdatedBy, int CleanUpTimeId)
        {
            return obj.Update(CleanUpTime, UpdatedBy, CleanUpTimeId);
        }
        [HttpGet]
        public IEnumerable<CleanUpTimeClass> UpdateStatus(int Status, int UpdatedBy, int CleanUpTimeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, CleanUpTimeId);
        }
    }
}
