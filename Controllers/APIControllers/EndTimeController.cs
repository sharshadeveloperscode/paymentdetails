using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class EndTimeController : ApiController
    {
        EndTimeDAL obj = new EndTimeDAL();
        [HttpGet]
         public IEnumerable<EmdTimeClass> GetData()
         {
            return  obj.GetData();
         }
        [HttpGet]
        public IEnumerable<EmdTimeClass> Insert(string EndTime, int IsActive, int CreatedBy)
         {
             return obj.Insert(EndTime, IsActive, CreatedBy);
         }
        [HttpGet]
         public IEnumerable<EmdTimeClass> Update(string EndTime, int UpdatedBy, int EndTimeId)
         {
             return obj.Update(EndTime, UpdatedBy, EndTimeId);
         }
        [HttpGet]
        public IEnumerable<EmdTimeClass> UpdateStatus(int Status, int UpdatedBy, int EndTimeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, EndTimeId);
        }
        [HttpGet]
        public IEnumerable<EmdTimeClass> GetDataById(int EndTimeId)
        {
            return obj.GetDataById(EndTimeId);
        }
    }
}
