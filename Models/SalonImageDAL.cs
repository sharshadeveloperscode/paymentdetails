using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class SalonImageDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonImageClass> obj = new List<SalonImageClass>();
        public IEnumerable<SalonImageClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonImage ti,tblSalons ts where ti.SalonsId= ts.SalonsId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonImageClass
                    {
                        SalonImageId = Convert.ToInt32(dr["SalonImageId"]),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonImageClass
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
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonImageClass> GetDatabyId(int SalonImageId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonImage ti,tblSalons ts where ti.SalonsId= ts.SalonsId  and ti.SalonImageId='" + SalonImageId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonImageClass
                    {
                        SalonImageId = Convert.ToInt32(dr["SalonImageId"]),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonImageClass
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
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonImageClass> GetDatabySalonId(int SalonId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonImage ti,tblSalons ts where ti.SalonsId= ts.SalonsId  and ti.SalonsId='" + SalonId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonImageClass
                    {
                        SalonImageId = Convert.ToInt32(dr["SalonImageId"]),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonImageClass
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
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonImageClass> Insert(string Image, string ImagePath, int SalonsId, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonImage(Image,ImagePath,SalonsId,IsActive,CreatedBy,CreatedDate) values('" + Image + "','" + ImagePath + "'," + SalonsId + ",'" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonImageClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonImageClass> Update(string Image, string ImagePath, int SalonsId, int UpdatedBy, int SalonImageId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonImage set Image='" + Image + "',ImagePath='" + ImagePath + "',SalonsId=" + SalonsId + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where SalonImageId=" + SalonImageId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonImageClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonImageClass> Delete(int SalonImageId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSalonImage where SalonImageId='" + SalonImageId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonImageClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonImageClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonImageClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonImageId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonImage set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonImageId='" + SalonImageId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonImageClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonImageClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class SalonImageClass
    {
        public int SalonImageId { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }
        public int SalonsId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}