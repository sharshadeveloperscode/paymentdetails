using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace SalonAPI.Models
{
    public class RoleDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblRoles> objRoles = new List<tblRoles>();

        public IEnumerable<tblRoles> GetRoles()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblRole", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objRoles.Add(new tblRoles
                    {
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Status = Convert.ToInt32(dt.Rows[i]["Status"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objRoles.Add(new tblRoles { Message = "NoData" });
                    return objRoles;
                }
                return objRoles;
            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }

        public IEnumerable<tblRoles> GetRoleById(int RoleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblRole where RoleId=" + RoleId, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objRoles.Add(new tblRoles
                    {
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        Status = Convert.ToInt32(dt.Rows[i]["Status"]),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return objRoles;
            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }

        public IEnumerable<tblRoles> GetRoleByDepartment(int DepartmentId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tr.*,td.DepartmentName from tblRole tr,tblDepartment td where tr.DepartmentId = td.DepartmentId and tr.DepartmentId = '" + DepartmentId + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objRoles.Add(new tblRoles
                    {
                        RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return objRoles;
            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }


        public IEnumerable<tblRoles> UpdateRoles(string RoleName,  int UpdatedBy, int RoleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblRole set RoleName='" + RoleName + "', UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where RoleId='" + RoleId + "' ", con);
                con.Open(); 
                cmd.ExecuteNonQuery();
                con.Close();
                objRoles.Add(new tblRoles { Message = "Success" });
                return objRoles;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objRoles.Add(new tblRoles { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objRoles;
                }
                else
                {
                    objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                    return objRoles;
                }

            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }

        public IEnumerable<tblRoles> InsertRoles(string RoleName, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblRole(RoleName,Status,CreatedBy,CreatedDate) values('" + RoleName + "','" + 1 + "', '" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objRoles.Add(new tblRoles { Message = "Success" });
                return objRoles;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    objRoles.Add(new tblRoles { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objRoles;
                }
                else
                {
                    objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                    return objRoles;
                }

            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }


        public IEnumerable<tblRoles> DeleteRole(int RoleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblRole where RoleId='"+RoleId+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objRoles.Add(new tblRoles { Message = "Success" });
                return objRoles;
            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }


        public IEnumerable<tblRoles> UpdateStatus(int Status, int UpdatedBy, int RoleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblRole set Status='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where RoleId='" + RoleId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                objRoles.Add(new tblRoles { Message = "Success" });
                return objRoles;
            }
            catch (Exception ex)
            {
                objRoles.Add(new tblRoles { Message = "Error", ErrorMessage = ex.Message });
                return objRoles;
            }
        }



        //class for tblRoles
        public class tblRoles
        {
            public string RoleName { get; set; }
            
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public int RoleId { get; set; }
            public int Status { get; set; }
          
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }

    }
}