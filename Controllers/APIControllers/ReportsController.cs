using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class ReportsController : ApiController
    {
        ReportsDAL obj = new ReportsDAL();
     
        [HttpGet]
        public IEnumerable<ReportsClass> TodayBookings(int SalonsId)
        {
            return obj.TodayBookings(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> ActualBooking(int SalonsId)
        {
            return obj.ActualBooking(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> CurrentMonthSalesByEmployee(int SalonsId)
        {
            return obj.CurrentMonthSalesByEmployee(SalonsId);
        }
        [HttpGet]
         public IEnumerable<ReportsClass> MonthlyBookings(int SalonsId, string Month, string Year)
        {
            return obj.MonthlyBookings(SalonsId, Month, Year);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> Bookingcancellations(int SalonsId)
        {
            return obj.Bookingcancellations(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> MonthlySalonsIncome()
        {
            return obj.MonthlySalonsIncome();
        }
        [HttpGet]
        public IEnumerable<ReportsClass> OldCustomers(int SalonsId)
        {
            return obj.OldCustomers(SalonsId);
        }
        [HttpGet]
       public IEnumerable<ReportsClass> SalonConfirmCancelBookings(int SalonsId)
        {
            return obj.SalonConfirmCancelBookings(SalonsId);
        }
        [HttpGet]
         public IEnumerable<ReportsClass> SalonTopServicesBooking(int SalonsId)
        {
            return obj.SalonTopServicesBooking(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReports(int SalonsId)
        {
            return obj.SalesReports(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsBasedonDate(string Fromdate, string Todate, int SalonsId)
        {
            return obj.SalesReportsBasedonDate(Fromdate, Todate, SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsByEmployee(int SalonsId)
        {
            return obj.SalesReportsByEmployee(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsByEmployeeBasedonDate(string Fromdate, string Todate, int SalonsId)
        {
            return obj.SalesReportsByEmployeeBasedonDate(Fromdate, Todate, SalonsId);
        }






        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsYesterday(int SalonsId)
        {
            return obj.SalesReportsYesterday(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsLast7Days(int SalonsId)
        {
            return obj.SalesReportsLast7Days(SalonsId);
        }
       
        [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsByEmployeeYesterday(int SalonsId)
        {
            return obj.SalesReportsByEmployeeYesterday(SalonsId);
        }
       [HttpGet]
        public IEnumerable<ReportsClass> SalesReportsByEmployeeLast7Days(int SalonsId)
        {
            return obj.SalesReportsByEmployeeLast7Days(SalonsId);
        }
    }
}
