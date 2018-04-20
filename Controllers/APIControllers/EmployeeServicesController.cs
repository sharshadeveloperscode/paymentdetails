using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class EmployeeServicesController : ApiController
    {
        EmployeeServicesDAL obj = new EmployeeServicesDAL();
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> GetDatabyId(int EmployeeServicesId)
        {
            return obj.GetDatabyId(EmployeeServicesId);
        }
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> Insert(int SalonServicesId, int SalonEmployeesId, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(SalonServicesId, SalonEmployeesId, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> Update(int SalonServicesId, int SalonEmployeesId, int UpdatedBy, int EmployeeServicesId)
        {
            return obj.Update(SalonServicesId, SalonEmployeesId, UpdatedBy, EmployeeServicesId);
        }
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> Delete(int EmployeeServicesId)
        {
            return obj.Delete(EmployeeServicesId);
        }
        [HttpGet]
        public IEnumerable<EmployeeServicesclass> UpdateStatus(int Status, int UpdatedBy, int EmployeeServicesId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, EmployeeServicesId);
        }
    }
}

