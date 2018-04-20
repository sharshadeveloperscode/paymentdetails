using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class ClassesDAL
    {
        public string SaveClass(string ClassName, int UserId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into tblClasses(ClassName,Status,CreatedBy,CreatedDate)values(@ClassName,@Status,@CreatedBy,@CreatedDate)", con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Parameters.AddWithValue("@ClassName", ClassName);
                        cmd.Parameters.AddWithValue("@Status", 1);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserId);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToUniversalTime());
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                return "Success";
            }
            catch (Exception)
            {
                return "Class Name already exist";
            }
            finally
            {

            }

        }

        public string UpdateClass(string ClassName, int UserId, int ClassId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("update tblClasses set ClassName=@ClassName,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate where ClassId=@ClassId", con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Parameters.AddWithValue("@ClassName", ClassName);
                        cmd.Parameters.AddWithValue("@UpdatedBy", UserId);
                        cmd.Parameters.AddWithValue("@ClassId", ClassId);
                        cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now.ToUniversalTime());
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                return "Success";
            }
            catch (Exception)
            {
                return "Class Name already exist";
            }
            finally
            {

            }
        }

        public string UpdateClassStatus(int Status, int ClassId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("update tblClasses set Status=@Status where ClassId=@ClassId", con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@ClassId", ClassId);
                        cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now.ToUniversalTime());
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                return "Success";
            }
            catch (Exception)
            {
                return "Failed to update Status";
            }
            finally
            {

            }
        }

        public IEnumerable<tblClasses> GetClasses()
        {
            List<tblClasses> obj = new List<tblClasses>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select * from tblClasses", con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            obj.Add(new tblClasses
                            {
                                ClassId = dr["ClassId"].ToString(),
                                ClassName = dr["ClassName"].ToString(),
                                Status = dr["Status"].ToString(),
                                Message = "Success"
                            });
                        }
                        dr.Close();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                obj.Add(new tblClasses
                {
                    Message = "Fail"
                });
            }
            finally
            {

            }
            return obj;
        }

        public IEnumerable<tblClasses> GetActiveClasses()
        {
            List<tblClasses> obj = new List<tblClasses>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select * from tblClasses where Status = 1", con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            obj.Add(new tblClasses
                            {
                                ClassId = dr["ClassId"].ToString(),
                                ClassName = dr["ClassName"].ToString(),
                                Status = dr["Status"].ToString(),
                                Message = "Success"
                            });
                        }
                        dr.Close();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                obj.Add(new tblClasses
                {
                    Message = "Fail"
                });
            }
            finally
            {

            }
            return obj;
        }

        public IEnumerable<tblClasses> GetClassById(int ClassId)
        {
            List<tblClasses> obj = new List<tblClasses>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select * from tblClasses where ClassId="+ ClassId, con))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            obj.Add(new tblClasses
                            {
                                ClassId = dr["ClassId"].ToString(),
                                ClassName = dr["ClassName"].ToString(),
                                Status = dr["Status"].ToString(),
                                Message = "Success"
                            });
                        }
                        dr.Close();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                obj.Add(new tblClasses
                {
                    Message = "Fail"
                });
            }
            finally
            {

            }
            return obj;
        }
    }

    public class tblClasses
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}