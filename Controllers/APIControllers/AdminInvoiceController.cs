using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class AdminInvoiceController : ApiController
    {
        AdminInvoiceDAL obj = new AdminInvoiceDAL();
       [HttpGet]
        public IEnumerable<AdminInvoiceClass> InsertInvoice(string SalonsId, string Month, string Year, int IsActive, int CreatedBy, string Period1, string Period2)
        {
            return obj.InsertInvoice(SalonsId, Month, Year, IsActive, CreatedBy, Period1, Period2);
        }
        [HttpGet]
        public IEnumerable<AdminInvoiceClass> GetInvoiceGeneration(string Month, string Year, string Period1, string Period2, string SalonsId)
        {
            return obj.GetInvoiceGeneration(Month, Year, Period1, Period2, SalonsId);
        }
        [HttpGet]
        public IEnumerable<AdminInvoiceClass> GetInvoice(int SalonsId)
        {
            return obj.GetInvoice( SalonsId);
        }
    }
}
