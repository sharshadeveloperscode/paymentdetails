using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class SalonschedulerController : ApiController
    {
        SalonschedulerDAL obj = new SalonschedulerDAL();
        public IEnumerable<SalonschedulerClass> Getdata()
        {
            return obj.Getdata();
        }
          public IEnumerable<SalonschedulerClass> GetPaymentsbySalonsId(int SalonsId)
        {
            return obj.GetPaymentsbySalonsId(SalonsId);
        }
    }
}
