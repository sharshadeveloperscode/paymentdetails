using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using SalonAPI.Models;

namespace Salon.Models
{
    public class FavouriteSalonsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblFavouriteSalons> obj = new List<tblFavouriteSalons>();
        
        //Add Salons to Favourites
        public string AddSalontoFavourite(string SalonId, string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into tblFavouriteSalons(SalonsId,UserId,CreatedBy,CreatedDate) values ('" + SalonId + "','" + UserId + "','" + UserId + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-mm-dd") + "')", con);
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

        // Remove Salons from Favourite
        public string RemoveSalonFromFavourite(string SalonId, string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Delete from tblFavouriteSalons where SalonsId='" + SalonId + "' and UserId='"+UserId+"'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Deleted";
            }
            catch(Exception ex)
            {
                return "Failed";
            }
            finally
            {
                con.Close();
            }
        }

        //Get Salons from Favourites
        public List<tblFavouriteSalons> GetFavouriteSalonsByUserId(string UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tf.*,ts.*, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = ts.SalonsId),0) AS Rating from tblFavouriteSalons tf inner join tblSalons ts on tf.SalonsId = ts.SalonsId where tf.UserId='" + UserId+"'", con);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    obj.Add(new tblFavouriteSalons
                    {
                        FavId = dr["FavId"].ToString(),
                        SalonsId = dr["SalonsId"].ToString(),
                        UserId = dr["UserId"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Rating = dr["Rating"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Message = "Success"
                    });
                }
                dr.Close();
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblFavouriteSalons
                {
                    Message = "Error",
                    ErrorMessage = ex.Message
                });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class tblFavouriteSalons : SalonsDAL.tblSalons
    {
        public string FavId { get; set; }
        public string SalonsId { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}