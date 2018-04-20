using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SalonAPI.Models
{
    public class AreaDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<Areaclass> obj = new List<Areaclass>();
        //GetData
        public IEnumerable<Areaclass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.CityName from tblArea ta,tblCity tc where ta.CityId= tc.CityId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        AreaName = dr["AreaName"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        IsActive= Convert.ToInt32(dr["IsActive"]),
                        CreatedBy= Convert.ToInt32(dr["CreatedBy"]),
                       // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate= dr["CreatedDate"].ToString(),
                      //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                         PostCode =dr["PostCode"].ToString(),
                        Message ="Success",
               
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new Areaclass
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
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Areaclass> GetPostCodes()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select PostCode from tblArea where IsActive=1  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        PostCode = dr["PostCode"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new Areaclass
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
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Areaclass> GetDataByIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ta.*, tc.CityName FROM tblArea ta, tblCity tc WHERE ta.IsActive='1' AND tc.IsActive='1' AND ta.CityId = tc.CityId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        AreaName = dr["AreaName"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        PostCode=dr["PostCode"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new Areaclass
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
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //GetDataByID
        public IEnumerable<Areaclass> GetDatabyId(int Areaid)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ta.* ,tc.CityName from tblArea ta,tblCity tc where ta.CityId= tc.CityId and ta.AreaId='" + Areaid+"'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        AreaName = dr["AreaName"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                       // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                       // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                      //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        PostCode =dr["PostCode"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Areaclass> GetDatabyCityId(int CityId)
        {
            try
            {//select ta.* ,tc.CityName from tblArea ta,tblCity tc where ta.CityId= tc.CityId and ta.AreaId='" + Areaid + "'
                MySqlCommand cmd = new MySqlCommand("select tc.*,ta.AreaName,ta.AreaId from tblCity tc,tblArea ta where tc.CityId=ta.CityId and tc.CityId='"+ CityId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        AreaName = dr["AreaName"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Areaclass> GetDatabyCityIdByIsActive(int CityId)
        {
            try
            {//select ta.* ,tc.CityName from tblArea ta,tblCity tc where ta.CityId= tc.CityId and ta.AreaId='" + Areaid + "'
                MySqlCommand cmd = new MySqlCommand("SELECT tc.*, ta.AreaName, ta.AreaId,ta.IsActive,ta.PostCode FROM tblCity tc, tblArea ta WHERE tc.IsActive='1' AND ta.IsActive='1' AND tc.CityId = ta.CityId AND tc.CityId ='" + CityId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new Areaclass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        AreaName = dr["AreaName"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        PostCode = dr["PostCode"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //Insert
        public IEnumerable<Areaclass> Insert(string AreaName,int CityId, int IsAcitve, int CreatedBy,string PostCode)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblArea(AreaName,CityId,IsActive,CreatedBy,CreatedDate,PostCode) values('" + AreaName + "',"+CityId+",'" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','"+PostCode+"' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new Areaclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<Areaclass> Update(string AreaName ,int CityId, int UpdatedBy, string PostCode, int AreaId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblArea set AreaName='" + AreaName + "',CityId="+ CityId + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',PostCode='"+ PostCode + "' where AreaId=" + AreaId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new Areaclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Areaclass> Delete(int AreaId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblArea where AreaId='" + AreaId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new Areaclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new Areaclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<Areaclass> UpdateStatus(int Status, int UpdatedBy, int AreaId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblArea set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where AreaId='" + AreaId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new Areaclass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new Areaclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    //Area Class
    public class Areaclass
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string PostCode { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

    }
}