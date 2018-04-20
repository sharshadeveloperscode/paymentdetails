using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class AdminReportsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<AdminReportsClass> obj = new List<AdminReportsClass>();
        public IEnumerable<AdminReportsClass> TodayBookings()
        {

            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

            try
            {
                
                MySqlCommand cmd = new MySqlCommand("SELECT* FROM tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp, tblSalons s WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.IsActive = 1 AND DATE(tsc.BookingDate) = '" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "' AND s.SalonsId = tsc.SalonsId GROUP BY tsc.SalonCheckoutId", con);

                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.IsActive = 1 AND DATE(tsc.BookingDate) = curdate() GROUP BY tsc.SalonCheckoutId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                       BusinessName = dr["BusinessName"].ToString(),
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
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> TopServicesBooking()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, tsc. EmployeeServicesId, COUNT(*) as Count FROM tblSalonCheckout tsc, tblEmployeeServices tes, tblSalonServices tss, tblCategory tc, tblTreatmentType tp, tblTreatmentTitle tt where tsc.EmployeeServicesId=tes.EmployeeServicesId AND tss.SalonServicesId=tes.SalonServicesId AND tss.CategoryId=tc.CategoryId AND tss.TreatmentTypeId=tp.TreatmentTypeId AND tss.TreatmentTitleId=tt.TreatmentTitleId GROUP BY tes.SalonServicesId HAVING COUNT(*) > 1 order by count(*) DESC limit 5 ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
                    {
                        Count= Convert.ToInt32(dr["Count"]),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                      //  FirstName = dr["FirstName"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        Price = dr["Price"].ToString(),
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
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                         Category = dr["Category"].ToString(),
                        TreatmentType = dr["TreatmentType"].ToString(),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> NewTopServicesBooking()
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT ttt.TreatmentType, count(*) as Count FROM tblSalonServices tss, tblEmployeeServices tes, tblSalonCheckout tsc, tblTreatmentType ttt WHERE tss.SalonServicesId = tes.SalonServicesId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tss.TreatmentTypeId = ttt.TreatmentTypeId GROUP BY ttt.TreatmentType ORDER BY count(*) DESC ", con);

                //MySqlCommand cmd = new MySqlCommand("SELECT tss.TreatmentTypeId, COUNT(*) AS Count FROM tblSalonServices tss, tblSalonCheckout tsc WHERE tss.TreatmentTypeId = tss.TreatmentTypeId AND tsc.IsActive = 4  GROUP BY tss.TreatmentTypeId ORDER BY COUNT(*) DESC", con);
                MySqlCommand cmd = new MySqlCommand("SELECT tt.TreatmentTitle,COUNT(*) AS Count ,tc.Category FROM tblSalonCheckout tsc, tblSalonServices tss, tblTreatmentTitle tt, tblCategory tc where tsc.SalonServicesId=tss.SalonServicesId AND tt.TreatmentTitleId=tss.TreatmentTitleId AND tc.CategoryId=tss.CategoryId AND tsc.IsActive=4 GROUP BY tss.TreatmentTitleId order by count(*) desc limit 5", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
                    {
                        Count = Convert.ToInt32(dr["Count"]),
                        Category = dr["Category"].ToString(),
                        // BookingDate = dr["BookingDate"].ToString(),
                        //  BookingTime = dr["BookingTime"].ToString(),
                        //  TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  FirstName = dr["FirstName"].ToString(),
                        //  PaymentStatus = dr["PaymentStatus"].ToString(),
                        //   BookingsId = dr["BookingsId"].ToString(),
                        //   Price = dr["Price"].ToString(),
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
                        //   SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        //   Category = dr["Category"].ToString(),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> ConfirmCancelBookings()
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT A.Year, A.month,A.count as cancel, B.count as booked FROM(SELECT YEAR(BookingDate) as 'Year', MONTHNAME(BookingDate) as 'Month', COUNT(BookingDate) as 'Count' FROM tblSalonCheckout WHERE IsActive = 2 AND year(BookingDate) = year('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') GROUP BY Month(BookingDate), Year(BookingDate)) AS A left OUTER JOIN (SELECT YEAR(BookingDate) as 'Year', MONTHNAME(BookingDate) as 'Month', COUNT(BookingDate) as 'Count' FROM tblSalonCheckout WHERE IsActive = 4 AND year(BookingDate) = year('" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "') GROUP BY Month(BookingDate), Year(BookingDate)) As B on A.Month = B.Month ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
                    {
                       // Count = Convert.ToInt32(dr["Count"]),

                        Year=dr["Year"].ToString(),
                        month=dr["month"].ToString(),
                        cancel=dr["cancel"].ToString(),
                        booked=dr["booked"].ToString(),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<AdminReportsClass> MonthlyBookings( string Month, string Year,string Day)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.IsActive = 4 AND Month(tsc.BookingDate) = '" + Month + "' AND year(tsc.BookingDate) = '" + Year + "' AND Day(tsc.BookingDate) = '"+Day+"' group by tsc.SalonCheckoutId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
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
                //if (!dr.HasRows)
                //{
                //    obj.Add(new AdminReportsClass
                //    {
                //        Message = "NoData"
                //    });
                //    return obj;
                //}
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> CurrentMonth(string Month)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.IsActive = 4 AND Month(tsc.BookingDate) = '" + Month + "'  group by tsc.SalonCheckoutId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
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
                //if (!dr.HasRows)
                //{
                //    obj.Add(new AdminReportsClass
                //    {
                //        Message = "NoData"
                //    });
                //    return obj;
                //}
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> Bookingcancellations()
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp, tblSalons ts WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND ts.SalonsId=tss.SalonsId AND tsc.IsActive = 2 group by tsc.SalonCheckoutId;", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
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
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
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
                        BusinessName = dr["BusinessName"].ToString(),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> MonthlyBookingcancellations(string Month, string Year,string Day)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp, tblSalons ts WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND ts.SalonsId = tss.SalonsId AND Month(tsc.BookingDate) = '" + Month + "' AND year(tsc.BookingDate) = '" + Year + "' AND Day(tsc.BookingDate) = '"+Day+"' AND tsc.IsActive = 2 group by tsc.SalonCheckoutId;", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
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
                        BusinessName = dr["BusinessName"].ToString(),
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<AdminReportsClass> OldCustomers()
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * from tblSalonCheckout tsc, tblCustomers tc, tblEmployeeServices tes, tblTreatmentTitle tt, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId  AND tsc.IsActive = 1 GROUP BY tp.UserId having count(*)>1 ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass
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
                    obj.Add(new AdminReportsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new AdminReportsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class AdminReportsClass
    {
           
        public int Count { get; set; }
        public string Year { get; set; }
        public string month { get; set; }
        public string cancel { get; set; }
        public string booked { get; set; }
        public string BookingDate { get; set; }
        public string BusinessName { get; set; }
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
        
             public string TreatmentType { get; set; }
        public string Category { get; set; }
        public string mydate { get; set; }
        public int DurationId { get; set; }
        public int SalonCheckoutId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string TreatmentTypeId { get;  set; }
        public int TreatmentTitleId { get; internal set; }
        public string ServicePrice { get; internal set; }
    }
}