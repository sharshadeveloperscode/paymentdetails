using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class TestController : ApiController
    {
        Test obj = new Test();
        [HttpGet]
        public IEnumerable<TestClass> Insert(string Image, string ImagePath)
        {
            return obj.Insert(Image,ImagePath);
        }
        [HttpGet]
        public IEnumerable<TestClass> GetData()
        {
            return obj.GetData();
        }
    }
}
