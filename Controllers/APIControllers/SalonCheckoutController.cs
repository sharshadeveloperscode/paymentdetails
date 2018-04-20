using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class SalonCheckoutController : ApiController
    {
        SalonCheckoutDAL obj = new SalonCheckoutDAL();
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> GetbyId(int SalonCheckoutId)
        {
            return obj.GetbyId(SalonCheckoutId);
        }
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> Insert(int EmployeeServicesId, string BookingDate, string BookingTime, string PaymentStatus, string PaymentType, int IsAcitve, string CreatedDate)
        {
            return obj.Insert(EmployeeServicesId, BookingDate, BookingTime, PaymentStatus, PaymentType, IsAcitve, CreatedDate);
        }
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> InsertNew(int EmployeeServicesId, string BookingDate, string BookingTime, string PaymentStatus, string PaymentType, int IsAcitve, string CreatedDate)
        {
            return obj.InsertNew(EmployeeServicesId, BookingDate, BookingTime, PaymentStatus, PaymentType, IsAcitve, CreatedDate);
        }
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> InsertNew1(string EmployeeServicesId, string BookingDate, string BookingTime, string PaymentStatus, string PaymentType, int IsAcitve, string CreatedDate, int SalonsId, string SalonServicesId,string BookingType)
        {
            return obj.InsertNew1(EmployeeServicesId, BookingDate, BookingTime, PaymentStatus, PaymentType, IsAcitve, CreatedDate, SalonsId, SalonServicesId, BookingType);
        }
        [HttpGet]
        public IEnumerable<SalonCheckoutClass> Update( string PaymentStatus, string PaymentType, int PaymentsId, int UpdatedBy, string UpdatedDate, int SalonCheckoutId)
        {
            return obj.Update( PaymentStatus, PaymentType, PaymentsId, UpdatedBy, UpdatedDate, SalonCheckoutId);
        }

        [HttpGet]
        public IEnumerable<SalonCheckoutClass> UpdateStatus(int Status, int UpdatedBy, int SalonCheckoutId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, SalonCheckoutId);
        }
    }
}
