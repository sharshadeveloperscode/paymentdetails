using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class SalonServicesController : ApiController
    {
        SalonServicesDAL obj = new SalonServicesDAL();
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetCategorysIsActive(int SalonsId)
        {
            return obj.GetCategorysIsActive(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDiscountsbySalonsId(int SalonsId, int CategoryId)
        {
            return obj.GetDiscountsbySalonsId(SalonsId, CategoryId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDatabyId(int SalonServicesId)
        {
            return obj.GetDatabyId(SalonServicesId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> FeratureServicesbySalonsId(int SalonsId)
        {
            return obj.FeratureServicesbySalonsId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> TreatmentTitlebasedonSalonsId(int SalonsId)
        {
            return obj.TreatmentTitlebasedonSalonsId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDatabySalonsId(int SalonsId)
        {
            return obj.GetDatabySalonsId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDatabySalonsIdIsActive(int SalonsId)
        {
            return obj.GetDatabySalonsIdIsActive(SalonsId);
        }
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<SalonServicesClass> Insert(int SalonsId, int CategoryId, string TreatmentTypeId, int TreatmentTitleId, int PricingTypeId, int DurationId, string Price, string Sale, int CleanUpTime, string Description, int IsAcitve, int CreatedBy, int featuredServices, string ImagePath)
        {
            return obj.Insert(SalonsId, CategoryId, TreatmentTypeId, TreatmentTitleId, PricingTypeId, DurationId, Price, Sale, CleanUpTime, Description, IsAcitve, CreatedBy, featuredServices, ImagePath);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> InsertDiscount(int CategoryId, int SalonsId, string Session, string SessionStart, string SessionEnd, string MonDay, string TuesDay, string WednesDay, string ThursDay, string FriDay, string SaturDay, string SunDay, int IsActive, int CreatedBy)
        {
            return obj.InsertDiscount(CategoryId, SalonsId, Session, SessionStart, SessionEnd, MonDay, TuesDay, WednesDay, ThursDay, FriDay, SaturDay, SunDay, IsActive, CreatedBy);
        }
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<SalonServicesClass> Update(int SalonsId, int CategoryId, string TreatmentTypeId, int TreatmentTitleId, int PricingTypeId, int DurationId, string Price, string Sale, int CleanUpTime, string Description, int UpdatedBy, int featuredServices, int SalonServicesId, string ImagePath)
        {
            return obj.Update(SalonsId, CategoryId, TreatmentTypeId, TreatmentTitleId, PricingTypeId, DurationId, Price, Sale, CleanUpTime, Description, UpdatedBy, featuredServices, SalonServicesId, ImagePath);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> UpdateDiscount(int CategoryId, int SalonsId, string Session, string SessionStart, string SessionEnd, string MonDay, string TuesDay, string WednesDay, string ThursDay, string FriDay, string SaturDay, string SunDay, int IsActive, int UpdatedBy)
        {
            return obj.UpdateDiscount(CategoryId, SalonsId, Session, SessionStart, SessionEnd, MonDay, TuesDay, WednesDay, ThursDay, FriDay, SaturDay, SunDay, IsActive, UpdatedBy);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> Delete(int SalonServicesId)
        {
            return obj.Delete(SalonServicesId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonServicesId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, SalonServicesId);
        }


        [HttpGet]
        public IEnumerable<SalonServicesClass> GetDatabyEmpId(int SalonEmployeesId)
        {
            return obj.GetDatabyEmpId(SalonEmployeesId);
        }


        [HttpGet]
        public IEnumerable<SalonServicesClass> GetUnAssDatabyEmpId(int SalonsId, int SalonEmployeeId)
        {
            return obj.GetUnAssDatabyEmpId(SalonsId, SalonEmployeeId);
        }
        [HttpGet]
        public IEnumerable<SalonServicesClass> UpdateFetureService(int featuredServices, int UpdatedBy, int SalonServicesId)
        {
            return obj.UpdateFetureService(featuredServices, UpdatedBy, SalonServicesId);
        }


        [HttpGet]
        public IEnumerable<Schedular> GetEmployeeBookings(int SalonId)
        {
            return obj.GetEmployeeBookings(SalonId);
        }

        [HttpGet]
        public IEnumerable<Schedular> GetEmployeeServices(int EmployeeId)
        {
            return obj.GetEmployeeServices(EmployeeId);
        }

        [AcceptVerbs("GET", "POST")]
        public string updateEmployeeUnavaialble(string StartDate, string StartTime, string EndDate, string EndTime, int EmployeeId)
        {
            return obj.updateEmployeeUnavaialble(StartDate, StartTime, EndDate, EndTime, EmployeeId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<Schedular> GetEmployeeServicesPrice(int ServiceId)
        {
            return obj.GetEmployeeServicesPrice(ServiceId);
        }

    }
}
