using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class BillingsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<BillingsClass> obj = new List<BillingsClass>();
        public IEnumerable<BillingsClass> ListofBookings()
        {
            try
            {
                // MySqlCommand cmd = new MySqlCommand("SELECT *,tsc.CreatedDate as mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse WHERE tp.UserId = tc.UserId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tp.PaymentsId = tsc.PaymentsId AND tt.TreatmentTitleId = tss.TreatmentTitleId GROUP BY SalonCheckoutId", con);
                MySqlCommand cmd = new MySqlCommand("select * , tsc.CreatedDate AS mydate from tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td where tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive NOT IN (0,3) group by SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<BillingsClass> ListofBookingsbasedonSalonsId(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            // string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            string Date1 = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tss.SalonsId = '" + SalonsId + "' AND tsc.BookingDate='" + Date1 + "' AND tsc.IsActive not in(0) GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BillingsClass> ListofBookingsDateRange(int SalonsId, string FromDate, string ToDate, int IsActive)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tss.SalonsId = '" + SalonsId + "' AND tsc.IsActive NOT IN(0 , 3) and tsc.IsActive=" + IsActive + " and tsc.BookingDate between '" + Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd") + "' GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<BillingsClass> ListofBookingsBySearch(int SalonsId, string FromDate, string ToDate, int IsActive, int BookingType)
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

                MySqlCommand cmd = new MySqlCommand("SELECT *,DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tsc.SalonServicesId = tss.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonsId = '" + SalonsId + "' AND tsc.IsActive NOT IN(0 , 3) and tsc.IsActive in (" + var1 + ") and tsc.BookingType in (" + var2 + ") and tsc.BookingDate between '" + Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd") + "' GROUP BY SalonCheckoutId order by tsc.SalonCheckoutId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {

                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTypeId"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["PayableAmount"].ToString(),
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
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        EvoucherNumber = dr["EvoucherNumber"].ToString(),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<BillingsClass> ListofBookings1(int SalonCheckoutId)
        {
            try
            {
                // MySqlCommand cmd = new MySqlCommand("SELECT *,tsc.CreatedDate as mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse WHERE tp.UserId = tc.UserId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tp.PaymentsId = tsc.PaymentsId AND tt.TreatmentTitleId = tss.TreatmentTitleId GROUP BY SalonCheckoutId", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.CreatedDate, '%d-%m-%Y') AS mydate, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS BookDate FROM tblSalonCheckout tsc, tblPayments tp, tblSalonServices tss, tblTreatmentTitle tt, tblCustomers tc, tblEmployeeServices tes, tblSalonEmployees tse, tblDuration td WHERE tp.PaymentsId = tsc.PaymentsId AND tsc.SalonServicesId = tss.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.UserId = tc.UserId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tsc.SalonCheckoutId = '" + SalonCheckoutId + "' GROUP BY SalonCheckoutId;", con); //AND tes.EmployeeServicesId = tsc.EmployeeServicesId
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {
                        BookingDate = dr["BookDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        BookingType = dr["BookingType"].ToString(),
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
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<BillingsClass> EvocuherBookingsList(int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS BookDate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblTreatmentTitle tt, tblSalonServices tss, tblDuration td WHERE tp.UserId = tc.UserId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tsc.SalonServicesId = tss.SalonServicesId AND tsc.SalonCheckoutId = '" + SalonCheckoutId + "' GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {

                        BookingDate = dr["BookDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTypeId"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
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
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateBookingStatus(string BookingDate, string BookingTime, string SalonCheckoutId, int EmployeeServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonCheckout set BookingDate='" + BookingDate + "',BookingTime='" + BookingTime + "',IsActive=6,EmployeeServicesId=" + EmployeeServicesId + " where SalonCheckoutId='" + SalonCheckoutId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }

        }





        public IEnumerable<BillingsClass> GetNoShowDetails()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive=3 GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        LastName = dr["LastName"].ToString(),

                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
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
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BillingsClass> GetCompleteDetails()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive=4 GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        LastName = dr["LastName"].ToString(),

                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
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
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BillingsClass> GetCompleteDetailsBasedOnSalonsId(int SalonsId, int IsActive)
        {
            try
            {
                if (IsActive == 0)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive in(1,2,3,4,5) AND tss.SalonsId='" + SalonsId + "' GROUP BY SalonCheckoutId", con);
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new BillingsClass
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
                        obj.Add(new BillingsClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive ='" + IsActive + "' AND tss.SalonsId='" + SalonsId + "' GROUP BY SalonCheckoutId", con);
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new BillingsClass
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
                        obj.Add(new BillingsClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                }

                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<BillingsClass> GetCancelOrderDetails()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc.CreatedDate AS mydate FROM tblSalonCheckout tsc, tblPayments tp, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblDuration td WHERE tp.UserId = tc.UserId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tp.PaymentsId = tsc.PaymentsId AND td.DurationId = tss.DurationId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive ='2' GROUP BY SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new BillingsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        LastName = dr["LastName"].ToString(),

                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
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
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
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
                    obj.Add(new BillingsClass
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
                    obj.Add(new BillingsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new BillingsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

    }
    public class BillingsClass
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
        public string EvoucherNumber { get; internal set; }
        public string ServicePrice { get; internal set; }
        public string TreatmentTypeId { get; internal set; }
    }
}