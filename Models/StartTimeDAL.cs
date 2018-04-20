using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class StartTimeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<StartTimeClass> obj = new List<StartTimeClass>();
        public IEnumerable<StartTimeClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblStartTime", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new StartTimeClass
                    {
                        StartTimeId = Convert.ToInt32(dr["StartTimeId"]),
                        StartTime = dr["StartTime"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new StartTimeClass
                    {
                        Message = "NoData"
                    });
                    return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new StartTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<StartTimeClass> GetDataById(int StartTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblStartTime where StartTimeId='" + StartTimeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new StartTimeClass
                    {
                        StartTimeId = Convert.ToInt32(dr["StartTimeId"]),
                        StartTime = dr["StartTime"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new StartTimeClass
                    {
                        Message = "NoData"
                    });
                    return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new StartTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<StartTimeClass> Insert(string StartTime, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblStartTime(StartTime,IsActive,CreatedBy,CreatedDate) values('" + StartTime + "','" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new StartTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new StartTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<StartTimeClass> Update(string StartTime, int UpdatedBy, int StartTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblStartTime set StartTime='" + StartTime + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where StartTimeId=" + StartTimeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new StartTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new StartTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<StartTimeClass> UpdateStatus(int Status, int UpdatedBy, int StartTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblStartTime set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where StartTimeId='" + StartTimeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new StartTimeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new StartTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class StartTimeClass
    {
        public int StartTimeId { get; set; }
        public string StartTime { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}