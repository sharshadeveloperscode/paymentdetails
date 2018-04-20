using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class ReportsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<ReportsClass> obj = new List<ReportsClass>();
        public IEnumerable<ReportsClass> TodayBookings(int SalonsId)
        {
            try
            {
                string URL = "http://www.google.com";
                System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
                DateTime Date = DateTime.Parse(res2.Headers["Date"]);

                string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

                //MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId=tp.UserId AND  date(tsc.CreatedDate) = curdate() AND tss.SalonsId = '" + SalonsId+"' group by tsc.SalonCheckoutId; ", con);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonCheckout tsc, tblCustomers tc, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.SalonServicesId = tss.SalonServicesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.CreatedDate ='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' AND tsc.SalonsId = '" + SalonsId + "' GROUP BY tsc.SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
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
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        //BusinessName = dr["BusinessName"].ToString(),
                        //  Image = dr["Image"].ToString(),
                        //  ImagePath = dr["ImagePath"].ToString(),
                        // GoogleMaps = dr["GoogleMaps"].ToString(),
                        // Address = dr["Address"].ToString(),
                        // OpeningHours = dr["OpeningHours"].ToString(),
                        // ClosingHours = dr["ClosingHours"].ToString(),
                        Description = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd"),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> MonthlyBookings(int SalonsId, string Month, string Year)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.IsActive = 4 AND Month(tsc.BookingDate) = '" + Month + "' AND year(tsc.BookingDate) = '" + Year + "' AND tss.SalonsId = '" + SalonsId + "' group by tsc.SalonCheckoutId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
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
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> Bookingcancellations(int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId=tsc.PaymentsId  AND tc.UserId=tp.UserId AND tsc.IsActive=2 AND tss.SalonsId='" + SalonsId + "' group by tsc.SalonCheckoutId;  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {

                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),

                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        //  Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),

                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalonConfirmCancelBookings(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {
                // old This is Also Working But Doubt

                //MySqlCommand cmd = new MySqlCommand("SELECT A.Year, A.month,A.count as cancel, B.count as booked FROM(SELECT ss.SalonsId, YEAR(sc.BookingDate) as 'Year', MONTHNAME(sc.BookingDate) as 'Month', COUNT(sc.BookingDate) as 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 2 AND year(sc.BookingDate) = year('"+Date1+"') AND ss.SalonsId = '" + SalonsId + "' GROUP BY Month(sc.BookingDate), Year(sc.BookingDate), ss.SalonsId) AS A left OUTER JOIN (SELECT ss.SalonsId, YEAR(sc.BookingDate) as 'Year', MONTHNAME(sc.BookingDate) as 'Month', COUNT(sc.BookingDate) as 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 4 AND year(sc.BookingDate) = year('"+Date1+"') AND ss.SalonsId = '" + SalonsId + "' GROUP BY Month(sc.BookingDate), Year(sc.BookingDate), ss.SalonsId) As B on A.Month = B.Month ", con);

                MySqlCommand cmd = new MySqlCommand("SELECT A.Year, A.month, case when isnull(A.count) then 0 else A.count end AS cancel, case when isnull(B.count) then 0 else B.count end AS booked FROM(SELECT ss.SalonsId, YEAR(sc.BookingDate) AS 'Year', MONTHNAME(sc.BookingDate) AS 'Month', COUNT(sc.BookingDate) AS 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 2 AND YEAR(sc.BookingDate) = YEAR('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') AND ss.SalonsId = " + SalonsId + " GROUP BY MONTH(sc.BookingDate) , YEAR(sc.BookingDate) , ss.SalonsId) AS A LEFT OUTER JOIN (SELECT ss.SalonsId, YEAR(sc.BookingDate) AS 'Year', MONTHNAME(sc.BookingDate) AS 'Month', COUNT(sc.BookingDate) AS 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 4 AND YEAR(sc.BookingDate) = YEAR('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') AND ss.SalonsId = " + SalonsId + " GROUP BY MONTH(sc.BookingDate) , YEAR(sc.BookingDate) , ss.SalonsId) AS B ON A.Month = B.Month union SELECT B.Year, B.month, case when isnull(A.count) then 0 else A.count end AS cancel, case when isnull(B.count) then 0 else B.count end AS booked FROM (SELECT ss.SalonsId, YEAR(sc.BookingDate) AS 'Year', MONTHNAME(sc.BookingDate) AS 'Month', COUNT(sc.BookingDate) AS 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 2 AND YEAR(sc.BookingDate) = YEAR('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') AND ss.SalonsId = " + SalonsId + " GROUP BY MONTH(sc.BookingDate) , YEAR(sc.BookingDate) , ss.SalonsId) AS A RIGHT OUTER JOIN (SELECT ss.SalonsId, YEAR(sc.BookingDate) AS 'Year', MONTHNAME(sc.BookingDate) AS 'Month', COUNT(sc.BookingDate) AS 'Count' FROM tblSalonCheckout sc, tblEmployeeServices es, tblSalonServices ss WHERE sc.EmployeeServicesId = es.EmployeeServicesId AND es.SalonServicesId = ss.SalonServicesId AND sc.IsActive = 4 AND YEAR(sc.BookingDate) = YEAR('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') AND ss.SalonsId = " + SalonsId + " GROUP BY MONTH(sc.BookingDate) , YEAR(sc.BookingDate) , ss.SalonsId) AS B ON A.Month = B.Month", con);



                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {
                        // Count = Convert.ToInt32(dr["Count"]),

                        Year = dr["Year"].ToString(),
                        month = dr["month"].ToString(),
                        cancel = dr["cancel"].ToString(),
                        booked = dr["booked"].ToString(),
                        // BookingDate = dr["BookingDate"].ToString(),
                        //  BookingTime = dr["BookingTime"].ToString(),
                        //   TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        //  BookingsId = dr["BookingsId"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        //  LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        //   Email = dr["Email"].ToString(),
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //  SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        //  Category = dr["Category"].ToString(),
                        //  TreatmentType = dr["TreatmentType"].ToString(),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalonTopServicesBooking(int SalonsId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand(" SELECT ttt.TreatmentType, count(*) as Count FROM tblSalonServices tss, tblEmployeeServices tes, tblSalonCheckout tsc, tblTreatmentType ttt WHERE tss.SalonServicesId = tes.SalonServicesId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.TreatmentTypeId = ttt.TreatmentTypeId AND tss.SalonsId = '" + SalonsId + "' GROUP BY ttt.TreatmentType ORDER BY count(*) DESC ", con);
                //MySqlCommand cmd = new MySqlCommand("SELECT tss.TreatmentTypeId, COUNT(*) AS Count FROM tblSalonServices tss, tblSalonCheckout tsc WHERE tss.TreatmentTypeId = tss.TreatmentTypeId AND tsc.IsActive=4 AND tss.SalonsId = '" + SalonsId + "' GROUP BY tss.TreatmentTypeId ORDER BY COUNT(*) DESC", con);
                MySqlCommand cmd = new MySqlCommand("SELECT tt.TreatmentTitle,COUNT(*) AS Count ,tc.Category FROM tblSalonCheckout tsc, tblSalonServices tss, tblTreatmentTitle tt, tblCategory tc where tsc.SalonServicesId=tss.SalonServicesId AND tt.TreatmentTitleId=tss.TreatmentTitleId AND tc.CategoryId=tss.CategoryId AND tss.SalonsId=" + SalonsId + " AND tsc.IsActive=4 GROUP BY tss.TreatmentTitleId order by count(*) desc limit 5 ", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {
                        Count = Convert.ToInt32(dr["Count"]),
                        //   BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        //   PaymentStatus = dr["PaymentStatus"].ToString(),
                        //   BookingsId = dr["BookingsId"].ToString(),
                        //    Price = dr["Price"].ToString(),
                        //  LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        //   Email = dr["Email"].ToString(),
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        // SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> OldCustomers(int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblEmployeeServices tes, tblTreatmentTitle tt, tblCustomers tc, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId=tp.UserId AND tsc.IsActive = 1 AND tss.SalonsId = '" + SalonsId + "' GROUP BY tp.UserId having count(*) > 1 ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
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
                        //  Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),

                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> ActualBooking(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId  AND tsc.BookingDate='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' and tsc.IsActive!=2 AND tsc.SalonsId = '" + SalonsId + "' GROUP BY tsc.SalonCheckoutId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        Email = dr["Email"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
                        CreatedDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd"),
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
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReports(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tsc.ServicePrice) AS TotalPrice, tsc.SalonCheckoutId, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive = 4 AND date(tsc.BookingDate) ='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' AND tss.SalonsId = '" + SalonsId + "' ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                // var CheckoutId = 0;
                // var Booking = 0;
                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        Bookings = dr["Bookings"].ToString(),
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //  SalonCheckoutId = CheckoutId,
                        Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReportsBasedonDate(string Fromdate, string Todate, int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tsc.ServicePrice) AS TotalPrice, tsc.SalonCheckoutId, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive = 4  AND tsc.BookingDate between '" + Fromdate + "' and '" + Todate + "' AND tss.SalonsId = '" + SalonsId + "' ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                // var CheckoutId = 0;
                // var Booking = 0;
                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        Bookings = dr["Bookings"].ToString(),
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //  SalonCheckoutId = CheckoutId,
                        Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReportsByEmployee(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT tse.EmployeeName, tsc.BookingDate, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tsc.ServicePrice) AS TotalPrice, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalonEmployees tse WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.IsActive = 4 AND date(tsc.BookingDate) ='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' AND tss.SalonsId = '" + SalonsId + "' GROUP BY tse.SalonEmployeesId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        //  BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        //  PaymentStatus = dr["PaymentStatus"].ToString(),
                        Bookings = dr["Bookings"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        //  Bookings = Booking,
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //    SalonCheckoutId = CheckoutId,
                        //  Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        EmployeeName = dr["EmployeeName"].ToString(),

                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReportsByEmployeeBasedonDate(string Fromdate, string Todate, int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT tse.EmployeeName, tsc.BookingDate, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tsc.ServicePrice) AS TotalPrice, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalonEmployees tse WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.IsActive = 4 AND tsc.BookingDate between '" + Fromdate + "' AND '" + Todate + "' AND tss.SalonsId = '" + SalonsId + "' GROUP BY tse.SalonEmployeesId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        //  BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        //  PaymentStatus = dr["PaymentStatus"].ToString(),
                        Bookings = dr["Bookings"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        //  Bookings = Booking,
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //    SalonCheckoutId = CheckoutId,
                        //  Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<ReportsClass> CurrentMonthSalesByEmployee(int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT tse.EmployeeName as EmployeeName, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tss.Price) AS TotalPrice, tsc.SalonCheckoutId, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalonEmployees tse WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive = 4 AND month(tsc.BookingDate)=month(now()) AND tse.SalonEmployeesId=tes.SalonEmployeesId AND tss.SalonsId = " + SalonsId + " group by tse.SalonEmployeesId ORDER BY COUNT(*) DESC LIMIT 5  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    obj.Add(new ReportsClass
                    {
                        Bookings = dr["Bookings"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<ReportsClass> MonthlySalonsIncome()
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT ts.BusinessName as SalonName, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tsc.ServicePrice) AS TotalPrice FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalons ts WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND ts.SalonsId=tss.SalonsId AND tsc.IsActive = 4 AND month(tsc.BookingDate)=month(now()) group by ts.Name order by SUM(tsc.ServicePrice) desc limit 5", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ReportsClass
                    {
                        SalonName = dr["SalonName"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }





        public IEnumerable<ReportsClass> SalesReportsYesterday(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tss.Price) AS TotalPrice, tsc.SalonCheckoutId, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive = 4 AND tsc.BookingDate = subdate('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' , 1) AND tss.SalonsId  ='" + SalonsId + "' ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                // var CheckoutId = 0;
                // var Booking = 0;
                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        Bookings = dr["Bookings"].ToString(),
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //  SalonCheckoutId = CheckoutId,
                        Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReportsLast7Days(int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tss.Price) AS TotalPrice, tsc.SalonCheckoutId, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tsc.IsActive = 4 AND tsc.BookingDate >= DATE(NOW()) - INTERVAL 7 DAY AND tss.SalonsId = '" + SalonsId + "' ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                // var CheckoutId = 0;
                // var Booking = 0;
                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        //   BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        Bookings = dr["Bookings"].ToString(),
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //  SalonCheckoutId = CheckoutId,
                        Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        // EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<ReportsClass> SalesReportsByEmployeeYesterday(int SalonsId)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT tse.EmployeeName, tsc.BookingDate, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tss.Price) AS TotalPrice, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalonEmployees tse WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.IsActive = 4 AND tsc.BookingDate = subdate('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "', 1) AND tss.SalonsId = '" + SalonsId + "' GROUP BY tse.SalonEmployeesId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        Bookings = dr["Bookings"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        //  Bookings = Booking,
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //    SalonCheckoutId = CheckoutId,
                        //  Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ReportsClass> SalesReportsByEmployeeLast7Days(int SalonsId)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT tse.EmployeeName, tsc.BookingDate, DAYNAME(tsc.BookingDate) AS dayname, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, SUM(tss.Price) AS TotalPrice, COUNT(*) AS Bookings FROM tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonServices tss, tblSalonEmployees tse WHERE tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.SalonServicesId = tes.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.IsActive = 4 AND tsc.BookingDate >= DATE(NOW()) - INTERVAL 7 DAY AND tss.SalonsId = 1 GROUP BY tse.SalonEmployeesId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //if (dr["SalonCheckoutId"] == DBNull.Value)
                    //{
                    //    CheckoutId = 0;
                    //}
                    //else
                    //{
                    //    CheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                    //}
                    //if (dr["Bookings"] == DBNull.Value)
                    //{
                    //    Booking = 0;
                    //}
                    //else
                    //{
                    //    Booking = Convert.ToInt32(dr["Bookings"]);
                    //}
                    obj.Add(new ReportsClass
                    {
                        Bookings = dr["Bookings"].ToString(),
                        //  Price = dr["Price"].ToString(),
                        TotalPrice = dr["TotalPrice"].ToString(),
                        //Bookings = Convert.ToInt32(dr["Bookings"]),
                        //  Bookings = Booking,
                        // Bookings =dr["Bookings"].ToString(),
                        dayname = dr["dayname"].ToString(),
                        // LastName = dr["LastName"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        // Email = dr["Email"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //    SalonCheckoutId = CheckoutId,
                        //  Bookdate = dr["Bookdate"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  mydate = dr["mydate"].ToString(),
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
                        EmployeeName = dr["EmployeeName"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new ReportsClass
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
                    obj.Add(new ReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


    }
    public class ReportsClass
    {
        public string TreatmentType { get; set; }
        public int Count { get; set; }
        public string Year { get; set; }
        public string month { get; set; }
        public string cancel { get; set; }
        public string booked { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string BookingsId { get; set; }
        public string TreatmentTitle { get; set; }

        public string FirstName { get; set; }
        public string PaymentStatus { get; set; }
        public string Bookdate { get; set; }
        public string dayname { get; set; }
        public string Price { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Duration { get; set; }
        public string mydate { get; set; }
        public int DurationId { get; set; }
        public string Bookings { get; set; }
        public string TotalPrice { get; set; }
        public int SalonCheckoutId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string TreatmentTypeId { get; set; }
        public string Category { get; internal set; }
        public string SalonName { get; internal set; }
        public string ServicePrice { get; internal set; }
        public string BookingType { get; internal set; }
        public string Description { get; internal set; }
        public string CreatedDate { get; internal set; }
    }
}