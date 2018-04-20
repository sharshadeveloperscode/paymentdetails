using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class SalonImageController : ApiController
    {
        SalonImageDAL obj = new SalonImageDAL();
        [HttpGet]
         public IEnumerable<SalonImageClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
         public IEnumerable<SalonImageClass> GetDatabyId(int SalonImageId)
        {
            return obj.GetDatabyId(SalonImageId);
        }
        [HttpGet]
        public IEnumerable<SalonImageClass> GetDatabySalonId(int SalonId)
        {
            return obj.GetDatabySalonId(SalonId);
        }
        [HttpGet]
        public IEnumerable<SalonImageClass> Insert(string Image, string ImagePath, int SalonsId, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(Image, ImagePath, SalonsId, IsAcitve, CreatedBy);
        }
        [HttpGet]
         public IEnumerable<SalonImageClass> Update(string Image, string ImagePath, int SalonsId, int UpdatedBy, int SalonImageId)
        {
            return obj.Update(Image, ImagePath, SalonsId, UpdatedBy, SalonImageId);
        }
        [HttpGet]
         public IEnumerable<SalonImageClass> Delete(int SalonImageId)
        {
            return obj.Delete(SalonImageId);
        }
        [HttpGet]
        public IEnumerable<SalonImageClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonImageId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, SalonImageId);
        }
    }
}
