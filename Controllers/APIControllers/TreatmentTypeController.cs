using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class TreatmentTypeController : ApiController
    {
        TreatmentTypeDAL obj = new TreatmentTypeDAL();
        [HttpGet]
        public IEnumerable<tblTreatmentType> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> GetDatabyId(int TreatmentTypeId)
        {
            return obj.GetDatabyId(TreatmentTypeId);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> Insert(string TreatmentType, int TreatmentTitleId, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(TreatmentType, TreatmentTitleId, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> Update(string TreatmentType, int TreatmentTitleId, int UpdatedBy, int TreatmentTypeId)
        {
            return obj.Update(TreatmentType, TreatmentTitleId, UpdatedBy, TreatmentTypeId);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> Delete(int TreatmentTypeId)
        {
            return obj.Delete(TreatmentTypeId);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> UpdateStatus(int Status, int UpdatedBy, int TreatmentTypeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, TreatmentTypeId);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> GetbyTreatmentTitleId(int TreatmentTitleId)
        {
            return obj.GetbyTreatmentTitleId(TreatmentTitleId);
        }
        [HttpGet]
        public IEnumerable<tblTreatmentType> GetDatabyIdByIsActive(int TreatmentTypeId)
        {
            return obj.GetDatabyIdByIsActive(TreatmentTypeId);
        }
        public IEnumerable<tblTreatmentType> GetbyTreatmentTitleIdByIsActive(int TreatmentTitleId)
        {
            return obj.GetbyTreatmentTitleIdByIsActive(TreatmentTitleId);
        }
    }
}
