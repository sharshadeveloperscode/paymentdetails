using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
  
    public class NewsLetterController : ApiController
    {
        NewsLetterDAL obj = new NewsLetterDAL();
        [HttpGet]
        public IEnumerable<NewsLetterClass> GetNewsletterSubscribers()
        {
            return obj.GetNewsletterSubscribers();
        }
        [HttpGet]
        public IEnumerable<NewsLetterClass> UpdateNewsletter(string Newsletter , int CustomerId)
        {
            return obj.UpdateNewsletter(Newsletter, CustomerId);
        }
    }
}
