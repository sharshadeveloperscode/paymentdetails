using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class ClientController : ApiController
    {
        ClientDAL obj = new ClientDAL();
        [HttpGet]
        public IEnumerable<ClientClass> ListofClientsbasedonSalonssId(int SalonsId)
        {
            return obj.ListofClientsbasedonSalonssId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<ClientClass> SearchByNameEmail(int SalonsId, string Name, string Email)
        {
            return obj.SearchByNameEmail(SalonsId, Name, Email);
        }
    }
}
