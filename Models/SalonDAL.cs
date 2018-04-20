using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SalonAPI.Models
{
    public class SalonDAL
    {
        List<salonAutoService> result = new List<salonAutoService>();
        List<HairSalonDetails> hairsalon = new List<HairSalonDetails>();
        List<salonOverView> overview = new List<salonOverView>();
        List<salonOverView> salonview = new List<salonOverView>();
        List<EVoucher> voucher = new List<EVoucher>();
        List<EVoucher> getvoucher = new List<EVoucher>();
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);


        public IEnumerable<salonAutoService> GetAutoServicesData(string servicename)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("select name from business where name LIKE '%" + servicename + "%'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new salonAutoService
                    {
                        Name = dr["name"].ToString()
                       
                    });
                }
                return result;

            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    result.Add(new salonAutoService { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return result;
                }
                else
                {
                    result.Add(new salonAutoService { Message = "Error", ErrorMessage = ex.Message });
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Add(new salonAutoService { Message = "Error", ErrorMessage = ex.Message });
                return result;
            }
            finally
            {
                con.Close();
            }
            
        }
        public IEnumerable<HairSalonDetails> GetSalonsList(string servicename)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct b.id,s.id,b.name,b.opening_hours,b.appointment_address,b.description,s.title,b.image,s.price,s.duration from business b,services s,service_category sc where type_id='" + servicename + "' and b.id=s.business_id", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hairsalon.Add(new HairSalonDetails()
                    {
                        Name = dr["name"].ToString(),
                        BusinessId = dr["id"].ToString(),
                        ServiceId = dr[1].ToString(),
                        Title = dr["title"].ToString(),
                        Price = dr["price"].ToString(),
                        Image = dr["image"].ToString(),
                        Duration = dr["duration"].ToString(),
                        Description = dr["description"].ToString(),
                        Address = dr["appointment_address"].ToString(),
                        OpeningHours = dr["opening_hours"].ToString()
                    });

                }
                return hairsalon;
            }
            catch (Exception ex)
            {
                hairsalon.Add(new HairSalonDetails { Message = "Error", ErrorMessage = ex.Message });
                return hairsalon;
            }
            finally
            {
                con.Close();
            }
        }
        //public string ConvertBytesToBase64(byte[] imageBytes)
        //{
          //  return Convert.ToBase64String(imageBytes);
        //}
        public  List<salonOverView> GetSalonsOverView()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct mraRating,mraComment,fname from Mreview,users where id=mraUserId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    overview.Add(new salonOverView
                    {
                        UName = dr["fname"].ToString(),
                        Rating = dr["mraRating"].ToString(),
                        Review = dr["mraComment"].ToString()
                    });
                }
                return overview;
            }
            catch (Exception ex)
            {
                overview.Add(new salonOverView { Message = "Error", ErrorMessage = ex.Message });
                return overview;
            }
            finally
            {
                con.Close();
            }
        }
        public  List<salonOverView> GetSalonsOverViews(string BusinessId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select mraRating,mraComment,fname from Mreview r,users u where mraBussinessId='" + BusinessId + "' and r.mraUserId=u.id", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    salonview.Add(new salonOverView
                    {
                        UName = dr["fname"].ToString(),
                        Rating = dr["mraRating"].ToString(),
                        Review = dr["mraComment"].ToString()
                    });
                }
                return salonview;
            }
            catch (Exception ex)
            {
                salonview.Add(new salonOverView { Message = "Error", ErrorMessage = ex.Message });
                return salonview;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<EVoucher> GetAppointment()
        {
            try { 
            MySqlCommand cmd = new MySqlCommand("SELECT s.title,s.price FROM `services` s,service_category sc where s.`service_category_id`=sc.id",con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                voucher.Add(new EVoucher
                {
                    Title = dr["title"].ToString(),
                    Price = dr["price"].ToString()
                });
            }
            return voucher;
            }
            catch (Exception ex)
            {
                voucher.Add(new EVoucher { Message = "Error", ErrorMessage = ex.Message });
                return voucher;
            }
            finally
            {
                con.Close();
            }
        }



        // Mallesh 


        // for Checking Email

        public List<salonAutoService> GetEmailDetails(string Email)
        {


            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT email FROM users where email='" + Email + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if(!dr.HasRows)
                {
                    result.Add(new salonAutoService
                    {
                        Message = "0"

                    });
                }
                else
                {
                    result.Add(new salonAutoService
                    {
                        Message = "1"

                    });
                }
               
                return result;
            }
            catch (Exception)
            {
                result.Add(new salonAutoService { Message = "Error" });
                return result;
            }
            finally
            {
                con.Close();
            }


            //int result;
            //string constr = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("SELECT email FROM users where email='" + Email + "'"))
            //    {
            //        using (MySqlDataAdapter sda = new MySqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                if (dt.Rows.Count > 0)
            //                {
            //                    result = 1;
            //                }
            //                else
            //                {
            //                    result = 0;
            //                }
            //            }
            //        }
            //    }
            //}
            //return result;
        }

      


        public class profileDetails
        {
            public string SName { get; set; }
            public string Date { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class profileDetail
        {
            public string service { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string ServiceId { get; set; }

            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class cutomerlog
        {
            public string Name { get; set; }
            public string Image { get; set; }
            public string SName { get; set; }
            public string Date { get; set; }
            public string Balance { get; set; }
            public string UName { get; set; }
            public string Message { get; set; }
            public string Loyalty { get; set; }
            public string ErrorMessage { get; set; }

        }
        public class SalonDetails
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Image { get; set; }
            public string Address { get; set; }
            public string Duration { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class Gallery
        {
            public string Image { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class Appointment
        {
            public string Title { get; set; }
            public string Price { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class EVoucher
        {
            public string Title { get; set; }
            public string Price { get; set; }
            public string Name { get; set; }
            public string Duration { get; set; }
            public string FirstName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class EVouchers
        {
            public string Title { get; set; }
            public string Price { get; set; }
            public string Name { get; set; }
            public string Duration { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class PlaceOrder
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Price { get; set; }
            public string Duration { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }

        }
        public class salonOverView
        {
            public string Rating { get; set; }
            public string Review { get; set; }
            public string UName { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class SalonServices
        {
            public string Name { get; set; }
            public string Image { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class SalonServicesDetails
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Description { get; set; }
            public string Duration { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class SalonServicesReview
        {
            public string Rating { get; set; }
            public string Review { get; set; }
            public string Name { get; set; }
            public string Duration { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class NearYouSalonDetails
        {
            public string Description { get; set; }
            public string SName { get; set; }
            public string Image { get; set; }
            public string Price { get; set; }
            public string Duration { get; set; }
            public string Title { get; set; }
            public string PName { get; set; }
            public string Rating { get; set; }
            public string Comment { get; set; }
            public string Address { get; set; }
            public string OpeningHours { get; set; }
            public string BusinessId { get; set; }
            public string ServiceId { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class ProfileDetails
        {
            public string PName { get; set; }
            public string Address { get; set; }
            public string PImage { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string WAmount { get; set; }
            public string Booking { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class HairSalonDetails
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Image { get; set; }
            public string Address { get; set; }
            public string Duration { get; set; }
            public string Description { get; set; }
            public string Title { get; set; }
            public string ServiceId { get; set; }
            public string BusinessId { get; set; }
            public string OpeningHours { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class OrderDetails
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Address { get; set; }
            public string Title { get; set; }
            public string PostalCode { get; set; }
            public string EName { get; set; }
            public string Time { get; set; }
            public string ETime { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class ConfirmOrder
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Duration { get; set; }
            public string Employee { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class salonAutoService
        {
            public string Name { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
            
        }


    }
}