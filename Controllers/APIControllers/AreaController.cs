using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class AreaController : ApiController
    {
        AreaDAL obj = new AreaDAL();
        [HttpGet]
        public IEnumerable<Areaclass> GetData()
        {
           return  obj.GetData();
        }
        [HttpGet]
        public IEnumerable<Areaclass> GetPostCodes()
        {
            return obj.GetPostCodes();
        }
        [HttpGet]
        public IEnumerable<Areaclass> GetDatabyId(int Areaid)
        {
            return obj.GetDatabyId(Areaid);
        }
        [HttpGet]
        public IEnumerable<Areaclass> Insert(string AreaName, int CityId, int IsAcitve, int CreatedBy,string PostCode)
        {
            return obj.Insert(AreaName, CityId, IsAcitve, CreatedBy, PostCode);
        }
        [HttpGet]
        public IEnumerable<Areaclass> Update(string AreaName, int CityId, int UpdatedBy, string PostCode, int AreaId)
        {
          return obj.Update(AreaName, CityId, UpdatedBy, PostCode, AreaId);
        }
        [HttpGet]
        public IEnumerable<Areaclass> Delete(int  AreaId)
        {
            return obj.Delete(AreaId);
        }
        [HttpGet]
        public IEnumerable<Areaclass> UpdateStatus(int Status, int UpdatedBy, int AreaId)
        {
           return obj.UpdateStatus(Status, UpdatedBy, AreaId);
        }
        [HttpGet]
        public IEnumerable<Areaclass> GetDatabyCityId(int CityId)
        {
            return obj.GetDatabyCityId(CityId);
        }
        [HttpGet]
        public IEnumerable<Areaclass> GetDataByIsActive()
        {
            return obj.GetDataByIsActive();
        }
        [HttpGet]
        public IEnumerable<Areaclass> GetDatabyCityIdByIsActive(int CityId)
        {
            return obj.GetDatabyCityIdByIsActive(CityId);
        }
    }
}
