using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class SalonEmployeesController : ApiController
    {
        SalonEmployeesDAL obj = new SalonEmployeesDAL();
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> GetDatabySalonsId(int SalonsId)
        {
            return obj.GetDatabySalonsId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> GetDatabyId(int SalonEmployeesId)
        {
            return obj.GetDatabyId(SalonEmployeesId);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> Insert(string EmployeeName, string PricingLevel, string JobTitle, string Phone, string Gender, string Email, string StartDate, string StartTime, string EndDate, string EndTime, string About, int SalonsId, string Image, string ImagePath, int IsActive, int CreatedBy, string DOB = null, string DOJ = null, int Age = 0 )
        {
            return obj.Insert(EmployeeName, PricingLevel, JobTitle, Phone, Gender, Email, StartDate, StartTime, EndDate, EndTime, About, SalonsId, Image, ImagePath, IsActive, CreatedBy, DOB, DOJ, Age);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> Update(string EmployeeName, string PricingLevel, string JobTitle, string Phone, string Gender, string Email, string StartDate, string StartTime, string EndDate, string EndTime, string About, int SalonsId, string Image, string ImagePath, int UpdatedBy, int SalonEmployeesId, string DOB = null, string DOJ = null, int Age = 0)
        {
            return obj.Update(EmployeeName, PricingLevel, JobTitle, Phone, Gender, Email, StartDate, StartTime, EndDate, EndTime, About, SalonsId, Image, ImagePath, UpdatedBy, SalonEmployeesId, DOB, DOJ, Age);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> Delete(int SalonEmployeesId)
        {
            return obj.Delete(SalonEmployeesId);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> UpdateStatus(int Status, int UpdatedBy, int SalonEmployeesId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, SalonEmployeesId);
        }
        [HttpGet]
        public IEnumerable<SalonEmployeesClass> GetDataUserbyId(int SalonsId)
        {
            return obj.GetDataUserbyId(SalonsId);
        }

        [HttpGet]
        public IEnumerable<SalonEmployeesClass> GetLeavesByEmployeeId(int SalonEmployeesId)
        {
            return obj.GetLeavesByEmployeeId(SalonEmployeesId);
        }

    }
}
