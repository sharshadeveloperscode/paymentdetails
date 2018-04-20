using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class SigningController : ApiController
    {
        SigningDAL obj = new SigningDAL();
        [HttpGet]
        public IEnumerable<SigningClass> Getdata()
        {
            return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<SigningClass> GetbyId(int SigningupId)
        {
            return obj.GetbyId(SigningupId);
        }
        [HttpGet]
        public IEnumerable<SigningClass> Insert(string SigningupName, int IsActive, int CreatedBy)
        {
            return obj.Insert(SigningupName, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<SigningClass> Update(string SigningupName, int UpdatedBy, int SigningupId)
        {
            return obj.Update(SigningupName, UpdatedBy, SigningupId);
        }
        [HttpGet]
        public IEnumerable<SigningClass> Delete(int SigningupId)
        {
            return obj.Delete(SigningupId);
        }
        [HttpGet]
        public IEnumerable<SigningClass> UpdateStatus(int Status, int UpdatedBy, int SigningupId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, SigningupId);
        }
    }
}
