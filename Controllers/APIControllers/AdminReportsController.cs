using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class AdminReportsController : ApiController
    {
        AdminReportsDAL obj = new AdminReportsDAL();
        [HttpGet]
        public IEnumerable<AdminReportsClass> TodayBookings()
        {
            return obj.TodayBookings();
        }
        [HttpGet]
         public IEnumerable<AdminReportsClass> Bookingcancellations()
        {
            return obj.Bookingcancellations();
        }
        [HttpGet]
        public IEnumerable<AdminReportsClass> OldCustomers()
        {
            return obj.OldCustomers();
        }
        [HttpGet]
        public IEnumerable<AdminReportsClass> MonthlyBookings( string Month, string Year,string Day)
        {
            return obj.MonthlyBookings(Month, Year,Day);
        }
        [HttpGet]
         public IEnumerable<AdminReportsClass> MonthlyBookingcancellations(string Month, string Year,string Day)
        {
            return obj.MonthlyBookingcancellations(Month, Year,Day);
        }
        [HttpGet]
         public IEnumerable<AdminReportsClass> CurrentMonth(string Month)
        {
            return obj.CurrentMonth(Month);
        }
        [HttpGet]
        public IEnumerable<AdminReportsClass> TopServicesBooking()
        {
            return obj.TopServicesBooking();
        }
        [HttpGet]
        public IEnumerable<AdminReportsClass> ConfirmCancelBookings()
        {
            return obj.ConfirmCancelBookings();
        }
        [HttpGet]
         public IEnumerable<AdminReportsClass> NewTopServicesBooking()
        {
            return obj.NewTopServicesBooking();
        }
    }
}
