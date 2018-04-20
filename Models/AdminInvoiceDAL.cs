using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class AdminInvoiceDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<AdminInvoiceClass> obj = new List<AdminInvoiceClass>();


        public IEnumerable<AdminInvoiceClass> GetInvoice(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblInvoice where SalonsId='" + SalonsId + "' ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminInvoiceClass
                    {
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Month = dr["Month"].ToString(),
                        Year = dr["Year"].ToString(),
                        Period1 = dr["Period1"].ToString(),
                        Period2 = dr["Period2"].ToString(),

                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new AdminInvoiceClass
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
                    obj.Add(new AdminInvoiceClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminInvoiceClass> GetInvoiceGeneration(string Month, string Year, string Period1, string Period2, string SalonsId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT *,date_format(tsc.BookingDate ,'%d-%m-%Y') as bookdate FROM tblSalonCheckout tsc, tblPayments tp, tblSalons ts, tblEmployeeServices tes, tblSalonServices tss where tsc.PaymentsId=tp.PaymentsId AND tsc.SalonsId=ts.SalonsId AND tsc.EmployeeServicesId = tes.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND month(tsc.BookingDate)='" + Month+"' AND year(tsc.BookingDate)='"+Year+ "'  AND day(tsc.BookingDate) between '"+ Period1 + "' and '"+ Period2 + "' AND tsc.IsActive=4   AND ts.SalonsId in(" + SalonsId+ ")", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS bookdate,ts.Address as VenueAddress,ts.PostalCode as venuepostcode FROM tblSalonCheckout tsc, tblPayments tp, tblSalons ts, tblEmployeeServices tes, tblSalonServices tss WHERE tsc.PaymentsId = tp.PaymentsId AND tsc.SalonsId = ts.SalonsId AND tsc.EmployeeServicesId = tes.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND MONTH(tsc.BookingDate) = '" + Month + "' AND YEAR(tsc.BookingDate) = '" + Year + "' AND DAY(tsc.BookingDate) BETWEEN '" + Period1 + "' AND '" + Period2 + "' AND tp.IsActive = 1 AND tsc.IsActive = 4 AND ts.SalonsId IN(" + SalonsId + ")", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminInvoiceClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        bookdate = dr["bookdate"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Address = dr["VenueAddress"].ToString(),
                        PayableAmount = Convert.ToInt32(dr["PayableAmount"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        Postcode = dr["venuepostcode"].ToString(),
                        Period1 = dr["BusinessName"].ToString(),
                        Period2 = dr["BusinessName"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new AdminInvoiceClass
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
                    obj.Add(new AdminInvoiceClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminInvoiceClass> InsertInvoice(string SalonsId, string Month, string Year, int IsActive, int CreatedBy, string Period1, string Period2)
        {
            try
            {
                string value = SalonsId;
                char delimiter = ',';
                string[] substrings = value.Split(delimiter);
                // int k = 0;
                con.Open();
                for (int i = 0; i < substrings.Length; i++)
                {

                    MySqlCommand cmd = new MySqlCommand("insert into tblInvoice(SalonsId,Month,Year,IsActive,CreatedBy,CreatedDate,Period1,Period2) values('" + substrings[i] + "','" + Month + "','" + Year + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + Period1 + "','" + Period2 + "')", con);

                    cmd.ExecuteNonQuery();
                }

                obj.Add(new AdminInvoiceClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new AdminInvoiceClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminInvoiceClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
    }
    public class AdminInvoiceClass
    {
        public string bookdate { get; set; }
        public int SalonsId { get; set; }
        public string BusinessName { get; set; }
        public int EmployeeServicesId { get; set; }
        public int PayableAmount { get; set; }
        public int PaymentsId { get; set; }
        public string PaymentType { get; set; }
        public int SalonCheckoutId { get; set; }
        public string TreatmentTypeId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string BookingDate { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Period2 { get; set; }
        public string Period1 { get; set; }
        public string Address { get; internal set; }
        public string Postcode { get; internal set; }
        public string ServicePrice { get; internal set; }
    }
}