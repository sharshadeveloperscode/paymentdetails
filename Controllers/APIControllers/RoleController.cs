using SalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalonAPI.Controllers
{
    public class RoleController : ApiController
    {
        RoleDAL objRole = new RoleDAL();

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> Insert_Role(string RoleName, int CreatedBy)
        {
            return objRole.InsertRoles(RoleName, CreatedBy);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> Update_Role(string RoleName, int UpdatedBy, int RoleId)
        {
            return objRole.UpdateRoles(RoleName, UpdatedBy, RoleId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> Delete_Role(int RoleId)
        {
            return objRole.DeleteRole(RoleId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> Get_Role_ById(int RoleId)
        {
            return objRole.GetRoleById(RoleId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> Get_Roles()
        {
            return objRole.GetRoles();
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.RoleDAL.tblRoles> UpdateStatus(int Status, int UpdatedBy, int RoleId)
        {
            return objRole.UpdateStatus(Status, UpdatedBy, RoleId);
        }
    }
}
