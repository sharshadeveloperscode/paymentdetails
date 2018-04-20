using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class MemberTypeController : ApiController
    {
        MemberTypeDAL obj = new MemberTypeDAL();
        [HttpGet]
        public IEnumerable<MemberTypeClass> Getdata()
        {
           return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> GetbyId(int MemberTypeId)
        {
           return obj.GetbyId(MemberTypeId);
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> Insert(string MemberTypeName, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(MemberTypeName, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> Update(string MemberTypeName, int UpdatedBy, int MemberTypeId)
        {
            return obj.Update(MemberTypeName, UpdatedBy, MemberTypeId);
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> Delete(int MemberTypeId)
        {
            return obj.Delete(MemberTypeId);
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> UpdateStatus(int Status, int UpdatedBy, int MemberTypeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, MemberTypeId);
        }
        [HttpGet]
        public IEnumerable<MemberTypeClass> GetdataByIsActive()
        {
            return obj.GetdataByIsActive();
        }
    }
}
