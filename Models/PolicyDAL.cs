using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class PolicyDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<PolicyClass> obj = new List<PolicyClass>();

        public IEnumerable<PolicyClass> InsertPolicy(int SalonsId, int PayAtVenue, int NeedBookingConfirmation, string CancellationPolicy, string BookingleadtimeforAppointments, int IsActive, int CreatedBy, string EvoucherCancellation)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblPolicy(SalonsId,PayAtVenue,NeedBookingConfirmation,CancellationPolicy,BookingleadtimeforAppointments,IsActive,CreatedBy,CreatedDate,EvoucherCancellation) values('" + SalonsId + "','" + PayAtVenue + "','" + NeedBookingConfirmation + "','" + CancellationPolicy + "','" + BookingleadtimeforAppointments + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + EvoucherCancellation + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new PolicyClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PolicyClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<PolicyClass> UpdatePolicy(int SalonsId, int PayAtVenue, int NeedBookingConfirmation, string CancellationPolicy, string BookingleadtimeforAppointments, int IsActive, int UpdatedBy, int PolicyId, string EvoucherCancellation)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPolicy set SalonsId='" + SalonsId + "',PayAtVenue='" + PayAtVenue + "',NeedBookingConfirmation='" + NeedBookingConfirmation + "',CancellationPolicy='" + CancellationPolicy + "',BookingleadtimeforAppointments='" + BookingleadtimeforAppointments + "',IsActive='" + IsActive + "',UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "',EvoucherCancellation='" + EvoucherCancellation + "' where PolicyId='" + PolicyId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new PolicyClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PolicyClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<PolicyClass> GetPolicybySalonId(int SalonsId)
        {
            try
            {//select ta.* ,tc.CityName from tblArea ta,tblCity tc where ta.CityId= tc.CityId and ta.AreaId='" + Areaid + "'
                MySqlCommand cmd = new MySqlCommand("select * from tblPolicy where SalonsId='" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PolicyClass
                    {
                        PolicyId = Convert.ToInt32(dr["PolicyId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        PayAtVenue = Convert.ToInt32(dr["PayAtVenue"]),
                        NeedBookingConfirmation = Convert.ToInt32(dr["NeedBookingConfirmation"]),
                        CancellationPolicy = dr["CancellationPolicy"].ToString(),
                        EvoucherCancellation = dr["EvoucherCancellation"].ToString(),
                        BookingleadtimeforAppointments = dr["BookingleadtimeforAppointments"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PolicyClass
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
                    obj.Add(new PolicyClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PolicyClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class PolicyClass
    {
        public int PolicyId { get; set; }
        public int SalonsId { get; set; }
        public int PayAtVenue { get; set; }
        public int NeedBookingConfirmation { get; set; }
        public string CancellationPolicy { get; set; }
        public string BookingleadtimeforAppointments { get; set; }
        public int IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string EvoucherCancellation { get; internal set; }
    }
}