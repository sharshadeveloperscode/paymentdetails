using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class BusinessHoursDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<BusinessHoursClass> obj = new List<BusinessHoursClass>();
        public IEnumerable<BusinessHoursClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tb.*,ts.BusinessName,tst.StartTime,te.EndTime from tblBusinessHours tb,tblSalons ts,tblStartTime tst,tblEndTime te where tb.SalonsId=ts.SalonsId and tb.OpeningHours=tst.StartTimeId and tb.ClosingHours=te.EndTimeId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BusinessHoursClass
                    {
                        BusinessHoursId = Convert.ToInt32(dr["BusinessHoursId"]),
                        Day = dr["Day"].ToString(),
                        OpeningHours = Convert.ToInt32(dr["OpeningHours"]),
                        ClosingHours = Convert.ToInt32(dr["ClosingHours"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                      //  Name = dr["Name"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new BusinessHoursClass
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
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BusinessHoursClass> GetDatabyId(int BusinessHoursId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tb.*,ts.BusinessName,tst.StartTime,te.EndTime from tblBusinessHours tb,tblSalons ts,tblStartTime tst,tblEndTime te where tb.SalonsId=ts.SalonsId and tb.OpeningHours=tst.StartTimeId and tb.ClosingHours=te.EndTimeId and tb.BusinessHoursId='" + BusinessHoursId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BusinessHoursClass
                    {
                        BusinessHoursId = Convert.ToInt32(dr["BusinessHoursId"]),
                        Day = dr["Day"].ToString(),
                        OpeningHours = Convert.ToInt32(dr["OpeningHours"]),
                        ClosingHours = Convert.ToInt32(dr["ClosingHours"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Name = dr["Name"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BusinessHoursClass> Insert(int SalonsId, string Day, int OpeningHours, int ClosingHours, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblBusinessHours(SalonsId,Day,OpeningHours,ClosingHours,IsActive,CreatedBy,CreatedDate) values('" + SalonsId + "','" + Day + "','" + OpeningHours + "','" + ClosingHours + "','" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new BusinessHoursClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<BusinessHoursClass> Update(int SalonsId, string Day, int OpeningHours, int ClosingHours,int IsActive, int UpdatedBy, int BusinessHoursId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblBusinessHours set SalonsId='" + SalonsId + "', Day='" + Day + "',IsActive='" + IsActive + "', OpeningHours=" + OpeningHours + ",ClosingHours=" + ClosingHours + ",UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where BusinessHoursId=" + BusinessHoursId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new BusinessHoursClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BusinessHoursClass> Delete(int BusinessHoursId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblBusinessHours where BusinessHoursId='" + BusinessHoursId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new BusinessHoursClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<BusinessHoursClass> UpdateStatus(int IsActive, int UpdatedBy, int BusinessHoursId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblBusinessHours set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where BusinessHoursId='" + BusinessHoursId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new BusinessHoursClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<BusinessHoursClass> GetDatabySalonId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblBusinessHours where  SalonsId='" + SalonsId + "' order by BusinessHoursId asc ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BusinessHoursClass
                    {
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        BusinessHoursId = Convert.ToInt32(dr["BusinessHoursId"]),
                        Day = dr["Day"].ToString(),
                        OpeningHours = Convert.ToInt32(dr["OpeningHours"]),
                        ClosingHours = Convert.ToInt32(dr["ClosingHours"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //UpdateBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //UpdatedDate = dr["UpdatedDate"].ToString(),
                       
                        Message = "Success",

                    });
                }
             
                if (!dr.HasRows)
                {
                    obj.Add(new BusinessHoursClass
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
                    obj.Add(new BusinessHoursClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BusinessHoursClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public DateTime GetServerDateTime()
        {
           
                string URL = "http://www.google.com";
                System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
                DateTime Date = DateTime.Parse(res2.Headers["Date"]);
                return Date;
           
           
        }

    }
    public class BusinessHoursClass
    {
        public int BusinessHoursId { get; set; }
        public string Day { get; set; }
        public int OpeningHours { get; set; }
        public int ClosingHours { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Name { get; set; }
        public int SalonsId { get; set; }
        public string StartTime { get; set; }
        public int StartTimeId { get; set; }
        public string EndTime { get; set; }
        public int EndTimeId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}