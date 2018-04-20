using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class PolicyController : ApiController
    {
        PolicyDAL obj = new PolicyDAL();
        [HttpGet]
        public IEnumerable<PolicyClass> InsertPolicy(int SalonsId, int PayAtVenue, int NeedBookingConfirmation, string CancellationPolicy, string BookingleadtimeforAppointments,int IsActive, int CreatedBy, string EvoucherCancellation)
        {
            return obj.InsertPolicy(SalonsId, PayAtVenue, NeedBookingConfirmation, CancellationPolicy, BookingleadtimeforAppointments, IsActive, CreatedBy, EvoucherCancellation);
        }
        [HttpGet]
        public IEnumerable<PolicyClass> UpdatePolicy(int SalonsId, int PayAtVenue, int NeedBookingConfirmation, string CancellationPolicy, string BookingleadtimeforAppointments, int IsActive, int UpdatedBy, int PolicyId, string EvoucherCancellation)
        {
            return obj.UpdatePolicy(SalonsId, PayAtVenue, NeedBookingConfirmation, CancellationPolicy, BookingleadtimeforAppointments, IsActive, UpdatedBy, PolicyId, EvoucherCancellation);
        }
        [HttpGet]
        public IEnumerable<PolicyClass> GetPolicybySalonId(int SalonsId)
        {
            return obj.GetPolicybySalonId(SalonsId);
        }
    }
}
