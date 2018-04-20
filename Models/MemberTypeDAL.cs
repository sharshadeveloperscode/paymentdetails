using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class MemberTypeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<MemberTypeClass> obj = new List<MemberTypeClass>();
        public IEnumerable<MemberTypeClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblMemberType", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new MemberTypeClass
                    {
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        MemberTypeName = dr["MemberTypeName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new MemberTypeClass
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
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<MemberTypeClass> GetdataByIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblMemberType where IsActive='1'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new MemberTypeClass
                    {
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        MemberTypeName = dr["MemberTypeName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new MemberTypeClass
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
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<MemberTypeClass> GetbyId(int MemberTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblMemberType where MemberTypeId='" + MemberTypeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new MemberTypeClass
                    {
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        MemberTypeName = dr["MemberTypeName"].ToString(),
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
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<MemberTypeClass> Insert(string MemberTypeName, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblMemberType(MemberTypeName,IsActive,CreatedBy,CreatedDate) values('" + MemberTypeName + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new MemberTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<MemberTypeClass> Update(string MemberTypeName, int UpdatedBy, int MemberTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblMemberType set MemberTypeName='" + MemberTypeName + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where MemberTypeId=" + MemberTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new MemberTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<MemberTypeClass> Delete(int MemberTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblMemberType where MemberTypeId='" + MemberTypeId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new MemberTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new MemberTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<MemberTypeClass> UpdateStatus(int Status, int UpdatedBy, int MemberTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblMemberType set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where MemberTypeId='" + MemberTypeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new MemberTypeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new MemberTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class MemberTypeClass
    {
        public int MemberTypeId { get; set; }
        public string MemberTypeName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}