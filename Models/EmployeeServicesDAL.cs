using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class EmployeeServicesDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<EmployeeServicesclass> obj = new List<EmployeeServicesclass>();
        public IEnumerable<EmployeeServicesclass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select tes.*,tss.SalonServicesId,tse.SalonEmployeesId from tblSalonServices tss,tblSalonEmployees tse,tblEmployeeServices tes where tes.SalonServicesId=tes.SalonServicesId and tes.SalonEmployeesId=tse.SalonEmployeesId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new EmployeeServicesclass
                    {
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                       // CityName = dr["CityName"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new EmployeeServicesclass
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
                    obj.Add(new EmployeeServicesclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmployeeServicesclass> GetDatabyId(int EmployeeServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select tes.*,tss.SalonServicesId,tse.SalonEmployeesId from tblSalonServices tss,tblSalonEmployees tse,tblEmployeeServices tes where tes.SalonServicesId=tes.SalonServicesId and tes.SalonEmployeesId=tse.SalonEmployeesId and tes.EmployeeServicesId='" + EmployeeServicesId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new EmployeeServicesclass
                    {
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        // AreaName = dr["AreaName"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new EmployeeServicesclass
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
                    obj.Add(new EmployeeServicesclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmployeeServicesclass> Insert(int SalonServicesId, int SalonEmployeesId, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblEmployeeServices(SalonServicesId,SalonEmployeesId,IsActive,CreatedBy,CreatedDate) values('" + SalonServicesId + "'," + SalonEmployeesId + ",'" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new EmployeeServicesclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new EmployeeServicesclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<EmployeeServicesclass> Update(int SalonServicesId, int SalonEmployeesId, int UpdatedBy, int EmployeeServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEmployeeServices set SalonServicesId='" + SalonServicesId + "',SalonEmployeesId=" + SalonEmployeesId + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where EmployeeServicesId=" + EmployeeServicesId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new EmployeeServicesclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new EmployeeServicesclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<EmployeeServicesclass> Delete(int EmployeeServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblEmployeeServices where EmployeeServicesId='" + EmployeeServicesId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new EmployeeServicesclass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new EmployeeServicesclass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<EmployeeServicesclass> UpdateStatus(int Status, int UpdatedBy, int EmployeeServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEmployeeServices set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where EmployeeServicesId='" + EmployeeServicesId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new EmployeeServicesclass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new EmployeeServicesclass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class EmployeeServicesclass
    {
        public int EmployeeServicesId { get; set; }
        public int SalonServicesId { get; set; }
        public int SalonEmployeesId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
       // public string CityName { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

    }
}