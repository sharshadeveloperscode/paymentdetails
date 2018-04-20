using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SalonAPI.Models
{
    public class TreatmentTitleDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<TreatmentTitleClass> obj = new List<TreatmentTitleClass>();
        public IEnumerable<TreatmentTitleClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.Category from tblTreatmentTitle ta,tblCategory tc where ta.CategoryId= tc.CategoryId Order by tc.Category", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Category = dr["Category"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new TreatmentTitleClass
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
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> GetDatabyId(int TreatmentTitleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.Category from tblTreatmentTitle ta,tblCategory tc where ta.CategoryId= tc.CategoryId and ta.TreatmentTitleId='" + TreatmentTitleId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        Category = dr["Category"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> GetbyCategoryId(int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.Category from tblTreatmentTitle ta,tblCategory tc where ta.CategoryId= tc.CategoryId and ta.CategoryId='" + CategoryId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        Category = dr["Category"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> GetTreatmentTitlebyCategoryId(int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblTreatmentTitle where TreatmentTitleId in(SELECT Distinct ta.TreatmentTitleId FROM tblTreatmentTitle ta, tblSalonServices ss WHERE ss.TreatmentTitleId = ta.TreatmentTitleId and ta.CategoryId = '" + CategoryId + "' and ta.IsActive = 1 and ss.IsActive = 1)", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        // Category = dr["Category"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }            
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> Insert(string TreatmentTitle, int CategoryId, int IsActive, int CreatedBy, string ImageName = null , string ImagePath = null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblTreatmentTitle(TreatmentTitle,CategoryId,IsActive,CreatedBy,CreatedDate,ImageName,ImagePath) values('" + TreatmentTitle + "'," + CategoryId + ",'" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', '" + ImageName + "', '" + ImagePath + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new TreatmentTitleClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<TreatmentTitleClass> Update(string TreatmentTitle, int CategoryId, int UpdatedBy, int TreatmentTitleId, string ImageName = null, string ImagePath = null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblTreatmentTitle set TreatmentTitle='" + TreatmentTitle + "',CategoryId=" + CategoryId + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ImageName='" + ImageName + "', ImagePath='" + ImagePath + "' where TreatmentTitleId=" + TreatmentTitleId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new TreatmentTitleClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> Delete(int TreatmentTitleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblTreatmentTitle where TreatmentTitleId='" + TreatmentTitleId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new TreatmentTitleClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<TreatmentTitleClass> UpdateStatus(int Status, int UpdatedBy, int TreatmentTitleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblTreatmentTitle set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where TreatmentTitleId='" + TreatmentTitleId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new TreatmentTitleClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<TreatmentTitleClass> GetbyCategoryIdByIsActvive(int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ta.*, tc.Category FROM tblTreatmentTitle ta, tblCategory tc WHERE ta.IsActive='1' AND ta.CategoryId = tc.CategoryId AND ta.CategoryId = '" + CategoryId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        Category = dr["Category"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<TreatmentTitleClass> GetDataIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.Category from tblTreatmentTitle ta,tblCategory tc where ta.CategoryId= tc.CategoryId AND tc.IsActive='1' AND ta.IsActive='1' Order by tc.Category", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new TreatmentTitleClass
                    {
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImageName = dr["ImageName"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Category = dr["Category"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new TreatmentTitleClass
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
                    obj.Add(new TreatmentTitleClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new TreatmentTitleClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class TreatmentTitleClass
    {
        public int TreatmentTitleId { get; set; }
        public string TreatmentTitle { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}