using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    
    public class CityController : ApiController
    {
        CityDAL obj = new CityDAL();
        [HttpGet]
        public IEnumerable<CityClass> Getdata()
        {
           return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<CityClass> GetbyId(int id)
        {
            return obj.GetbyId(id);
        }
        [HttpGet]
        public IEnumerable<CityClass> Insert(string CityName,int IsActive,int CreatedBy)
        {
           return obj.Insert(CityName, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<CityClass> Update(string CityName,int UpdatedBy,int Cityid)
        {
           return obj.Update(CityName, UpdatedBy, Cityid);
        }
        [HttpGet]
        public IEnumerable<CityClass> Delete(int id)
        {
           return obj.Delete(id);
        }
        [HttpGet]
        public IEnumerable<CityClass> UpdateStatus(int Status, int UpdatedBy, int CityId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, CityId);
        }
        [HttpGet]
        public IEnumerable<CityClass> GetdataByIsActive()
        {
            return obj.GetdataByIsActive();
        }
    }
}
