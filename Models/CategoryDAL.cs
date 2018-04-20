using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace SalonAPI.Models
{
    public class CategoryDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblCategory> Obj = new List<tblCategory>();

        public IEnumerable<tblCategory> GetCategory()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCategory", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Obj.Add(new tblCategory
                    {
                        CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        Category = dt.Rows[i]["Category"].ToString(),
                        ImageName = dt.Rows[i]["ImageName"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                       // UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    Obj.Add(new tblCategory { Message = "NoData" });
                    return Obj;
                }
                return Obj;
            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }

        public IEnumerable<tblCategory> GetCategoryById(int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCategory where CategoryId=" + CategoryId, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Obj.Add(new tblCategory
                    {
                        CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        Category = dt.Rows[i]["Category"].ToString(),
                        ImageName = dt.Rows[i]["ImageName"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return Obj;
            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }



        public IEnumerable<tblCategory> UpdateCategory(string Category,string ImageName,string ImagePath, int UpdatedBy, int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCategory set Category='" + Category + "',ImageName='" + ImageName + "',ImagePath='" + ImagePath + "', UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where CategoryId='" + CategoryId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Obj.Add(new tblCategory { Message = "Success" });
                return Obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    Obj.Add(new tblCategory { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return Obj;
                }
                else
                {
                    Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                    return Obj;
                }

            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }

        public IEnumerable<tblCategory> InsertCategory(string Category, string ImageName, string ImagePath, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblCategory(Category,ImageName,ImagePath,IsActive,CreatedBy,CreatedDate) values('" + Category + "','" + ImageName + "','" + ImagePath + "', '" + 1 + "', '" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Obj.Add(new tblCategory { Message = "Success" });
                return Obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    Obj.Add(new tblCategory { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return Obj;
                }
                else
                {
                    Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                    return Obj;
                }

            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }


        public IEnumerable<tblCategory> DeleteCategory(int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblCategory where CategoryId='" + CategoryId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Obj.Add(new tblCategory { Message = "Success" });
                return Obj;
            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }


        public IEnumerable<tblCategory> UpdateStatus(int Status, int UpdatedBy, int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCategory set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where CategoryId='" + CategoryId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Obj.Add(new tblCategory { Message = "Success" });
                return Obj;
            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }
        public IEnumerable<tblCategory> GetCategoryByIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCategory tc where tc.IsActive='1'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Obj.Add(new tblCategory
                    {
                        CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        Category = dt.Rows[i]["Category"].ToString(),
                        ImageName = dt.Rows[i]["ImageName"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        // UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    Obj.Add(new tblCategory { Message = "NoData" });
                    return Obj;
                }
                return Obj;
            }
            catch (Exception ex)
            {
                Obj.Add(new tblCategory { Message = "Error", ErrorMessage = ex.Message });
                return Obj;
            }
        }


        //class for tblCategory
        public class tblCategory
        {
            public string Category { get; set; }
            public string ImageName { get; set; }
            public string ImagePath { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public int CategoryId { get; set; }
            public int IsActive { get; set; }

            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }

    }
}