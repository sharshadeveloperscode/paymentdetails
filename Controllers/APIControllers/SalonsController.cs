using SalonAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using static SalonAPI.Models.SalonsDAL;

namespace SalonAPI.Controllers
{
    public class SalonsController : ApiController
    {
        SalonsDAL obj = new SalonsDAL();

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblSalons> InsertSalons(string BusinessName, string Address, string Name, string PostalCode, int MemberTypeId, string Note, string PhoneNumber, string Email, string Password, int BusinessType, int CityId, int AreaId, int CountryId, int ManageYourBookings, int ReasonForSigningUp, string Website, string GoogleMaps, string Image, string ImagePath, int CreatedBy, int FrontendStatus, int Noofchairs, int Popularity,int ClassId)
        {
            return obj.InsertSalons(BusinessName, Address, Name, PostalCode, MemberTypeId, Note, PhoneNumber, Email, Password, BusinessType, CityId, AreaId, CountryId, ManageYourBookings, ReasonForSigningUp, Website, GoogleMaps, Image, ImagePath, CreatedBy, FrontendStatus, Noofchairs, Popularity, ClassId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblSalons> UpdateSalons(string BusinessName, string Address, string Name, string PostalCode, int MemberTypeId, string Note, string PhoneNumber, string Email, string Password, int BusinessType, int CityId, int AreaId, int CountryId, int ManageYourBookings, int ReasonForSigningUp, string Website, string GoogleMaps, string Image, string ImagePath, int UpdatedBy, int FrontendStatus, int SalonsId, int Noofchairs, int Available, int Popularity,int ClassId)
        {
            return obj.UpdateSalons(BusinessName, Address, Name, PostalCode, MemberTypeId, Note, PhoneNumber, Email, Password, BusinessType, CityId, AreaId, CountryId, ManageYourBookings, ReasonForSigningUp, Website, GoogleMaps, Image, ImagePath, UpdatedBy, FrontendStatus, SalonsId, Noofchairs, Available, Popularity, ClassId);
        }

        [HttpGet]
        public IEnumerable<tblSalons> DeleteSalons(int SalonsId)
        {
            return obj.DeleteSalons(SalonsId);
        }

        [HttpGet]
        public IEnumerable<tblSalons> GetSalonsId(int SalonsId)
        {
            return obj.GetSalonsId(SalonsId);
        }

        [HttpGet]
        public IEnumerable<tblSalons> GetByUserId(int UserId)
        {
            return obj.GetByUserId(UserId);
        }


        [HttpGet]
        public IEnumerable<tblSalons> GetSalons()
        {
            return obj.GetSalons();
        }


        [HttpGet]
        public IEnumerable<tblSalons> UpdateStatus(int Status, int UpdatedBy, int SalonsId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, SalonsId);
        }

        [HttpGet]
        public IEnumerable<tblSalons> GetSalonIdByUserId(int UserId)
        {
            return obj.GetSalonIdByUserId(UserId);
        }

        [HttpGet]
        public IEnumerable<tblSalons> GetActiveSalons()
        {
            return obj.GetActiveSalons();
        }

        [HttpGet]
        public string UpdatePopularity(int Popularity, int UpdatedBy, int PopularityId,int Limit) => obj.UpdatePopularity(Popularity, UpdatedBy, PopularityId, Limit);

        [HttpGet]
        public IEnumerable<tblSalons> GetSalonsBySearch(int Id, string Type) => obj.GetSalonsBySearch(Id, Type);

        [HttpGet]
        public IEnumerable<tblSalons> GetPopularSalons()
        {
            return obj.GetPopularSalons();
        }

        [HttpGet]
        public IEnumerable<tblSalons> GetSalonsByFilter(string StartPrice, string EndPrice, string Date, string Chairs, string City, string Class)
        {
            return obj.GetSalonsByFilter(StartPrice,EndPrice,Date,Chairs,City,Class);
        }

    }
}
