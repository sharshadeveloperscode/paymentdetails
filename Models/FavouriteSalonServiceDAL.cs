using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using SalonAPI.Models;


namespace Salon.Models
{
    public class FavouriteSalonServiceDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblFavouriteSalonService> obj = new List<tblFavouriteSalonService>();

        // Add Services to Favourite
        public string AddServicestoFavourites(string SalonServicesId, string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into tblFavouriteSalonService(SalonServicesId,UserId,CreatedBy,CreatedDate) values('" + SalonServicesId + "','" + UserId + "','" + UserId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error";
            }
            finally
            {
                con.Close();
            }
        }

        //Delete Service from Favourite

        public string RemoveServicefromFavourite(string SalonServicesId, string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Delete from tblFavouriteSalonService where SalonServicesId='" + SalonServicesId + "' and UserId='" + UserId + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Deleted";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }
        }

        // Get salon Service by User Id
        public List<tblFavouriteSalonService> GetSalonServicesByUserId(string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tfs.*,tss.* from tblFavouriteSalonService tfs inner join tblSalonServices tss on tfs.SalonServicesId = tss.SalonServicesId where tfs.UserId ='" + UserId + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblFavouriteSalonService
                    {
                        FavId = dr["FavId"].ToString(),
                        UserId = dr["UserId"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),

                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        Description = dr["Description"].ToString(),

                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        Message = "Success",
                    });
                }
                dr.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public string AddServiceToCart(int SalonServicesId, int UserId, int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into tblCart(SalonServicesId,UserId,SalonsId,CreatedDate) values('" + SalonServicesId + "','" + UserId + "','" + SalonsId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string AddServiceToCart(int SalonServicesId, int UserId, int SalonsId, DateTime BookingDate, string BookingTime, int Chairs=0, int EmployeeServicesId = 0)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into tblCart(SalonServicesId,UserId,SalonsId,CreatedDate,EmployeeServicesId,BookingDate,BookingTime,Chairs) values('" + SalonServicesId + "','" + UserId + "','" + SalonsId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "'," + EmployeeServicesId + ",'" + Convert.ToDateTime(BookingDate).ToString("yyyy-MM-dd") + "','" + BookingTime + "'," + Chairs + ")", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServiceFromCart(int CartId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblCart where CartId=" + CartId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServiceFromCart(int UserId, int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"delete from tblCart where UserId={UserId} and SalonsId={SalonsId}", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServicesFromCartByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblCart where UserId=" + UserId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public List<tblFavouriteSalonService> GetCartServices(string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCart c inner join tblSalonServices ss on c.SalonServicesId=ss.SalonServicesId inner join tblSalons s on s.SalonsId=c.SalonsId where c.UserId="+UserId+"", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                int carttotal = 0;
                while (dr.Read())
                {
                    carttotal = carttotal + Convert.ToInt32(dr["Price"].ToString());
                    obj.Add(new tblFavouriteSalonService
                    {
                        CartId = dr["CartId"].ToString(),
                        UserId = dr["UserId"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Price = dr["Price"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CartTotal= carttotal,
                        EmployeeServicesId = String.IsNullOrEmpty(dr["EmployeeServicesId"].ToString()) ? 0 : Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingDate = Convert.ToDateTime(dr["BookingDate"]),
                        BookingTime = dr["BookingTime"].ToString(),
                        Chairs = String.IsNullOrEmpty(dr["Chairs"].ToString()) ? 0 : Convert.ToInt32(dr["Chairs"]),
                        Message = "Success",
                    });
                }
                dr.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public List<tblFavouriteSalonService> GetCartServices(string UserId, string SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCart c inner join tblSalonServices ss on c.SalonServicesId=ss.SalonServicesId inner join tblSalons s on s.SalonsId=c.SalonsId where c.UserId=" + UserId + " and c.SalonsId=" + SalonsId + "", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                int carttotal = 0;
                while (dr.Read())
                {
                    carttotal = carttotal + Convert.ToInt32(dr["Price"].ToString());
                    obj.Add(new tblFavouriteSalonService
                    {
                        CartId = dr["CartId"].ToString(),
                        UserId = dr["UserId"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Price = dr["Price"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CartTotal = carttotal,
                        EmployeeServicesId = String.IsNullOrEmpty(dr["EmployeeServicesId"].ToString()) ? 0 : Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingDate = Convert.ToDateTime(dr["BookingDate"]),
                        BookingTime = dr["BookingTime"].ToString(),
                        Chairs = String.IsNullOrEmpty(dr["Chairs"].ToString()) ? 0 : Convert.ToInt32(dr["Chairs"]),
                        Message = "Success",
                    });
                }
                dr.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public string AddServiceToSaveForLater(int SalonServicesId, int UserId, int SalonsId,int CartId)
        {
            try
            {
                MySqlCommand cmd2 = new MySqlCommand("delete from tblCart where CartId="+CartId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand("Insert into tblSaveForLater(SalonServicesId,UserId,SalonsId,CreatedDate) values('" + SalonServicesId + "','" + UserId + "','" + SalonsId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string AddServiceToSaveForLater(int SalonServicesId, int UserId, int SalonsId, int CartId, DateTime BookingDate, string BookingTime, int Chairs = 0, int EmployeeServicesId = 0)
        {
            try
            {
                MySqlCommand cmd2 = new MySqlCommand("delete from tblCart where CartId=" + CartId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand("Insert into tblSaveForLater(SalonServicesId,UserId,SalonsId,CreatedDate,EmployeeServicesId,BookingDate,BookingTime,Chairs) values('" + SalonServicesId + "','" + UserId + "','" + SalonsId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "'," + EmployeeServicesId + ",'" + Convert.ToDateTime(BookingDate).ToString("yyyy-MM-dd") + "','" + BookingTime + "'," + Chairs + ")", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServiceFromSaveForLater(int SaveForLaterId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSaveForLater where SaveForLaterId=" + SaveForLaterId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServiceFromSaveForLater(int UserId, int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"delete from tblSaveForLater where UserId={UserId} and SalonsId={SalonsId}", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteServicesFromSaveForLaterByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSaveForLater where UserId=" + UserId, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }
        }

        public List<tblFavouriteSalonService> GetSaveForLaterServices(string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSaveForLater c inner join tblSalonServices ss on c.SalonServicesId=ss.SalonServicesId inner join tblSalons s on s.SalonsId=c.SalonsId where c.UserId=" + UserId + "", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblFavouriteSalonService
                    {
                        SaveForLaterId = dr["SaveForLaterId"].ToString(),
                        UserId = dr["UserId"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Message = "Success",
                    });
                }
                dr.Close();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



    }

    public class tblFavouriteSalonService : SalonServicesClass
    {
        public string FavId { get; set; }
        public string SalonServicesId { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpadatedBy { get; set; }
        public string CartId { get; internal set; }
        public string BusinessName { get; internal set; }
        public string SaveForLaterId { get; internal set; }
        public int CartTotal { get; internal set; }
        public int EmployeeServicesId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int Chairs { get; set; }
    }
}