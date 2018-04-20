using SalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalonAPI.Controllers
{
    public class CustomersController : ApiController
    {
        CustomersDAL obj = new CustomersDAL();
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> InsertCustomers(string FirstName, string LastName,string PhoneNumber, string ProfileName, string PostalCode,
            int MemberTypeId, int Gender, string Note, string Newsletter, string Email, string Password, string Image, string ImagePath, int CreatedBy, string Address)
        {
            return obj.InsertCustomers(FirstName, LastName,PhoneNumber, ProfileName, PostalCode, MemberTypeId, Gender, Note, Newsletter, Email, Password, Image, ImagePath,CreatedBy,Address);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> UpdateCustomers(string FirstName, string LastName,string PhoneNumber, string ProfileName, string PostalCode,
            int MemberTypeId, int Gender, string Note, string Newsletter, string Email, string Password ,int UserId,  string Iamge,string ImagePath,  int UpdatedBy, int CustomerId,string Address, int Age = 0)
        {
            return obj.UpdateCustomers(FirstName, LastName,PhoneNumber, ProfileName, PostalCode, MemberTypeId, Gender, Note, Newsletter, Email, Password,UserId, Iamge,ImagePath, UpdatedBy, CustomerId,Address, Age);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> GetCustomersDetailsByUserId(int UserId)
        {
            return obj.GetCustomersDetailsByUserId(UserId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> UpdateFECustomers(string PhoneNumber, string Email, string Password, int UserId, string Image, string ImagePath, int UpdatedBy, int CustomerId,string ProfileName,string PostalCode, string Address,int Gender, string FirstName, string LastName)
        {
            return obj.UpdateFECustomers(PhoneNumber, Email, Password, UserId, Image, ImagePath, UpdatedBy, CustomerId,ProfileName,PostalCode, Address,Gender,FirstName,LastName);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> DeleteCustomers(int CustomerId)
        {
            return obj.DeleteCustomers(CustomerId);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> GetCustomersId(int CustomerId)
        {
            return obj.GetCustomersId(CustomerId);
        }


        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> GetUserId(int UserId)
        {
            return obj.GetUserId(UserId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> GetCustomers()
        {
            return obj.GetCustomers();
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> UpdateStatus(int Status, int UpdatedBy, int CustomerId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, CustomerId);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.CustomersDAL.tblCustomers> GetCustomersBySearch(string prefix)
        {
            return obj.GetCustomersBySearch(prefix);
        }
    }
}
