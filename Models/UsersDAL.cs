using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Salon.Helper;

namespace SalonAPI.Models
{
    public class UsersDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);

        List<tblUsers> objUsers = new List<tblUsers>();
        List<UsersClass> objUserRoles = new List<UsersClass>();
        List<clsUserPermissions> objUserPermisions = new List<clsUserPermissions>();
        List<tblWorkFlow> objWorkFlow = new List<tblWorkFlow>();
        List<tblAuctions> objAuctions = new List<tblAuctions>();

        public IEnumerable<tblUsers> GetUsers()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tu.*,tr.RoleName from tblUsers tu,tblRole tr where tu.RoleId = tr.RoleId  ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        Name = dt.Rows[i]["Name"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        Status = dt.Rows[i]["Status"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "No Data" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> GetSalonPages()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPages where PageID in(85,110,30,109,31,32,33,96,97,104,52,36,108,37,40,72,105,84,116)  ", con);
                // MySqlCommand cmd = new MySqlCommand("select * from tblPages ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        // UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        //  Name = dt.Rows[i]["Name"].ToString(),
                        // UserName = dt.Rows[i]["UserName"].ToString(),
                        //  MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        //  Email = dt.Rows[i]["Email"].ToString(),
                        //  Password = dt.Rows[i]["Password"].ToString(),
                        //  RoleName = dt.Rows[i]["RoleName"].ToString(),

                        //  CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        //  UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "No Data" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }
        public IEnumerable<tblUsers> GetAdminEmailPassword()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,tu.Email as AdminEmail,tu.MobileNumber as AdminMobileNumber,tu.UserName as AdminUserName from tblUsers tu,tblRole tr where tu.RoleId=tr.RoleId AND tr.RoleName='admin' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        AdminName = dt.Rows[i]["AdminUserName"].ToString(),
                        AdminEmail = dt.Rows[i]["AdminEmail"].ToString(),
                        AdminMobileNumber = dt.Rows[i]["AdminMobileNumber"].ToString(),

                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "No Data" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> ForgotPassword(string Email)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("select tu.*,tr.RoleName,td.DepartmentName from tblUsers tu,tblRole tr,tblDepartment td where tu.RoleId = tr.RoleId", con);
                MySqlCommand cmd = new MySqlCommand("select * from tblUsers where Email='" + Email + "'", con);
                con.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    objUsers.Add(new tblUsers
                    {
                        //UserId = Convert.ToInt32(dataReader["UserId"]),
                        RoleId = Convert.ToInt32(dataReader["RoleId"]),
                        //Name = dataReader["Name"].ToString(),
                        //UserName = dataReader["UserName"].ToString(),
                        //MobileNumber = dataReader["MobileNumber"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        Name = dataReader["Name"].ToString(),
                        //RoleName = dataReader["RoleName"].ToString(),
                        //Status = dataReader["Status"].ToString(),
                        //CreatedBy = dataReader["CreatedBy"].ToString(),
                        //UpdatedBy = dataReader["UpdatedBy"].ToString(),
                        //BackDating = dataReader["BackDating"].ToString(),
                        Message = "Success"
                    });
                }
                if (!dataReader.HasRows)
                {
                    objUsers.Add(new tblUsers { Message = "No Data" });
                }
                dataReader.Close();
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<tblUsers> GetUserById(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tu.*,tr.RoleName from tblUsers tu,tblRole tr where tu.RoleId = tr.RoleId  and  tu.UserId ='" + UserId + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),

                        Name = dt.Rows[i]["Name"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "Success" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }



        public IEnumerable<tblUsers> GetUserIdByEmail(string Email)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tu.*,tr.RoleName from tblUsers tu,tblRole tr where tu.RoleId = tr.RoleId  and  tu.Email ='" + Email + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),

                        Name = dt.Rows[i]["Name"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "Success" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> UpdateUsers(string Name, string UserName, string Password, string MobileNumber, string Email, int UpdatedBy, int RoleId, int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblUsers set Name='" + Name + "',UserName='" + UserName + "',Password='" + Password + "',MobileNumber='" + MobileNumber + "',Email='" + Email + "',RoleId='" + RoleId + "', UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where UserId='" + UserId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objUsers.Add(new tblUsers { Message = "Success" });
                return objUsers;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> InsertUsers(string Name, string UserName, string Password, string MobileNumber, string Email, int CreatedBy, int RoleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblUsers(Name,UserName,Password,RoleId,MobileNumber,Email,Status,CreatedBy,CreatedDate) values('" + Name + "','" + UserName + "','" + Password + "','" + RoleId + "', '" + MobileNumber + "','" + Email + "',1, '" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                con.Open();
                int k = cmd.ExecuteNonQuery();
                int userid = (int)cmd.LastInsertedId;
                if (RoleId != 10)
                {
                    MySqlCommand cmd2 = new MySqlCommand("insert into tblCustomers(FirstName,LastName,ProfileName,PhoneNumber,PostalCode,MemberTypeId,Gender,Note,Newsletter,Email,Password,Image,ImagePath, UserId,IsActive,CreatedBy,CreatedDate,Address) values('" + Name + "','" + Name + "', '" + Name + "','" + MobileNumber + "','','','','','','" + Email + "','" + Password + "','','', '" + userid + "', '" + 1 + "', '" + CreatedBy + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "','')", con);
                    cmd2.ExecuteNonQuery();
                }

                con.Close();
                objUsers.Add(new tblUsers
                {
                    UserId = Convert.ToInt32(userid),
                    Message = "Success"
                });
                //if (k >= 1)
                //{
                //    MySqlCommand cmd1 = new MySqlCommand("select top 1 UserId from tblUsers order by UserId desc ", con);
                //    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                //    DataTable dt = new DataTable();
                //    da1.Fill(dt);
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        objUsers.Add(new tblUsers
                //        {
                //            UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                //            Message = "Success"
                //        });
                //    }
                //}
                return objUsers;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> EmailCheckone(string Email)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblUsers where UserName='" + Email + "' or Email='" + Email + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "NoData" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> DeleteUsers(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblUsers where UserId='" + UserId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objUsers.Add(new tblUsers { Message = "Success" });
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> Verify_Login(string UserName, string Password)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT tblUsers.*, tblRole.RoleName, tblPages.PageName,tblCustomers.* FROM tblUsers INNER JOIN tblRole ON tblRole.RoleId = tblUsers.RoleId LEFT OUTER JOIN tblStartPage ON tblRole.RoleId = tblStartPage.RoleId LEFT OUTER JOIN tblPages ON tblStartPage.PageID = tblPages.PageID LEFT OUTER JOIN tblCustomers ON tblCustomers.UserId = tblUsers.UserId WHERE tblUsers.UserName = '" + UserName + "' AND tblUsers.Password = '" + Password + "' and tblUsers.Status=1", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success",
                        StartPage = dt.Rows[i]["PageName"].ToString(),
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "Fail" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> Verify_UserLogin(string UserName, string Password)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("select u.*, r.RoleName, (select BidderBasicDetailsId from tblBidderBasicDetails where UserId=u.UserId) as BidderRegId, (select RegistrationId from tblVendorRegistration where UserId = u.UserId) as VendorRegId from tblUsers u, tblRole r where u.RoleId = r.RoleId and u.UserName='" + UserName + "' and u.Password='" + Password + "'", con);
                MySqlCommand cmd = new MySqlCommand("select u.*, r.RoleName, (select BidderBasicDetailsId from tblBidderBasicDetails where UserId=u.UserId) as BidderRegId,(select TenderBasicDetailsId from tblBidderBasicDetails  where UserId=u.UserId) as TenderId,(select RegStatus from tblBidderBasicDetails  where UserId=u.UserId) as RegStatus, (select RegistrationId from tblVendorRegistration where UserId = u.UserId) as VendorRegId from tblUsers u, tblRole r where u.RoleId = r.RoleId and u.UserName='" + UserName + "' and u.Password='" + Password + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["BidderRegId"] == DBNull.Value)
                    {
                        dt.Rows[i]["BidderRegId"] = 0;
                    }
                    if (dt.Rows[i]["VendorRegId"] == DBNull.Value)
                    {
                        dt.Rows[i]["VendorRegId"] = 0;
                    }
                    if (dt.Rows[i]["TenderId"] == DBNull.Value)
                    {
                        dt.Rows[i]["TenderId"] = 0;
                    }
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        BidderRegistrationId = Convert.ToInt32(dt.Rows[i]["BidderRegId"]),
                        VendorRegistrationId = Convert.ToInt32(dt.Rows[i]["VendorRegId"]),
                        TenderBasicDetailsId = Convert.ToInt32(dt.Rows[i]["TenderId"]),
                        BidderBasicDetailsId = Convert.ToInt32(dt.Rows[i]["BidderRegId"]),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),

                        RegStatus = dt.Rows[i]["RegStatus"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "Fail" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> Change_Password(string Password, int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblUsers set Password='" + Password + "', UpdatedBy='" + UserId + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where UserId='" + UserId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MySqlCommand cmd2 = new MySqlCommand("update tblCustomers set Password='" + Password + "', UpdatedBy='" + UserId + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where UserId='" + UserId + "' ", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();


                objUsers.Add(new tblUsers { Message = "Success" });
                return objUsers;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> Change_Email_Password(string Password, string Email)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblUsers set Password='" + Password + "', UpdatedBy='0',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where Email='" + Email + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MySqlCommand cmd2 = new MySqlCommand("update tblCustomers set Password='" + Password + "', UpdatedBy='0',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where Email='" + Email + "' ", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();


                objUsers.Add(new tblUsers { Message = "Success" });
                return objUsers;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }


        public IEnumerable<tblUsers> ChangePassword(string OldPassword, string NewPassword, int UserId)
        {
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblUsers where UserId='" + UserId + "' and Password='" + OldPassword + "'", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                int i = Convert.ToInt32(cmd1.ExecuteScalar());
                if (i > 0)
                {
                    MySqlCommand cmd = new MySqlCommand("update tblUsers set Password='" + NewPassword + "', UpdatedBy='" + UserId + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where UserId='" + UserId + "' ", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    objUsers.Add(new tblUsers { Message = "Success" });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "InCorrect old Password" });
                    return objUsers;
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        // get user by roleid
        public IEnumerable<UsersClass> Get_Users_By_RoleID(int RoleID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_GetUsersByRoleID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", RoleID);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserRoles.Add(new UsersClass
                    {
                        Name = dt.Rows[i]["Name"].ToString(),
                        UserID = Convert.ToInt32(dt.Rows[i]["UserId"])
                    });
                }
            }
            catch (Exception)
            {
                objUserRoles.Add(new UsersClass
                {
                    Name = "Error",
                    UserID = 0
                });
            }
            return objUserRoles;
        }

        // get user permissions
        public IEnumerable<clsUserPermissions> Get_Users_Permissions(int UserID, string MenuName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_UserPermissions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserID);
                cmd.Parameters.AddWithValue("@Count", 0);
                cmd.Parameters.AddWithValue("@rowcount", 0);
                cmd.Parameters.AddWithValue("@MenuName", MenuName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        MenuName = dt.Rows[i]["MenuName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        ID = dt.Rows[i]["ID"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString(),
                        count = Convert.ToInt32(dt.Rows[i]["count"]),
                        // UserId = dt.Rows[i]["UserId"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    Insert = "Error",
                    count = 1
                });
            }
            return objUserPermisions;
        }

        public string UpdateUserPermissions(int PermissionId, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion)
        {
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblUserPermissions where tblUserPermissions.UserId=" + UserId + " and tblUserPermissions.PageID=" + PageID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                int j = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (j == 0)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblUserPermissions(UserId,PageID,View,Insertion,Edit,Deletion,CreatedDate,CreatedBy)values(" + UserId + "," + PageID + ",'" + View + "','" + Insertion + "','" + Edit + "','" + Deletion + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update tblUserPermissions set View='" + View + "',Insertion='" + Insertion + "',Edit='" + Edit + "',Deletion='" + Deletion + "' where UserId=" + UserId + " and PageID=" + PageID + "", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
        public string UpdateUserPermissions1(string PageID, int UserId)
        {
            try
            {
                //MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblUserPermissions where tblUserPermissions.UserId=" + UserId + " and tblUserPermissions.PageID=" + PageID + "", con);
                //if (con.State == ConnectionState.Closed) { con.Open(); }
                //int j = Convert.ToInt32(cmd1.ExecuteScalar());
                //con.Close();
                //if (j == 0)
                //{
                con.Open();
                string value = PageID;
                char delimiter = ',';
                string[] substrings = value.Split(delimiter);
                for (int i = 0; i < substrings.Length; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblUserPermissions(UserId,PageID,View,Insertion,Edit,Deletion,CreatedDate,CreatedBy)values(" + UserId + "," + substrings[i] + ",'" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                    // if (con.State == ConnectionState.Closed) { con.Open(); } 
                    cmd.ExecuteNonQuery();
                }


                con.Close();
                ////  }
                //  else
                //  {
                //MySqlCommand cmd = new MySqlCommand("update tblUserPermissions set View='" + View + "',Insertion='" + Insertion + "',Edit='" + Edit + "',Deletion='" + Deletion + "' where UserId=" + UserId + " and PageID=" + PageID + "", con);
                //if (con.State == ConnectionState.Closed) { con.Open(); }
                //cmd.ExecuteNonQuery();
                //con.Close();
                // }
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public string WorkFlow(string WorkFlowName, int PermissionId, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion)
        {
            try
            {
                // MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblWorkFlow where tblWorkFlow.UserId=" + UserId + " and tblWorkFlow.PageID=" + PageID + " and tblWorkFlow.WorkFlowName='"+WorkFlowName+"'", con);
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblWorkFlow where tblWorkFlow.WorkFlowName='" + WorkFlowName + "'", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                int j = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (j == 0)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblWorkFlow(UserId,PageID,WorkFlowName,CreatedDate,CreatedBy)values(" + UserId + "," + PageID + ",'" + WorkFlowName + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    UpdateUserPermissions(PermissionId, PageID, UserId, View, Insertion, Edit, Deletion);
                    return "Work flow created sucessfully";
                }
                else
                {
                    //MySqlCommand cmd = new MySqlCommand("update tblWorkFlow set WorkFlowName='" + WorkFlowName + "' where UserId=" + UserId + " and PageID=" + PageID + "", con);
                    //if (con.State == ConnectionState.Closed) { con.Open(); }
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    //UpdateUserPermissions(PermissionId, PageID, UserId, View, Insertion, Edit, Deletion);
                    // return "work flow updated successfully";
                    return "Exists";
                }

            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IEnumerable<clsUserPermissions> Get_User_Permissions_By_Id(int UserID, string PageName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblUserPermissions inner join tblPages on tblUserPermissions.PageID=tblPages.PageID where tblUserPermissions.UserId=" + UserID + " and tblPages.PageName='" + PageName + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        MenuName = dt.Rows[i]["MenuName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        ID = dt.Rows[i]["ID"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    PageID = 0
                });
            }
            return objUserPermisions;
        }

        public string InsertPages(string MenuName, string PageName, string DisplayName, int FrontEndDisplay)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblPages(MenuName,PageName,CreatedDate,CreatedBy,PageDisplayName,Display)values('" + MenuName + "','" + PageName + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin','" + DisplayName + "'," + FrontEndDisplay + ")", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();

                MySqlCommand cmd1 = new MySqlCommand("select * from tblPages where tblPages.MenuName='" + MenuName + "' and tblPages.PageName='" + PageName + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MySqlCommand cmd2 = new MySqlCommand("select distinct UserId from tblUserPermissions", con);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    MySqlCommand cmd3 = new MySqlCommand("insert into tblUserPermissions(UserId,PageID,View,Insertion,Edit,Deletion,CreatedDate,CreatedBy)values('" + dt1.Rows[i]["UserId"].ToString() + "','" + dt.Rows[0]["PageID"].ToString() + "','0','0','0','0','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
                return "Success";
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("Duplicate"))
                {
                    return "UniqueConstraint";
                }
                else
                {
                    return "Fail";
                }
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public string UpdatePages(string MenuName, string PageName, int PageID, string DisplayName, int FrontEndDisplay)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPages set MenuName='" + MenuName + "',PageName='" + PageName + "',PageDisplayName='" + DisplayName + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',UpdatedBy='Admin',Display=" + FrontEndDisplay + " where PageID=" + PageID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IEnumerable<clsUserPermissions> GetPageList()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPages ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        MenuName = dt.Rows[i]["MenuName"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString(),
                        FrontEndDisplay = dt.Rows[i]["Display"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> GetPageById(int PageID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPages where PageID=" + PageID + "", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        MenuName = dt.Rows[i]["MenuName"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString(),
                        FrontEndDisplay = dt.Rows[i]["Display"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public string AddStartPage(int RoleID, int PageID)
        {
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblStartPage where RoleID=" + RoleID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                int j = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (j == 0)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblStartPage(PageID,RoleID,CreatedDate,CreatedBy)values(" + PageID + "," + RoleID + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Assigned Successfully";
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update tblStartPage set PageID='" + PageID + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',UpdatedBy='Admin' where RoleId=" + RoleID + "", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Updated Successfully";
                }
            }
            catch (Exception)
            {
                return "Failed to Assign";
            }
        }

        public IEnumerable<clsUserPermissions> GetAllStartPages()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tblStartPage.ID,tblRole.RoleId,tblRole.RoleName,tblPages.PageName from tblStartPage inner join tblPages on tblStartPage.PageID=tblPages.PageID inner join tblRole on tblStartPage.RoleId=tblRole.RoleId", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        ID = dt.Rows[i]["ID"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> GetStartPageByRoleId(int RoleID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblStartPage where RoleId=" + RoleID + "", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"])
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> GetStartPageById(int ID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tblDepartment.DepartmentId,tblStartPage.RoleId,tblStartPage.PageID from tblStartPage inner join tblRole on tblStartPage.RoleId=tblRole.RoleId inner join tblDepartment on tblDepartment.DepartmentId=tblRole.DepartmentId where tblStartPage.ID=" + ID + "", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        RoleID = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentId"])
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public string DeleteStartPage(int ID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblStartPage where ID=" + ID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }

        }
        public IEnumerable<clsUserPermissions> GetModules()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT MenuName FROM tblPages order by PageID in(85,110,30,31,32,33,96,97,104,52,36,108,37,40,44,19,72,105,84)", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        MenuName = dt.Rows[i]["MenuName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    MenuName = "Error"
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> Get_Work_Flow(int RoleID, string ModuleName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_WorkFlow", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        UserId = dt.Rows[i]["UserId"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString(),
                        DepartmentName = dt.Rows[i]["DepartmentName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    count = 0
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> Get_Users_For_WorkFlow(int RoleID, string ModuleName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tblPages.PageID,tblPages.PageName,tblUsers.UserId,tblUsers.UserName,0 as View from tblPages cross join tblUsers where tblUsers.RoleID=" + RoleID + " and tblPages.MenuName='" + ModuleName + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        UserId = dt.Rows[i]["UserId"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    count = 0
                });
            }
            return objUserPermisions;
        }

        public string CreateTask(string ModuleName, string TaskName, int PageID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblTasks(PageID,ModuleName,TaskName,CreatedDate,CreatedBy)values(" + PageID + ",'" + ModuleName + "','" + TaskName + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','Admin')", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Assign";
            }
        }

        public string UpdateTask(string ModuleName, string TaskName, int PageID, int ID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblTasks set ModuleName='" + ModuleName + "',TaskName='" + TaskName + "',PageID=" + PageID + ",UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',UpdatedBy='Admin' where ID=" + ID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Assign";
            }
        }

        public IEnumerable<clsUserPermissions> GetTasks()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblTasks inner join tblPages on tblTasks.PageID=tblPages.PageID", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        ID = dt.Rows[i]["ID"].ToString(),
                        PageName = dt.Rows[i]["ModuleName"].ToString(),
                        MenuName = dt.Rows[i]["ModuleName"].ToString(),
                        TaskName = dt.Rows[i]["TaskName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error"
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<tblWorkFlow> GetWorkFlows()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct WorkFlowName from tblWorkFlow", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objWorkFlow.Add(new tblWorkFlow
                    {
                        WorkFlowName = dt.Rows[i]["WorkFlowName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objWorkFlow.Add(new tblWorkFlow
                {
                    WorkFlowName = "Error"
                });
            }
            return objWorkFlow;
        }

        public IEnumerable<clsUserPermissions> GetWorkFlowByName(string WorkFlowName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tblWorkFlow.WorkFlowName,tblDepartment.DepartmentName,tblRole.RoleName,tblPages.PageDisplayName,tblPages.PageID,tblUsers.UserId,tblUsers.UserName,tblUserPermissions.View from tblWorkFlow left outer join tblPages on tblWorkFlow.PageID=tblPages.PageID left outer join tblUsers on tblWorkFlow.UserId=tblUsers.UserId left outer join tblUserPermissions on tblWorkFlow.PageID=tblUserPermissions.PageID left outer join tblRole on tblRole.RoleId=tblUsers.RoleId left outer join tblDepartment on tblDepartment.DepartmentId=tblRole.DepartmentId where tblUserPermissions.UserId=tblWorkFlow.UserId and tblWorkFlow.WorkFlowName='" + WorkFlowName + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageDisplayName"].ToString(),
                        DepartmentName = dt.Rows[i]["DepartmentName"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        UserId = dt.Rows[i]["UserId"].ToString(),
                        WorkFlowName = dt.Rows[i]["WorkFlowName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    count = 0
                });
            }
            return objUserPermisions;
        }

        public string DeleteWorkFlow(string WorkFlowName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblWorkFlow where WorkFlowName='" + WorkFlowName + "'", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }


        public IEnumerable<clsUserPermissions> Get_Work_FlowDetails(string ModuleName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_Workflow_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        UserId = dt.Rows[i]["UserId"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    count = 0
                });
            }
            return objUserPermisions;
        }

        public string CreateWorkFlow(string WorkFlowName, int Levels, string Description, string CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblWorkFlows(WorkFlowName,Levels,Description,CreatedBy,CreatedDate)values('" + WorkFlowName + "'," + Levels + ",'" + Description + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Created Successfully";
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return "unique";
                }
                else
                {
                    return "Fail";
                }

            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IEnumerable<tblWorkFlow> GetWorkFlowDetails()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblWorkFlows", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objWorkFlow.Add(new tblWorkFlow
                    {
                        WorkFlowName = dt.Rows[i]["WorkFlowName"].ToString(),
                        WorkFlowID = Convert.ToInt32(dt.Rows[i]["WorkFlowID"]),
                        Levels = Convert.ToInt32(dt.Rows[i]["Levels"]),
                        Description = dt.Rows[i]["Description"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objWorkFlow.Add(new tblWorkFlow
                {
                    WorkFlowName = "Error"
                });
            }
            return objWorkFlow;
        }

        public string CreateLevels(string LevelName, int WorkFlowID, string CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblWorkFlowLevels(WorkFlowID,LevelName,CreatedBy,CreatedDate)values(" + WorkFlowID + ",'" + LevelName + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                con.Close();
                return "Created Successfully";
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    return "unique";
                }
                else
                {
                    return "Fail";
                }

            }
            catch (Exception)
            {
                return "Fail";
            }
        }

        public IEnumerable<tblWorkFlow> GetWorkFlowLevels(int WorkFlowID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblWorkFlowLevels inner join tblWorkFlows on tblWorkFlowLevels.WorkFlowID=tblWorkFlows.WorkFlowID where tblWorkFlowLevels.WorkFlowID=" + WorkFlowID + "", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objWorkFlow.Add(new tblWorkFlow
                    {
                        LevelName = dt.Rows[i]["LevelName"].ToString(),
                        WorkFlowName = dt.Rows[i]["WorkFlowName"].ToString(),
                        LevelID = Convert.ToInt32(dt.Rows[i]["LevelID"])
                    });
                }
            }
            catch (Exception)
            {
                objWorkFlow.Add(new tblWorkFlow
                {
                    LevelName = "Error"
                });
            }
            return objWorkFlow;
        }

        public string WorkFlowDetailsByLevels(string WorkFlowID, int PageID, int UserId, string View, string Insertion, string Edit, string Deletion, string ModuleName, string CreatedBy, int LevelID)
        {
            try
            {
                // MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblWorkFlow where tblWorkFlow.UserId=" + UserId + " and tblWorkFlow.PageID=" + PageID + " and tblWorkFlow.WorkFlowName='"+WorkFlowName+"'", con);
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tblWorkFlowDetails where tblWorkFlowDetails.WorkFlowID=" + WorkFlowID + " and tblWorkFlowDetails.UserId=" + UserId + " and tblWorkFlowDetails.PageID=" + PageID + "", con);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                int j = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (j == 0)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblWorkFlowDetails(WorkFlowID,UserId,PageID,LevelID,ModuleName,CreatedDate,CreatedBy)values(" + WorkFlowID + "," + UserId + "," + PageID + "," + LevelID + ",'" + ModuleName + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + CreatedBy + "')", con);
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    UpdateUserPermissions(0, PageID, UserId, View, Insertion, Edit, Deletion);
                    return "Work flow created sucessfully";
                }
                else
                {
                    UpdateUserPermissions(0, PageID, UserId, View, Insertion, Edit, Deletion);
                    return "Work flow updated sucessfully";
                }

            }
            catch (Exception)
            {
                return "Fail";
            }
        }


        public IEnumerable<clsUserPermissions> GetWorkLevelsDetails(int LevelID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct tblPages.PageID,tblPages.PageName,tblRole.RoleName,tblPages.PageDisplayName,tblUserPermissions.View,tblUserPermissions.Insertion,tblUserPermissions.Edit,tblUserPermissions.Deletion,tblUsers.UserId,tblUsers.UserName from tblPages inner join tblWorkFlowDetails on tblPages.PageID=tblWorkFlowDetails.PageID inner join tblUsers on tblWorkFlowDetails.UserId=tblUsers.UserId inner join tblUserPermissions on tblPages.PageID=tblUserPermissions.PageID and tblWorkFlowDetails.PageID=tblUserPermissions.PageID inner join tblRole on tblRole.RoleId=tblUsers.RoleId  where tblWorkFlowDetails.LevelID=" + LevelID + " and tblUserPermissions.View=1", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        UserId = dt.Rows[i]["UserId"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    count = 0
                });
            }
            return objUserPermisions;
        }

        public IEnumerable<clsUserPermissions> GetAllVieWPages(int UserID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPages inner join tblUserPermissions on tblPages.PageID=tblUserPermissions.PageID where tblUserPermissions.UserId=" + UserID + " and tblUserPermissions.View=1 AND tblPages.Display = 1 order by tblPages.PageID in(85,110,30,72,109,31,105,32,33,96,97,104,52,36,37,40,84,108)", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserPermisions.Add(new clsUserPermissions
                    {
                        PageID = Convert.ToInt32(dt.Rows[i]["PageID"]),
                        PageName = dt.Rows[i]["PageName"].ToString(),
                        MenuName = dt.Rows[i]["MenuName"].ToString(),
                        DisplayName = dt.Rows[i]["PageDisplayName"].ToString(),
                        View = dt.Rows[i]["View"].ToString(),
                        Edit = dt.Rows[i]["Edit"].ToString(),
                        Insert = dt.Rows[i]["Insertion"].ToString(),
                        Delete = dt.Rows[i]["Deletion"].ToString(),
                        ID = dt.Rows[i]["ID"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                objUserPermisions.Add(new clsUserPermissions
                {
                    PageName = "Error",
                    PageID = 0
                });
            }
            return objUserPermisions;
        }


        public IEnumerable<tblUsers> UsernameAvailability(string UserName)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblUsers where UserName='" + UserName + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "NoData" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }


        public IEnumerable<tblUsers> UpdateUserStatus(int UserId, string Status)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblUsers set Status=" + Status + " where UserId='" + UserId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objUsers.Add(new tblUsers { Message = "Success" });
                return objUsers;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objUsers.Add(new tblUsers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objUsers;
                }
                else
                {
                    objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                    return objUsers;
                }

            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> EmailCheck(string Email)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblUsers where Email='" + Email + "' ", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUsers.Add(new tblUsers
                    {
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objUsers.Add(new tblUsers { Message = "NoData" });
                    return objUsers;
                }
                return objUsers;
            }
            catch (Exception ex)
            {
                objUsers.Add(new tblUsers { Message = "Error", ErrorMessage = ex.Message });
                return objUsers;
            }
        }

        public IEnumerable<tblUsers> registerThroughOtp(string MobileNumber)
        {
            dbHelper objdb = new dbHelper();
            MySqlTransaction trans;
            trans = null;
            using (MySqlConnection cons = objdb.GetConnection())
            {
                objdb.opencon();
                trans = cons.BeginTransaction();
                try
                {
                    int id = 0;
                    Random ran = new Random();
                    string OTP = ran.Next(0, 1000000).ToString("D6");
                    MySqlCommand cmd = new MySqlCommand("insert into tblUsers(UserName,Password,MobileNumber,RoleId,CreatedDate,OTP)values(@UserName,@Password,@MobileNumber,@RoleId,@CreatedDate,@OTP)", cons, trans);
                    cmd.Parameters.AddWithValue("@UserName", MobileNumber);
                    cmd.Parameters.AddWithValue("@Password", MobileNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@RoleId", 9);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    cmd.Parameters.AddWithValue("@OTP", OTP);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.AddMinutes(750));
                    cmd.ExecuteNonQuery();
                    id = Convert.ToInt32(cmd.LastInsertedId);
                    MySqlCommand cmd2 = new MySqlCommand("insert into tblCustomers(PhoneNumber,UserId,MemberTypeId)values(@PhoneNumber,@UserId,@MemberTypeId)", cons, trans);
                    objdb.opencon();
                    cmd2.Parameters.AddWithValue("@PhoneNumber", MobileNumber);
                    cmd2.Parameters.AddWithValue("@UserId", id);
                    cmd2.Parameters.AddWithValue("@MemberTypeId", 1);
                    cmd2.ExecuteNonQuery();

                    string content = "Your One-Time Password for Hogarbarber is " + OTP;
                    objdb.SendSMS(MobileNumber, content);
                    objUsers.Add(new tblUsers
                    {
                        Message = "Registered Successfully",
                        OTP = OTP,
                        LoginStatus = "1",
                        UserId = id
                    });
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    objUsers.Add(new tblUsers
                    {
                        Message = "Mobile Number Already Exist",
                        // Message = ex.Message,
                        OTP = "0",
                        UserId = 0
                    });
                   
                }
                finally
                {
                    objdb.closecon();
                }
            }
            return objUsers;
        }

        public IEnumerable<tblUsers> verifyOtp(int UserId, string OTP)
        {
            dbHelper objdb = new dbHelper();
            using (MySqlConnection cons = objdb.GetConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("select count(*) from tblUsers where UserId=@UserId and OTP=@OTP", cons))
                    {
                        objdb.opencon();
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.Parameters.AddWithValue("@OTP", OTP);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            objUsers.Add(new tblUsers
                            {
                                Message = "Valid OTP"
                            });
                        }
                        else
                        {
                            objUsers.Add(new tblUsers
                            {
                                Message = "Invalid OTP"
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    objUsers.Add(new tblUsers
                    {
                        Message = "Failed to validate OTP"
                    });
                }
                finally
                {
                    objdb.closecon();
                }
            }
            return objUsers;
        }
        public IEnumerable<tblUsers> ResendOTP(string MobileNumber)
        {
            dbHelper objdb = new dbHelper();
            using (MySqlConnection cons = objdb.GetConnection())
            {
                try
                {
                    Random ran = new Random();
                    string OTP = ran.Next(0, 1000000).ToString("D6");
                    using (MySqlCommand cmd = new MySqlCommand("update tblUsers set OTP=@OTP where MobileNumber=@MobileNumber", cons))
                    {
                        objdb.opencon();
                        cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        cmd.Parameters.AddWithValue("@OTP", OTP);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        MySqlCommand cmd2 = new MySqlCommand("select UserId from tblUsers where MobileNumber=@MobileNumber", cons);
                        cmd2.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        objdb.opencon();
                        int UserId = Convert.ToInt32(cmd2.ExecuteScalar());
                        objUsers.Add(new tblUsers
                        {
                            UserId = UserId,
                            LoginStatus = "1",
                            Message = "OTP Sent Successfully"
                        });
                        string content = "Your One-Time Password for Hogarbaber is " + OTP;
                        objdb.SendSMS(MobileNumber, content);
                    }
                }
                catch (Exception ex)
                {
                    objUsers.Add(new tblUsers
                    {
                        LoginStatus = "0",
                        //   Message = "Failed to validate OTP"
                        Message = ex.Message
                    });
                }
                finally
                {
                    objdb.closecon();
                }
            }
            return objUsers;
        }
        public IEnumerable<tblUsers> registerThroughEmail(string Name, string Email, string MobileNumber, string Password, string LoginType, string ProfilePicture, string Gender)
        {
            dbHelper objdb = new dbHelper();
            MySqlTransaction trans;
            trans = null;
            using (MySqlConnection cons = objdb.GetConnection())
            {
                objdb.opencon();
                trans = cons.BeginTransaction();
                try
                {
                    int id = 0;
                    MySqlCommand cmd = new MySqlCommand("insert into tblUsers(Name,UserName,Password,MobileNumber,RoleId,CreatedDate,LoginType,ProfilePicture)values(@Name,@UserName,@Password,@MobileNumber,@RoleId,@CreatedDate,@LoginType,@ProfilePicture)", cons, trans);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@UserName", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@RoleId", 9);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    cmd.Parameters.AddWithValue("@LoginType", LoginType);
                    cmd.Parameters.AddWithValue("@ProfilePicture", ProfilePicture);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.AddMinutes(750));
                    cmd.ExecuteNonQuery();
                    id = Convert.ToInt32(cmd.LastInsertedId);
                    MySqlCommand cmd2 = new MySqlCommand("insert into tblCustomers(Email,Password,ProfileName,PhoneNumber,UserId,MemberTypeId,Gender)values(@Email,@Password,@ProfileName,@PhoneNumber,@UserId,@MemberTypeId,@Gender)", cons, trans);
                    objdb.opencon();
                    cmd2.Parameters.AddWithValue("@Email", Email);
                    cmd2.Parameters.AddWithValue("@Password", Password);
                    cmd2.Parameters.AddWithValue("@ProfileName", Name);
                    cmd2.Parameters.AddWithValue("@PhoneNumber", MobileNumber);
                    cmd2.Parameters.AddWithValue("@UserId", id);
                    cmd2.Parameters.AddWithValue("@MemberTypeId", 1);
                    cmd2.Parameters.AddWithValue("@Gender", Gender);
                    cmd2.ExecuteNonQuery();

                    objUsers.Add(new tblUsers
                    {
                        Message = "Registered Successfully",
                        LoginStatus = "2",
                        UserId = id
                    });
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    objUsers.Add(new tblUsers
                    {
                        Message = "Email Already Exist",
                        // Message = ex.Message,
                        LoginStatus = "0",
                        OTP = "0",
                        UserId = 0
                    });
                    trans.Rollback();
                }
                finally
                {
                    objdb.closecon();
                }
            }
            return objUsers;
        }

        public IEnumerable<tblUsers> SearchAll(string Name)
        {
            dbHelper objdb = new dbHelper();
            using (MySqlConnection cons = objdb.GetConnection())
            {
                try
                {
                    //int id = 0;
                    MySqlCommand cmd = new MySqlCommand("Sp_SearchAll", cons);
                    objdb.opencon();
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objUsers.Add(new tblUsers
                        {
                            Id = dr["Id"].ToString(),
                            Name = dr["Name"].ToString(),
                            Type = dr["Type"].ToString(),
                            Message = "Success"
                        });
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    objUsers.Add(new tblUsers
                    {
                        Message = "Email Already Exist",
                        // Message = ex.Message,
                        OTP = "0",
                        UserId = 0
                    });
                }
                finally
                {
                    objdb.closecon();
                }
            }
            return objUsers;
        }

        //class for tblUsers
        public class tblUsers
        {
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public int DepartmentId { get; set; }
            public string RoleName { get; set; }
            public string DepartmentName { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public int BidderRegistrationId { get; set; }
            public int VendorRegistrationId { get; set; }
            public int BidderBasicDetailsId { get; set; }
            public int TenderBasicDetailsId { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
            public string StartPage { get; set; }
            public string Image { get; set; }
            public string ImagePath { get; set; }
            public string RegStatus { get; set; }
            public string Status { get; set; }
            public string AdminMobileNumber { get; set; }
            public string AdminEmail { get; set; }
            public int PageID { get; internal set; }
            public string AdminName { get; set; }
            public string OTP { get; internal set; }
            public string Type { get; internal set; }
            public string Id { get; internal set; }
            public string LoginStatus { get; internal set; }
        }

        public class UsersClass
        {
            public int UserID { get; set; }
            public string Name { get; set; }
        }

        public class clsUserPermissions
        {
            public int PageID { get; set; }
            public string PageName { get; set; }
            public string MenuName { get; set; }
            public string View { get; set; }
            public string Insert { get; set; }
            public string Edit { get; set; }
            public string Delete { get; set; }
            public string ID { get; set; }
            public int count { get; set; }
            public string UserId { get; set; }
            public string RoleName { get; set; }
            public int RoleID { get; set; }
            public int DepartmentID { get; set; }
            public string UserName { get; set; }
            public string DepartmentName { get; set; }
            public string DisplayName { get; set; }
            public string TaskName { get; set; }
            public string WorkFlowName { get; set; }
            public string FrontEndDisplay { get; internal set; }
        }

        public class tblWorkFlow
        {
            public int WorkFlowID { get; set; }
            public string WorkFlowName { get; set; }
            public int Levels { get; set; }
            public string Description { get; set; }
            public string LevelName { get; set; }
            public int LevelID { get; set; }
        }

        public class tblAuctions
        {
            public string Count { get; set; }
            public string TenderTitle { get; set; }
            public string TenderUniqueNumber { get; set; }
            public string TenderRefernceNumber { get; set; }
            public string TenderType { get; set; }
            public string AuctionDate { get; set; }
            public string AuctionStartTime { get; set; }
            public string AuctionEndTime { get; set; }
            public string AuctionPrice { get; set; }
            public string Message { get; set; }
            public string BidderName { get; set; }
            public string BidderId { get; set; }
        }
    }
}