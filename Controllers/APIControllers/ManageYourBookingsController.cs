using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class ManageYourBookingsController : ApiController
    {
        ManageYourBookingsDAL obj = new ManageYourBookingsDAL();
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> Getdata()
        {
            return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> GetbyId(int BookingsId)
        {
            return obj.GetbyId(BookingsId);
        }
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> Insert(string BookingsName, int IsActive, int CreatedBy)
        {
            return obj.Insert(BookingsName, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> Update(string BookingsName, int UpdatedBy, int BookingsId)
        {
            return obj.Update(BookingsName, UpdatedBy, BookingsId);
        }
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> Delete(int BookingsId)
        {
            return obj.Delete(BookingsId);
        }
        [HttpGet]
        public IEnumerable<ManageYourBookingsClass> UpdateStatus(int Status, int UpdatedBy, int BookingsId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, BookingsId);
        }
    }
}
