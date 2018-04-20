using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class SigningDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SigningClass> obj = new List<SigningClass>();
        public IEnumerable<SigningClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblReasonforSigningup", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SigningClass
                    {
                        SigningId = Convert.ToInt32(dr["SigningId"]),
                        SigningupName = dr["SigningupName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SigningClass
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
                    obj.Add(new SigningClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SigningClass> GetbyId(int SigningupId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblReasonforSigningup where SigningId='" + SigningupId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SigningClass
                    {
                        SigningId = Convert.ToInt32(dr["SigningId"]),
                        SigningupName = dr["SigningupName"].ToString(),
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
                    obj.Add(new SigningClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SigningClass> Insert(string SigningupName, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblReasonforSigningup(SigningupName,IsActive,CreatedBy,CreatedDate) values('" + SigningupName + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SigningClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SigningClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SigningClass> Update(string SigningupName, int UpdatedBy, int SigningupId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblReasonforSigningup set SigningupName='" + SigningupName + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where SigningId=" + SigningupId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SigningClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SigningClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SigningClass> Delete(int SigningupId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblReasonforSigningup where SigningId='" + SigningupId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SigningClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SigningClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SigningClass> UpdateStatus(int Status, int UpdatedBy, int SigningupId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblReasonforSigningup set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SigningId='" + SigningupId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SigningClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SigningClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class SigningClass
    {
        public int SigningId { get; set; }
        public string SigningupName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}