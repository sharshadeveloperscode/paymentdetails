using System.Collections.Generic;
using System.Web.Http;
using SalonAPI.Models;
using static SalonAPI.Models.UsersDAL;

namespace SalonAPI.Controllers
{
    public class UsersController : ApiController
    {
        UsersDAL objUsers = new UsersDAL();

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Insert_User(string Name, string UserName, string Password, string MobileNumber, string Email, int CreatedBy, int RoleId)
        {
            return objUsers.InsertUsers(Name, UserName, Password, MobileNumber, Email, CreatedBy, RoleId);
        }



        [HttpGet]
        public IEnumerable<tblUsers> Update_User(string Name, string UserName, string Password, string MobileNumber, string Email, int UpdatedBy, int RoleId, int UserId)
        {
            return objUsers.UpdateUsers(Name, UserName, Password, MobileNumber, Email, UpdatedBy, RoleId, UserId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Delete_User(int UserId)
        {
            return objUsers.DeleteUsers(UserId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Get_User_ById(int UserId)
        {
            return objUsers.GetUserById(UserId);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> GetUserIdByEmail(string Email)
        {
            return objUsers.GetUserIdByEmail(Email);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> ForgotPassword(string Email)
        {
            return objUsers.ForgotPassword(Email);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Get_Users()
        {
            return objUsers.GetUsers();
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> GetAdminEmailPassword()
        {
            return objUsers.GetAdminEmailPassword();
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Verify_Login(string UserName, string Password)
        {
            return objUsers.Verify_Login(UserName, Password);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Change_Password(string Password, int UserId)
        {
            return objUsers.Change_Password(Password, UserId);
        }

        [HttpGet]
        public IEnumerable<tblUsers> Change_Email_Password(string Password, string Email)
        {
            return objUsers.Change_Email_Password(Password, Email);
        }




        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> GetSalonPages()
        {
            return objUsers.GetSalonPages();
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> Verify_UserLogin(string UserName, string Password)
        {
            return objUsers.Verify_UserLogin(UserName, Password);
        }

        [HttpGet]
        public IEnumerable<UsersDAL.tblUsers> ChangePassword(string OldPassword, string NewPassword, int UserId)
        {
            return objUsers.ChangePassword(OldPassword, NewPassword, UserId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.UsersClass> Get_Users_By_RoleID(int RoleID)
        {
            return objUsers.Get_Users_By_RoleID(RoleID);
        }

        // get user permissions
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<clsUserPermissions> Get_Users_Permissions(int UserID, string MenuName)
        {
            return objUsers.Get_Users_Permissions(UserID, MenuName);
        }

        [AcceptVerbs("GET", "POST")]
        public string UpdateUserPermissions(int PermissionId, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion)
        {
            return objUsers.UpdateUserPermissions(PermissionId, PageID, UserId, View, Insertion, Edit, Deletion);
        }
        [AcceptVerbs("GET", "POST")]
        public string UpdateUserPermissions1(string PageID, int UserId)
        {
            return objUsers.UpdateUserPermissions1(PageID, UserId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> Get_User_Permissions_By_Id(int UserID, string PageName)
        {
            return objUsers.Get_User_Permissions_By_Id(UserID, PageName);
        }

        [AcceptVerbs("GET", "POST")]
        public string InsertPages(string MenuName, string PageName, string DisplayName, int FrontEndDisplay)
        {
            return objUsers.InsertPages(MenuName, PageName, DisplayName, FrontEndDisplay);
        }


        [AcceptVerbs("GET", "POST")]
        public string UpdatePages(string MenuName, string PageName, int PageID, string DisplayName, int FrontEndDisplay)
        {
            return objUsers.UpdatePages(MenuName, PageName, PageID, DisplayName, FrontEndDisplay);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetPageList()
        {
            return objUsers.GetPageList();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetPageById(int PageID)
        {
            return objUsers.GetPageById(PageID);
        }

        [AcceptVerbs("GET", "POST")]
        public string AddStartPage(int RoleID, int PageID)
        {
            return objUsers.AddStartPage(RoleID, PageID);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetAllStartPages()
        {
            return objUsers.GetAllStartPages();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetStartPageByRoleId(int RoleID)
        {
            return objUsers.GetStartPageByRoleId(RoleID);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetStartPageById(int ID)
        {
            return objUsers.GetStartPageById(ID);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteStartPage(int ID)
        {
            return objUsers.DeleteStartPage(ID);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetModules()
        {
            return objUsers.GetModules();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> Get_Work_Flow(int RoleID, string ModuleName)
        {
            return objUsers.Get_Work_Flow(RoleID, ModuleName);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> Get_Users_For_WorkFlow(int RoleID, string ModuleName)
        {
            return objUsers.Get_Users_For_WorkFlow(RoleID, ModuleName);
        }

        [AcceptVerbs("GET", "POST")]
        public string WorkFlow(string WorkFlowName, int PermissionId, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion)
        {
            return objUsers.WorkFlow(WorkFlowName, PermissionId, PageID, UserId, View, Insertion, Edit, Deletion);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.tblWorkFlow> GetWorkFlows()
        {
            return objUsers.GetWorkFlows();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetWorkFlowByName(string WorkFlowName)
        {
            return objUsers.GetWorkFlowByName(WorkFlowName);
        }

        [AcceptVerbs("GET", "POST")]
        public string DeleteWorkFlow(string WorkFlowName)
        {
            return objUsers.DeleteWorkFlow(WorkFlowName);
        }


        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> Get_Work_FlowDetails(string ModuleName)
        {
            return objUsers.Get_Work_FlowDetails(ModuleName);
        }

        [AcceptVerbs("GET", "POST")]
        public string CreateWorkFlow(string WorkFlowName, int Levels, string Description, string CreatedBy)
        {
            return objUsers.CreateWorkFlow(WorkFlowName, Levels, Description, CreatedBy);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.tblWorkFlow> GetWorkFlowDetails()
        {
            return objUsers.GetWorkFlowDetails();
        }

        [AcceptVerbs("GET", "POST")]
        public string CreateLevels(string LevelName, int WorkFlowID, string CreatedBy)
        {
            return objUsers.CreateLevels(LevelName, WorkFlowID, CreatedBy);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.tblWorkFlow> GetWorkFlowLevels(int WorkFlowID)
        {
            return objUsers.GetWorkFlowLevels(WorkFlowID);
        }

        [AcceptVerbs("GET", "POST")]
        public string WorkFlowDetailsByLevels(string WorkFlowID, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion, string ModuleName, string CreatedBy, int LevelID)
        {
            return objUsers.WorkFlowDetailsByLevels(WorkFlowID, PageID, UserId, View, Insertion, Edit, Deletion, ModuleName, CreatedBy, LevelID);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetWorkLevelsDetails(int LevelID)
        {
            return objUsers.GetWorkLevelsDetails(LevelID);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<UsersDAL.clsUserPermissions> GetAllVieWPages(int UserID)
        {
            return objUsers.GetAllVieWPages(UserID);
        }


        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> UsernameAvailability(string UserName)
        {
            return objUsers.UsernameAvailability(UserName);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.UsersDAL.tblUsers> EmailCheck(string Email)
        {
            return objUsers.EmailCheck(Email);
        }

        [HttpGet]
        public IEnumerable<tblUsers> UpdateUserStatus(int UserId, string Status)
        {
            return objUsers.UpdateUserStatus(UserId, Status);
        }
        [HttpGet]
        public IEnumerable<UsersDAL.tblUsers> EmailCheckone(string Email)
        {
            return objUsers.EmailCheckone(Email);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblUsers> registerThroughOtp(string MobileNumber)
        {
            return objUsers.registerThroughOtp(MobileNumber);
        }
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblUsers> registerThroughEmail(string Name, string Email, string MobileNumber, string Password, string LoginType, string ProfilePicture, string Gender)
        {
            return objUsers.registerThroughEmail(Name, Email, MobileNumber, Password, LoginType, ProfilePicture, Gender);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblUsers> verifyOtp(int UserId, string OTP)
        {
            return objUsers.verifyOtp(UserId, OTP);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblUsers> ResendOTP(string MobileNumber) => objUsers.ResendOTP(MobileNumber);

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblUsers> SearchAll(string Name) => objUsers.SearchAll(Name);

    }
}
