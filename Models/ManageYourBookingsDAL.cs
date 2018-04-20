using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class ManageYourBookingsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<ManageYourBookingsClass> obj = new List<ManageYourBookingsClass>();
        public IEnumerable<ManageYourBookingsClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblManageYourBooking", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ManageYourBookingsClass
                    {
                        BookingsId = Convert.ToInt32(dr["BookingsId"]),
                        BookingsName = dr["BookingsName"].ToString(),
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
                    obj.Add(new ManageYourBookingsClass
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
                    obj.Add(new ManageYourBookingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ManageYourBookingsClass> GetbyId(int BookingsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblManageYourBooking where BookingsId='" + BookingsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ManageYourBookingsClass
                    {
                        BookingsId = Convert.ToInt32(dr["BookingsId"]),
                        BookingsName = dr["BookingsName"].ToString(),
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
                    obj.Add(new ManageYourBookingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ManageYourBookingsClass> Insert(string BookingsName, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblManageYourBooking(BookingsName,IsActive,CreatedBy,CreatedDate) values('" + BookingsName + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new ManageYourBookingsClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new ManageYourBookingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<ManageYourBookingsClass> Update(string BookingsName, int UpdatedBy, int BookingsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblManageYourBooking set BookingsName='" + BookingsName + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where BookingsId=" + BookingsId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new ManageYourBookingsClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new ManageYourBookingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ManageYourBookingsClass> Delete(int BookingsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblManageYourBooking where BookingsId='" + BookingsId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new ManageYourBookingsClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new ManageYourBookingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<ManageYourBookingsClass> UpdateStatus(int Status, int UpdatedBy, int BookingsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblManageYourBooking set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where BookingsId='" + BookingsId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new ManageYourBookingsClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new ManageYourBookingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class ManageYourBookingsClass
    {
        public int BookingsId { get; set; }
        public string BookingsName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}