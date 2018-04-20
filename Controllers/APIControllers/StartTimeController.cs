using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class StartTimeController : ApiController
    {
        StartTimeDAL obj = new StartTimeDAL();
        [HttpGet]
        public IEnumerable<StartTimeClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
         public IEnumerable<StartTimeClass> Insert(string StartTime, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(StartTime, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<StartTimeClass> Update(string StartTime, int UpdatedBy, int StartTimeId)
          {
              return obj.Update(StartTime, UpdatedBy, StartTimeId);
          }
        [HttpGet]
        public IEnumerable<StartTimeClass> UpdateStatus(int Status, int UpdatedBy, int StartTimeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, StartTimeId);
        }
        [HttpGet]
        public IEnumerable<StartTimeClass> GetDataById(int StartTimeId)
        {
            return obj.GetDataById(StartTimeId);
        }
    }
}
