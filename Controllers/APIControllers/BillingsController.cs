using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class BillingsController : ApiController
    {
        BillingsDAL obj = new BillingsDAL();
        [HttpGet]
        public IEnumerable<BillingsClass> ListofBookings()
        {
            return obj.ListofBookings();
        }
        [HttpGet]
         public IEnumerable<BillingsClass> ListofBookingsbasedonSalonsId(int SalonsId)
        {
            return obj.ListofBookingsbasedonSalonsId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<BillingsClass> ListofBookingsDateRange(int SalonsId, string FromDate, string ToDate,int IsActive)
        {
            return obj.ListofBookingsDateRange(SalonsId, FromDate, ToDate, IsActive);
        }
        [HttpGet]
        public IEnumerable<BillingsClass> ListofBookings1(int SalonCheckoutId)
        {
            return obj.ListofBookings1(SalonCheckoutId);
        }
        public IEnumerable<BillingsClass> GetNoShowDetails()
        {
            return obj.GetNoShowDetails();
        }
        public IEnumerable<BillingsClass> GetCompleteDetails()
        {
            return obj.GetCompleteDetails();
        }
        [HttpGet]
        public IEnumerable<BillingsClass> GetCancelOrderDetails()
        {
            return obj.GetCancelOrderDetails();
        }

        [HttpGet]
        public IEnumerable<BillingsClass> GetCompleteDetailsBasedOnSalonsId(int SalonsId,int IsActive)
        {
            return obj.GetCompleteDetailsBasedOnSalonsId(SalonsId,IsActive);
        }

        [HttpGet]
        public IEnumerable<BillingsClass> ListofBookingsBySearch(int SalonsId, string FromDate, string ToDate, int IsActive, int BookingType)
        {
            return obj.ListofBookingsBySearch(SalonsId,FromDate,ToDate,IsActive,BookingType);
        }

        [HttpGet]
        public IEnumerable<BillingsClass> EvocuherBookingsList(int SalonCheckoutId)
        {
            return obj.EvocuherBookingsList(SalonCheckoutId);
        }

        [HttpGet]
        public string UpdateBookingStatus(string BookingDate, string BookingTime, string SalonCheckoutId,int EmployeeServicesId)
        {
            return obj.UpdateBookingStatus(BookingDate,BookingTime,SalonCheckoutId, EmployeeServicesId);
        }
    }
}
