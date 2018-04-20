using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class DashboardController : ApiController
    {
        DashboardDAL obj = new DashboardDAL();
        [HttpGet]
        public IEnumerable<DashboardClass> Todaycustomers(string date)
        {
          return   obj.Todaycustomers(date);
        }
        [HttpGet]
        public IEnumerable<DashboardClass> TodaySalons(string date)
        {
            return obj.TodaySalons(date);
        }
        [HttpGet]
        public IEnumerable<DashboardClass> TodayCancellations(string date)
        {
            return obj.TodayCancellations(date);
        }
    }
}
