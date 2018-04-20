using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class PricingTypeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<PricingTypeClass> obj = new List<PricingTypeClass>();
        public IEnumerable<PricingTypeClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPricingType", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PricingTypeClass
                    {
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        PricingType = dr["PricingType"].ToString(),
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
                    obj.Add(new PricingTypeClass
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
                    obj.Add(new PricingTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PricingTypeClass> GetbyId(int PricingTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblPricingType where PricingTypeId='" + PricingTypeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PricingTypeClass
                    {
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        PricingType = dr["PricingType"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new PricingTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PricingTypeClass> Insert(string PricingType, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblPricingType(PricingType,IsActive,CreatedBy,CreatedDate) values('" + PricingType + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new PricingTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PricingTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<PricingTypeClass> Update(string PricingType, int UpdatedBy, int PricingTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPricingType set PricingType='" + PricingType + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where PricingTypeId=" + PricingTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new PricingTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PricingTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PricingTypeClass> UpdateStatus(int Status, int UpdatedBy, int PricingTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPricingType set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where PricingTypeId='" + PricingTypeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new PricingTypeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new PricingTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class PricingTypeClass
    {
            public int PricingTypeId { get; set; }
            public string PricingType { get; set; }
            public int IsActive { get; set; }
            public int CreatedBy { get; set; }
            public int UpdateBy { get; set; }
            public string CreatedDate { get; set; }
            public string UpdatedDate { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }
}