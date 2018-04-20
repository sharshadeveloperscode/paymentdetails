using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class ClientDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<ClientClass> obj = new List<ClientClass>();

        public IEnumerable<ClientClass> ListofClientsbasedonSalonssId(int SalonsId)
        {
            try
            {
                
                MySqlCommand cmd = new MySqlCommand("SELECT *,tp.UserId,count(*) as Bookingscount , tsc.BookingDate as date, MAX(tsc.BookingDate) as LastBookingDate, tc.Email as CustomerEmail, tc.PhoneNumber as CustomerPhoneNumber FROM tblSalonCheckout tsc, tblEmployeeServices tes, tblTreatmentTitle tt, tblCustomers tc, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.BookingDate AND tsc.IsActive = 4 AND tss.SalonsId = '"+SalonsId+"' GROUP BY tp.UserId HAVING COUNT(*) >= 1  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ClientClass
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        CustomerEmail = dr["CustomerEmail"].ToString(),
                        CustomerPhoneNumber = dr["CustomerPhoneNumber"].ToString(),
                       // SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        LastBookingDate = dr["LastBookingDate"].ToString(),
                        Bookingscount = dr["Bookingscount"].ToString(),
                        //  BookingDate = dr["BookingDate"].ToString(),
                        //  BookingTime = dr["BookingTime"].ToString(),
                        // TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        // PaymentType = dr["PaymentType"].ToString(),
                        // BookingsId = dr["BookingsId"].ToString(),
                        // Price = dr["Price"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        // SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //   IsActive = Convert.ToInt32(dr["IsActive"]),
                        //   mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ClientClass
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
                    obj.Add(new ClientClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ClientClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ClientClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<ClientClass> SearchByNameEmail(int SalonsId,string Name ,string Email)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT *,tp.UserId,count(*) as Bookingscount , tsc.BookingDate as date, MAX(tsc.BookingDate) as LastBookingDate, tc.Email as CustomerEmail, tc.PhoneNumber as CustomerPhoneNumber FROM tblSalonCheckout tsc, tblEmployeeServices tes, tblTreatmentTitle tt, tblCustomers tc, tblSalonServices tss, tblSalonEmployees tse, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tt.TreatmentTitleId = tss.TreatmentTitleId AND tss.SalonServicesId = tes.SalonServicesId AND tp.PaymentsId = tsc.PaymentsId AND tc.UserId = tp.UserId AND tsc.BookingDate AND tc.FirstName like '"+Name+"%' AND tc.Email like '"+Email+"%' AND tsc.IsActive = 4 AND tss.SalonsId = '"+SalonsId+"' GROUP BY tp.UserId HAVING COUNT(*) >= 1  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new ClientClass
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        CustomerEmail = dr["CustomerEmail"].ToString(),
                        CustomerPhoneNumber = dr["CustomerPhoneNumber"].ToString(),
                       // SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        LastBookingDate = dr["LastBookingDate"].ToString(),
                        Bookingscount = dr["Bookingscount"].ToString(),
                        //  BookingDate = dr["BookingDate"].ToString(),
                        //  BookingTime = dr["BookingTime"].ToString(),
                        // TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PaymentStatus = dr["PaymentStatus"].ToString(),
                        // PaymentType = dr["PaymentType"].ToString(),
                        // BookingsId = dr["BookingsId"].ToString(),
                        // Price = dr["Price"].ToString(),
                        // EndTime = dr["EndTime"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        // SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //   IsActive = Convert.ToInt32(dr["IsActive"]),
                        //   mydate = dr["mydate"].ToString(),
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
                    obj.Add(new ClientClass
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
                    obj.Add(new ClientClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new ClientClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new ClientClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class ClientClass
    {
        public int UserId { get; set; }
        public int SalonsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string Bookingscount { get; set; }
        public string LastBookingDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}