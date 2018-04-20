using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class SalonschedulerDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonschedulerClass> obj = new List<SalonschedulerClass>();
        public IEnumerable<SalonschedulerClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblCustomers", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonschedulerClass
                    {
                        CustomerId = Convert.ToInt32(dr["CustomerId"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonschedulerClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonschedulerClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonschedulerClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonschedulerClass> GetPaymentsbySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonCheckout tsc, tblPayments tp, tblEmployeeServices tes, tblSalonEmployees tse, tblSalonServices tss, tblTreatmentTitle ttt, tblTreatmentType ttp, tblCustomers tc, tblCategory tca, tblDuration td where tsc.PaymentsId = tp.PaymentsId AND tes.EmployeeServicesId = tsc.EmployeeServicesId AND tes.SalonServicesId = tss.SalonServicesId AND ttt.TreatmentTitleId = tss.TreatmentTitleId AND ttp.TreatmentTypeId = tss.TreatmentTypeId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tca.CategoryId=tss.CategoryId AND tc.UserId = tp.UserId AND td.DurationId=tss.DurationId AND tsc.IsActive = 1 AND tss.SalonsId = '"+SalonsId+"'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonschedulerClass
                    {
                        CustomerId = Convert.ToInt32(dr["CustomerId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        Price = dr["Price"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonschedulerClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonschedulerClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonschedulerClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }
    public class SalonschedulerClass
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BookingDate { get; set; }
        public string BookingsId { get; set; }
        public string TreatmentType { get; set; }
        public string Price { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public string BookingTime { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}