using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class Test
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<TestClass> obj = new List<TestClass>();
        public IEnumerable<TestClass> Insert(string Image, string ImagePath)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblTest(Image,ImagePath) values('"+ Image + "','"+ImagePath+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new TestClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new TestClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TestClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TestClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<TestClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblTest ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TestClass
                    {
                        Image = dr["Image"].ToString(),
                        ImagePath=dr["ImagePath"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new TestClass
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
                    obj.Add(new TestClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TestClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TestClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class TestClass
    {
        // public string CityName { get; set; }

        public string Image { get; set; }
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}