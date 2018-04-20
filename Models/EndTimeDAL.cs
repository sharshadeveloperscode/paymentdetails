using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class EndTimeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<EmdTimeClass> obj = new List<EmdTimeClass>();
        public IEnumerable<EmdTimeClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblEndTime", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new EmdTimeClass
                    {
                        EndTimeId = Convert.ToInt32(dr["EndTimeId"]),
                        EndTime = dr["EndTime"].ToString(),
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
                    obj.Add(new EmdTimeClass
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
                    obj.Add(new EmdTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmdTimeClass> GetDataById(int EndTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblEndTime where EndTimeId='" + EndTimeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new EmdTimeClass
                    {
                        EndTimeId = Convert.ToInt32(dr["EndTimeId"]),
                        EndTime = dr["EndTime"].ToString(),
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
                    obj.Add(new EmdTimeClass
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
                    obj.Add(new EmdTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmdTimeClass> Insert(string EndTime, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblEndTime(EndTime,IsActive,CreatedBy,CreatedDate) values('" + EndTime + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new EmdTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new EmdTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<EmdTimeClass> Update(string EndTime, int UpdatedBy, int EndTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEndTime set EndTime='" + EndTime + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where EndTimeId=" + EndTimeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new EmdTimeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new EmdTimeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmdTimeClass> UpdateStatus(int Status, int UpdatedBy, int EndTimeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEndTime set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where EndTimeId='" + EndTimeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new EmdTimeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new EmdTimeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class EmdTimeClass
    {
        public int EndTimeId { get; set; }
        public string EndTime { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}