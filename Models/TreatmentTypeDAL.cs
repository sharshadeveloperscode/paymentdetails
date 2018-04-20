using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SalonAPI.Models
{
    public class TreatmentTypeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblTreatmentType> obj = new List<tblTreatmentType>();

        public IEnumerable<tblTreatmentType> GetData()
        {
            try
            {
               // MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.TreatmentTitle from tblTreatmentType ta,tblTreatmentTitle tc where ta.TreatmentTitleId= tc.TreatmentTitleId ", con);
                 MySqlCommand cmd = new MySqlCommand("SELECT ta.*, tc.TreatmentTitle,tl.Category FROM tblCategory tl, tblTreatmentType ta, tblTreatmentTitle tc WHERE  ta.TreatmentTitleId = tc.TreatmentTitleId AND tl.CategoryId = tc.CategoryId ", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblTreatmentType
                    {
                        TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new tblTreatmentType
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
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //GetDataByID
        public IEnumerable<tblTreatmentType> GetDatabyId(int TreatmentTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.TreatmentTitle,tcg.CategoryId from tblTreatmentType ta,tblTreatmentTitle tc ,tblCategory tcg where tcg.CategoryId=tc.CategoryId and ta.TreatmentTitleId= tc.TreatmentTitleId and ta.TreatmentTypeId='" + TreatmentTypeId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblTreatmentType
                    {
                        TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<tblTreatmentType> GetbyTreatmentTitleId(int TreatmentTitleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.TreatmentTitle from tblTreatmentType ta,tblTreatmentTitle tc where ta.TreatmentTitleId= tc.TreatmentTitleId and ta.TreatmentTitleId='" + TreatmentTitleId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblTreatmentType
                    {
                        TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //Insert
        public IEnumerable<tblTreatmentType> Insert(string TreatmentType, int TreatmentTitleId, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblTreatmentType(TreatmentType,TreatmentTitleId,IsActive,CreatedBy,CreatedDate) values('" + TreatmentType + "'," + TreatmentTitleId + ",'" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblTreatmentType { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<tblTreatmentType> Update(string TreatmentType, int TreatmentTitleId, int UpdatedBy, int TreatmentTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblTreatmentType set TreatmentType='" + TreatmentType + "',TreatmentTitleId=" + TreatmentTitleId + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where TreatmentTypeId=" + TreatmentTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblTreatmentType { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<tblTreatmentType> Delete(int TreatmentTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblTreatmentType where TreatmentTypeId='" + TreatmentTypeId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblTreatmentType { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<tblTreatmentType> UpdateStatus(int Status, int UpdatedBy, int TreatmentTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblTreatmentType set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where TreatmentTypeId='" + TreatmentTypeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new tblTreatmentType { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<tblTreatmentType> GetDatabyIdByIsActive(int TreatmentTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" SELECT ta.*, tc.TreatmentTitle, tcg.CategoryId FROM tblTreatmentType ta, tblTreatmentTitle tc, tblCategory tcg WHERE ta.IsActive='1' AND tcg.CategoryId = tc.CategoryId AND ta.TreatmentTitleId = tc.TreatmentTitleId AND ta.TreatmentTypeId ='" + TreatmentTypeId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblTreatmentType
                    {
                        TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<tblTreatmentType> GetbyTreatmentTitleIdByIsActive(int TreatmentTitleId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ta.*, tc.TreatmentTitle FROM tblTreatmentType ta, tblTreatmentTitle tc WHERE ta.IsActive='1' AND tc.IsActive='1' AND ta.TreatmentTitleId = tc.TreatmentTitleId AND ta.TreatmentTitleId ='" + TreatmentTitleId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblTreatmentType
                    {
                        TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new tblTreatmentType { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblTreatmentType { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class tblTreatmentType
    {
        public int TreatmentTypeId { get; set; }
        public string TreatmentType { get; set; }
        public int TreatmentTitleId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string TreatmentTitle { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public String Category { get; set; }

        public int CategoryId { get; set; }
    }
}