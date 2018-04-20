using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SalonAPI.Models
{
    public class NewsLetterDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<NewsLetterClass> obj = new List<NewsLetterClass>();
        public IEnumerable<NewsLetterClass> GetNewsletterSubscribers()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCustomers where Newsletter=1" , con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new NewsLetterClass
                    {
                        CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]),

                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                      //  PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                       // PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                     //   ProfileName = dt.Rows[i]["FirstName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                     //   Note = dt.Rows[i]["Note"].ToString(),
                     //   Password = dt.Rows[i]["Password"].ToString(),
                     //   UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                     //   Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                    //    MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                    //    CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                     //   UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new NewsLetterClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<NewsLetterClass> UpdateNewsletter(string Newsletter, int CustomerId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCustomers set Newsletter='" + Newsletter + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where CustomerId='" + CustomerId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new NewsLetterClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new NewsLetterClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class NewsLetterClass
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Newsletter { get; set; }
        public int IsActive { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}