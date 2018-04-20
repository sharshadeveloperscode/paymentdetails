using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Salon.Models;
using SalonAPI.Models;

namespace Salon.Controllers.APIControllers
{
    public class FavouriteSalonServiceController : ApiController
    {
        FavouriteSalonServiceDAL obj = new FavouriteSalonServiceDAL();

        [AcceptVerbs("GET", "POST")]
        public string AddServicestoFavourites(string SalonServicesId, string UserId)
        {
            return obj.AddServicestoFavourites(SalonServicesId, UserId);
        }
        [AcceptVerbs("GET", "POST")]
        public string RemoveServicefromFavourite(string SalonServicesId, string UserId)
        {
            return obj.RemoveServicefromFavourite(SalonServicesId, UserId);
        }
        [AcceptVerbs("GET", "POST")]
        public List<tblFavouriteSalonService> GetSalonServicesByUserId(string UserId)
        {
            return obj.GetSalonServicesByUserId(UserId);
        }
        [AcceptVerbs("GET", "POST")]
        public string AddServiceToCart(int SalonServicesId, int UserId, int SalonsId)
        {
            return obj.AddServiceToCart(SalonServicesId, UserId, SalonsId);
        }

        [AcceptVerbs("GET", "POST")]
        public string AddServiceToCart(int SalonServicesId, int UserId, int SalonsId, DateTime BookingDate, string BookingTime, int Chairs = 0, int EmployeeServicesId = 0)
        {
            return obj.AddServiceToCart(SalonServicesId, UserId, SalonsId, BookingDate, BookingTime, Chairs, EmployeeServicesId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServiceFromCart(int CartId)
        {
            return obj.DeleteServiceFromCart(CartId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServiceFromCart(int UserId, int SalonsId)
        {
            return obj.DeleteServiceFromCart(UserId, SalonsId);
        }

        [AcceptVerbs("GET", "POST")]
        public List<tblFavouriteSalonService> GetCartServices(string UserId)
        {
            return obj.GetCartServices(UserId);
        }

        [AcceptVerbs("GET", "POST")]
        public List<tblFavouriteSalonService> GetCartServices(string UserId, string SalonsId)
        {
            return obj.GetCartServices(UserId, SalonsId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServicesFromCartByUserId(int UserId)
        {
            return obj.DeleteServicesFromCartByUserId(UserId);
        }


        [AcceptVerbs("GET", "POST")]
        public string AddServiceToSaveForLater(int SalonServicesId, int UserId, int SalonsId, int CartId)
        {
            return obj.AddServiceToSaveForLater(SalonServicesId, UserId, SalonsId, CartId);
        }

        [AcceptVerbs("GET", "POST")]
        public string AddServiceToSaveForLater(int SalonServicesId, int UserId, int SalonsId, int CartId, DateTime BookingDate, string BookingTime, int Chairs=0, int EmployeeServicesId = 0)
        {
            return obj.AddServiceToSaveForLater(SalonServicesId, UserId, SalonsId, CartId, BookingDate, BookingTime, Chairs, EmployeeServicesId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServiceFromSaveForLater(int SaveForLaterId)
        {
            return obj.DeleteServiceFromSaveForLater(SaveForLaterId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServiceFromSaveForLater(int UserId, int SalonsId)
        {
            return obj.DeleteServiceFromSaveForLater(UserId, SalonsId);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteServicesFromSaveForLaterByUserId(int UserId)
        {
            return obj.DeleteServicesFromSaveForLaterByUserId(UserId);
        }

        [AcceptVerbs("GET", "POST")]
        public List<tblFavouriteSalonService> GetSaveForLaterServices(string UserId)
        {
            return obj.GetSaveForLaterServices(UserId);
        }

    }
}
