using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class SalonCheckoutDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonCheckoutClass> obj = new List<SalonCheckoutClass>();
        public IEnumerable<SalonCheckoutClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonCheckout", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonCheckoutClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        PaymentStatus=dr["PaymentStatus"].ToString(),
                        PaymentType= dr["PaymentType"].ToString(),
                        PaymentsId= Convert.ToInt32(dr["PaymentsId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonCheckoutClass
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
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonCheckoutClass> GetbyId(int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonCheckout where SalonCheckoutId='" + SalonCheckoutId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonCheckoutClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PaymentsId = Convert.ToInt32(dr["PaymentsId"]),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdateBy= Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  UpdatedDate= dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonCheckoutClass> Insert( int EmployeeServicesId, string BookingDate, string BookingTime,string PaymentStatus, string PaymentType, int IsAcitve,string CreatedDate)
        {
   
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

            try
            {
                con.Open();
                MySqlCommand cmd3 = new MySqlCommand("select SalonCheckoutId from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);

                MySqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                int Number = Convert.ToInt32(dr3["SalonCheckoutId"]);
                dr3.Close();

                Random generator = new Random();
                int RandomNumber = generator.Next(100000, 1000000);
                string currentYear = DateTime.Now.Year.ToString();
                string UniqueNumber = currentYear + "_" + "AppyPetsBookingId" + "_" + RandomNumber + "_" + Number;


                MySqlCommand cmd = new MySqlCommand("insert into tblSalonCheckout(EmployeeServicesId,BookingDate,BookingTime,BookingsId,PaymentStatus,PaymentType,IsActive,CreatedDate) values(" + EmployeeServicesId + ",('" + BookingDate + "'),'" + BookingTime + "','"+ UniqueNumber + "','" + PaymentStatus + "','" + PaymentType + "','" + IsAcitve + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
              
                cmd.ExecuteNonQuery();


                MySqlCommand cmd2 = new MySqlCommand("select SalonCheckoutId from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);

                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                int SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                dr.Close();

                obj.Add(new SalonCheckoutClass { Message = "Success", SalonCheckoutId = SalonCheckoutId });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonCheckoutClass> InsertNew(int EmployeeServicesId, string BookingDate, string BookingTime, string PaymentStatus, string PaymentType, int IsAcitve, string CreatedDate)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime Date = DateTime.Parse(res2.Headers["Date"]);

            string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd");

            try
            {
                con.Open();
                MySqlCommand cmd3 = new MySqlCommand("select SalonCheckoutId from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);
                MySqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                int Number = Convert.ToInt32(dr3["SalonCheckoutId"]);
                dr3.Close();

                Random generator = new Random();
                int RandomNumber = generator.Next(100000, 1000000);
                string currentYear = DateTime.Now.Year.ToString();
                string UniqueNumber = currentYear + "_" + "AppyPetsBookingId" + "_" + RandomNumber + "_" + Number;

                MySqlCommand cmd5 = new MySqlCommand("insert into tblPayments(UserId,PaymentType,PaymentStatus,IsActive,CreatedBy,CreatedDate) values('','" + PaymentType + "','" + PaymentStatus + "','" + IsAcitve + "','','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                cmd5.ExecuteNonQuery();
                int paymentid = Convert.ToInt32(cmd5.LastInsertedId);



                MySqlCommand cmd = new MySqlCommand("insert into tblSalonCheckout(EmployeeServicesId,BookingDate,BookingTime,BookingsId,PaymentsId,PaymentStatus,PaymentType,IsActive,CreatedDate) values(" + EmployeeServicesId + ",('" + BookingDate + "'),'" + BookingTime + "','" + UniqueNumber + "','"+ paymentid + "','" + PaymentStatus + "','" + PaymentType + "','" + IsAcitve + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);

                cmd.ExecuteNonQuery();


                MySqlCommand cmd2 = new MySqlCommand("select SalonCheckoutId from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);

                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                int SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                dr.Close();

                obj.Add(new SalonCheckoutClass { Message = "Success", SalonCheckoutId = SalonCheckoutId });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonCheckoutClass> InsertNew1(string EmployeeServicesId, string BookingDate, string BookingTime, string PaymentStatus, string PaymentType, int IsAcitve, string CreatedDate, int SalonsId, string SalonServicesId, string BookingType)
        {
            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {

                string URL = "http://www.google.com";
                System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
                DateTime Date = DateTime.Parse(res2.Headers["Date"]);
                string Date1 = Convert.ToDateTime(Date).ToString("yyyy-MM-dd HH:mm:ss");

                MySqlCommand cmd3 = new MySqlCommand("select SalonCheckoutId from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);
                MySqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                int Number = Convert.ToInt32(dr3["SalonCheckoutId"]);
                dr3.Close();

                Random generator = new Random();
                int RandomNumber = generator.Next(100000, 1000000);
                string currentYear = DateTime.Now.Year.ToString();
                string UniqueNumber = currentYear + RandomNumber + Number;
                string EvoucherNumber = "EV" + currentYear + "A" + RandomNumber + "P" + Number;
                MySqlCommand cmd5 = new MySqlCommand("insert into tblPayments(UserId,PaymentType,PaymentStatus,IsActive,CreatedBy,CreatedDate) values('','" + PaymentType + "','" + PaymentStatus + "','" + IsAcitve + "','','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' )", con, tran);
                cmd5.ExecuteNonQuery();
                int paymentid = Convert.ToInt32(cmd5.LastInsertedId);

                string[] EmployeeSerId = EmployeeServicesId.Split(',');
                string[] BookDate = BookingDate.Split(',');
                string[] BookTime = BookingTime.Split(',');
                string[] SalonServId = SalonServicesId.Split(',');
                for (int p = 0; p < SalonServId.Length; p++)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblSalonCheckout(EmployeeServicesId,BookingDate,BookingTime,BookingsId,PaymentsId,PaymentStatus,PaymentType,IsActive,CreatedDate,SalonsId,SalonServicesId,BookingType,EvoucherNumber) values('" + EmployeeSerId[p] + "','" + BookDate[p] + "','" + BookTime[p] + "','" + UniqueNumber + "','" + paymentid + "','" + PaymentStatus + "','" + PaymentType + "','" + IsAcitve + "','" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd") + "','" + SalonsId + "','" + SalonServId[p] + "','" + BookingType + "','" + EvoucherNumber + "')", con, tran);

                    cmd.ExecuteNonQuery();
                }

                MySqlCommand cmd2 = new MySqlCommand("select SalonCheckoutId,EvoucherNumber from tblSalonCheckout order by SalonCheckoutId DESC limit 1", con);

                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                int SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]);
                string Evoucher = dr["EvoucherNumber"].ToString();
                dr.Close();

                obj.Add(new SalonCheckoutClass { Message = "Success", Evoucher = Evoucher, BookingsId = UniqueNumber, PaymentsId = paymentid, SalonCheckoutId = SalonCheckoutId });
                tran.Commit();
                return obj;
            }
            catch (MySqlException ex)
            {
                tran.Rollback();
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

















        public IEnumerable<SalonCheckoutClass> Update(  string PaymentStatus, string PaymentType, int PaymentsId, int UpdatedBy, string UpdatedDate ,int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonCheckout set IsActive='" + 1 + "', PaymentStatus='" + PaymentStatus + "',PaymentType='" + PaymentType + "',PaymentsId='" + PaymentsId + "',UpdateBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss") + "' where SalonCheckoutId=" + SalonCheckoutId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonCheckoutClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonCheckoutClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SalonCheckoutClass> UpdateStatus(int Status, int UpdatedBy, int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonCheckout set IsActive='" + Status + "',  UpdateBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonCheckoutId='" + SalonCheckoutId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonCheckoutClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonCheckoutClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class SalonCheckoutClass
    {
        public int SalonCheckoutId { get; set; }
        public int EmployeeServicesId { get; set; }
        public string BookingDate{get;set;}
        public string BookingTime { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string BookingsId { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public int  PaymentsId { get; set; }
        public string Evoucher { get; internal set; }
    }
}