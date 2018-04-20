using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class SearchController : ApiController
    {
        SearchDAL obj = new SearchDAL();
        [HttpGet]
        public IEnumerable<SearchClass> Search(string PostCode, string TreatmentTitleId, string CheckDate)
        {
            return obj.Search(PostCode, TreatmentTitleId, CheckDate);
        }
        [HttpGet]
        public IEnumerable<SearchClass> SearchBasedonSalonName(string BusinessName)
        {
            return obj.SearchBasedonSalonName(BusinessName);
        }
        [HttpGet]
        public IEnumerable<SearchClass> SearchBasedonCategoryId(int CategoryId)
        {
            return obj.SearchBasedonCategoryId(CategoryId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> SearchBasedonCityId(int CityId)
        {
            return obj.SearchBasedonCityId(CityId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewSalonDetails(string SalonsId, string CheckDate)
        {
            return obj.ViewSalonDetails(SalonsId, CheckDate);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewSalonImages(string SalonsId)
        {
            return obj.ViewSalonImages(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewBookingDetails(string SalonsId, string SalonServicesId,string CheckDate)
        {
            return obj.ViewBookingDetails(SalonsId, SalonServicesId, CheckDate);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewSalonCheckoutDetails(string BookingsId, string CheckDate)
        {
            return obj.ViewSalonCheckoutDetails(BookingsId,CheckDate);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewSalonOpeningHours(string SalonsId)
        {
            return obj.ViewSalonOpeningHours(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewSalonTimings(string SalonsId)
        {
            return obj.ViewSalonTimings(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> EmployeesbasedonSalons(string SalonServicesId)
        {
            return obj.EmployeesbasedonSalons(SalonServicesId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> ViewEmployeeAvailableTimings(int SalonServicesId, int SalonEmployeesId, string Date,int SalonsId)
        {
            return obj.ViewEmployeeAvailableTimings(SalonServicesId, SalonEmployeesId, Date, SalonsId);
        }

        [HttpGet]
        public IEnumerable<SearchClass> FilterSearch(int limit, string PriceRange, string Order, string StartTime, string EndTime, string StartPrice, string EndPrices, string Day, string AreaId, string TreatmentTitleId)
        {
            return obj.FilterSearch(limit, PriceRange, Order, StartTime, EndTime, StartPrice, EndPrices, Day, AreaId, TreatmentTitleId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> SearchBasedonFrontendandIsActive()
        {
            return obj.SearchBasedonFrontendandIsActive();
        }
        [HttpGet]
        public IEnumerable<SearchClass> BindTreatmentType(int SalonsId)
        {
            return obj.BindTreatmentType(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> NewFilterSearch(int limit, string PriceRange, string Order, string StartTime, string EndTime, string Day, string AreaId, string TreatmentTitleId, string StartPrice, string EndPrice)
        {
            return obj.NewFilterSearch(limit, PriceRange, Order, StartTime, EndTime, Day, AreaId, TreatmentTitleId, StartPrice, EndPrice);
        }
        [HttpGet]
        public IEnumerable<SearchClass> NewFilterTreatmentType(int SalonsId, string StartPrice, string TreatmentTitleId, string EndPrices)
        {
            return obj.NewFilterTreatmentType(SalonsId, StartPrice, TreatmentTitleId, EndPrices);
        }
        [HttpGet]
        public IEnumerable<SearchClass> NewFilterSearch1(int limit, string PriceRange, string Order, string StartTime, string EndTime, string Day, string AreaId, string TreatmentTitleId, string StartPrice, string EndPrice)
        {
            return obj.NewFilterSearch1(limit, PriceRange, Order, StartTime, EndTime, Day, AreaId, TreatmentTitleId, StartPrice, EndPrice);
        }
        [HttpGet]
        public IEnumerable<SearchClass> NewFilterTreatmentType1(int SalonsId, string StartPrice, string TreatmentTitleId, string EndPrices)
        {
            return obj.NewFilterTreatmentType1(SalonsId, StartPrice, TreatmentTitleId, EndPrices);
        }
        

        [HttpGet]
        public IEnumerable<SearchClass> SalonRating(int SalonsId)
        {
            return obj.SalonRating(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SearchClass> GetEvoucherOrderSummary(string BookingsId, string CheckDate)
        {
            return obj.GetEvoucherOrderSummary(BookingsId, CheckDate);
        }
    }
}
