using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class TreatmentTitleController : ApiController
    {
        TreatmentTitleDAL obj = new TreatmentTitleDAL();
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetDatabyId(int TreatmentTitleId)
        {
            return obj.GetDatabyId(TreatmentTitleId);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> Insert(string TreatmentTitle, int CategoryId, int IsAcitve, int CreatedBy, string ImageName = null, string ImagePath = null)
        {
            return obj.Insert(TreatmentTitle, CategoryId, IsAcitve, CreatedBy, ImageName, ImagePath);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> Update(string TreatmentTitle, int CategoryId, int UpdatedBy, int TreatmentTitleId, string ImageName = null, string ImagePath = null)
        {
            return obj.Update(TreatmentTitle, CategoryId, UpdatedBy, TreatmentTitleId, ImageName, ImagePath);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> Delete(int TreatmentTitleId)
        {
            return obj.Delete(TreatmentTitleId);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> UpdateStatus(int Status, int UpdatedBy, int TreatmentTitleId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, TreatmentTitleId);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetbyCategoryId(int CategoryId)
        {
            return obj.GetbyCategoryId(CategoryId);
        }        
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetTreatmentTitlebyCategoryId(int CategoryId)
        {
            return obj.GetTreatmentTitlebyCategoryId(CategoryId);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetbyCategoryIdByIsActvive(int CategoryId)
        {
            return obj.GetbyCategoryIdByIsActvive(CategoryId);
        }
        [HttpGet]
        public IEnumerable<TreatmentTitleClass> GetDataIsActive()
        {
            return obj.GetDataIsActive();
        }
    }
}
