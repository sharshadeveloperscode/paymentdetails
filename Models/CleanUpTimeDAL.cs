using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace SalonAPI.Models
{
    public class CleanUpTimeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<CleanUpTimeClass> obj = new List<CleanUpTimeClass>();
        public IEnumerable<CleanUpTimeClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCleanUpTime", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new CleanUpTimeClass
                    {
                        CleanUpTimeId = Convert.ToInt32(dr["CleanUpTimeId"]),
                        CleanUpTime = dr["CleanUpTime"].ToString(),
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
                    obj.Add(new CleanUpTimeClass
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
                    obj.Add(new CleanUpTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<CleanUpTimeClass> GetbyId(int CleanUpTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCleanUpTime where CleanUpTimeId='" + CleanUpTimeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new CleanUpTimeClass
                    {
                        CleanUpTimeId = Convert.ToInt32(dr["CleanUpTimeId"]),
                        CleanUpTime = dr["CleanUpTime"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new CleanUpTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<CleanUpTimeClass> Insert(string CleanUpTime, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblCleanUpTime(CleanUpTime,IsActive,CreatedBy,CreatedDate) values('" + CleanUpTime + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new CleanUpTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new CleanUpTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<CleanUpTimeClass> Update(string CleanUpTime, int UpdatedBy, int CleanUpTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCleanUpTime set CleanUpTime='" + CleanUpTime + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where CleanUpTimeId=" + CleanUpTimeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new CleanUpTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new CleanUpTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<CleanUpTimeClass> UpdateStatus(int Status, int UpdatedBy, int CleanUpTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCleanUpTime set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where CleanUpTimeId='" + CleanUpTimeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new CleanUpTimeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new CleanUpTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class CleanUpTimeClass
    {
        public int CleanUpTimeId { get; set; }
        public string CleanUpTime { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}