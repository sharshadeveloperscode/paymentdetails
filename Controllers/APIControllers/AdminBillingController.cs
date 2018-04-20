using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class AdminBillingController : ApiController
    {
        AdminBillingDAL obj = new AdminBillingDAL();
        [HttpGet]
        public IEnumerable<AdminBilling> AdminListofBookingsBySearch(string FromDate, string ToDate, int IsActive, int BookingType)
        {
            return obj.AdminListofBookingsBySearch(FromDate, ToDate, IsActive, BookingType);
        }
    }
}
