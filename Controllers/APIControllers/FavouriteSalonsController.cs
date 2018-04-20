using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
using Salon.Models;

namespace Salon.Controllers.APIControllers
{
    public class FavouriteSalonsController : ApiController
    {
        FavouriteSalonsDAL obj = new FavouriteSalonsDAL();
        [AcceptVerbs("GET","POST")]
        public string AddSalontoFavourite(string SalonId, string UserId)
        {
            return obj.AddSalontoFavourite(SalonId, UserId);
        }
        [AcceptVerbs("GET","POST")]
        public string RemoveSalonFromFavourite(string SalonId, string UserId)
        {
            return obj.RemoveSalonFromFavourite(SalonId, UserId);
        }
        [AcceptVerbs("GET","POST")]
        public List<tblFavouriteSalons> GetFavouriteSalonsByUserId(string UserId)
        {
            return obj.GetFavouriteSalonsByUserId(UserId);
        }

    }
}
