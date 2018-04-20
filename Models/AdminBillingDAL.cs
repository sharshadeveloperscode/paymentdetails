using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class AdminBillingDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<AdminBilling> obj = new List<AdminBilling>();
        
        public IEnumerable<AdminBilling> ListofBookingsbasedonSalonsId()
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId  AND tsc.BookingDate=('" + Date1 + "') AND tsc.IsActive not in(0) GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminBilling
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        mydate = dr["mydate"].ToString(),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        //BusinessName = dr["BusinessName"].ToString(),
                        //  Image = dr["Image"].ToString(),
                        //  ImagePath = dr["ImagePath"].ToString(),
                        // GoogleMaps = dr["GoogleMaps"].ToString(),
                        // Address = dr["Address"].ToString(),
                        // OpeningHours = dr["OpeningHours"].ToString(),
                        // ClosingHours = dr["ClosingHours"].ToString(),
                        //Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new AdminBilling
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
                    obj.Add(new AdminBilling { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminBilling { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminBilling { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<AdminBilling> AdminListofBookingsBySearch( string FromDate, string ToDate, int IsActive, int BookingType)
        {
            try
            {
                string var1;
                string var2;
                if (IsActive == 0)
                {
                    var1 = "1,2,4,5,6";
                }
                else
                {
                    var1 = IsActive.ToString();
                }

                if (BookingType == 0)
                {
                    var2 = "'Appointments','EVoucher'";

                }
                else if (BookingType == 1)
                {
                    var2 = "'Appointments'";
                }
                else
                {
                    var2 = "'EVoucher'";
                }

                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tp.PaymentsId = tsc.PaymentsId and tsc.SalonServicesId=tss.SalonServicesId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId  AND tsc.IsActive NOT IN(0) and tsc.IsActive in (" + var1 + ") and tsc.BookingType in (" + var2 + ") and tsc.BookingDate between '" + Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd") + "' GROUP BY SalonCheckoutId order by SalonCheckoutId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminBilling
                    {

                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        mydate = dr["mydate"].ToString(),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        //BusinessName = dr["BusinessName"].ToString(),
                        //  Image = dr["Image"].ToString(),
                        //  ImagePath = dr["ImagePath"].ToString(),
                        // GoogleMaps = dr["GoogleMaps"].ToString(),
                        // Address = dr["Address"].ToString(),
                        // OpeningHours = dr["OpeningHours"].ToString(),
                        // ClosingHours = dr["ClosingHours"].ToString(),
                        //Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new AdminBilling
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
                    obj.Add(new AdminBilling { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminBilling { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminBilling { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


    


      
    }
    public class AdminBilling
    {
        public string BookingDate { get; set; }
        public string PaymentType { get; set; }
        public string BookingTime { get; set; }
        public string BookingsId { get; set; }
        public string TreatmentTitle { get; set; }
        public string FirstName { get; set; }
        public string PaymentStatus { get; set; }
        public string Price { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Duration { get; set; }
        public string mydate { get; set; }
        public int IsActive { get; set; }
        public int PaymentsId { get; set; }
        public int DurationId { get; set; }
        public int SalonCheckoutId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string BookingType { get; internal set; }
        public int SalonServicesId { get; internal set; }
        public string TreatmentTypeId { get; internal set; }
        public string ServicePrice { get; internal set; }
    }

}