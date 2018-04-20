using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class DurationDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<DurationClass> obj = new List<DurationClass>();
        public IEnumerable<DurationClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblDuration order by DurationId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new DurationClass
                    {
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        Duration = dr["Duration"].ToString(),
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
                    obj.Add(new DurationClass
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
                    obj.Add(new DurationClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<DurationClass> GetbyId(int DurationId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblDuration where DurationId='" + DurationId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new DurationClass
                    {
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        Duration = dr["Duration"].ToString(),
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
                    obj.Add(new DurationClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<DurationClass> Insert(string Duration, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblDuration(Duration,IsActive,CreatedBy,CreatedDate) values('" + Duration + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new DurationClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new DurationClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<DurationClass> Update(string Duration, int UpdatedBy, int DurationId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblDuration set Duration='" + Duration + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where DurationId=" + DurationId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new DurationClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new DurationClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<DurationClass> UpdateStatus(int Status, int UpdatedBy, int DurationId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblDuration set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where DurationId='" + DurationId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new DurationClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new DurationClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class DurationClass
    {
        public int DurationId { get; set; }
        public string Duration { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}