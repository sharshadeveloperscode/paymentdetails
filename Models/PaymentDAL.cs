using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
namespace SalonAPI.Models
{
    public class PaymentDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<PaymentClass> obj = new List<PaymentClass>();
        public IEnumerable<PaymentClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tp.*, tu.UserId from tblPayments tp, tblUsers tu where tp.UserId = tu.UserId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        PaymentsId = dr["PaymentsId"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PaymentClass> GetDatabyId(int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tp.*, tu.UserId from tblPayments tp, tblUsers tu where tp.UserId = tu.UserId AND PaymentsId='" + PaymentsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        PaymentsId = dr["PaymentsId"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BookingsId = dr["BookingsId"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PaymentClass> Insert(int UserId, string PaymentType, string PaymentStatus, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblPayments(UserId,PaymentType,PaymentStatus,IsActive,CreatedBy,CreatedDate) values('" + UserId + "','" + PaymentType + "','" + PaymentStatus + "','" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("select PaymentsId from tblPayments order by PaymentsId DESC limit 1", con);

                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                string PaymentsId1 = dr["PaymentsId"].ToString();
                dr.Close();

                obj.Add(new PaymentClass { Message = "Success", PaymentsId = PaymentsId1 });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<PaymentClass> Update(int UserId, string PaymentType, string PaymentStatus, int IsActive, int UpdatedBy, int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPayments set UserId='" + UserId + "',PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',IsActive='" + IsActive + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where PaymentsId=" + PaymentsId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new PaymentClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> UpdateNew(int UserId, string PaymentType, string PaymentStatus, int IsActive, int PaymentsId, int Isthisforyou, string ReferenceName, string OriginalAmount, string DiscountAmount, string PayableAmount, string CouponCode, int VoucherTypeId)
        {
            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPayments set UserId='" + UserId + "',PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',IsActive='" + IsActive + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',OriginalAmount='" + OriginalAmount + "',DiscountAmount='" + DiscountAmount + "',PayableAmount='" + PayableAmount + "',CouponCode='" + CouponCode + "',VoucherTypeId='" + VoucherTypeId + "' where PaymentsId=" + PaymentsId + "", con, tran);

                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = new MySqlCommand("update tblSalonCheckout set PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',IsActive=1, UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',Isthisforyou='" + Isthisforyou + "',ReferenceName='" + ReferenceName + "' where PaymentsId=" + PaymentsId + "", con, tran);
                cmd1.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand("select * from tblSalonCheckout where PaymentsId=" + PaymentsId + "", con, tran);
                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                string BookingsId = dr["BookingsId"].ToString();
                dr.Close();
                obj.Add(new PaymentClass { Message = "Success", BookingsId = BookingsId });
                tran.Commit();
                return obj;
            }
            catch (MySqlException ex)
            {
                tran.Rollback();
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                tran.Rollback();
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> Delete(int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblPayments where PaymentsId='" + PaymentsId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new PaymentClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<PaymentClass> UpdateStatus(int IsActive, int UpdatedBy, int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPayments set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where PaymentsId='" + PaymentsId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new PaymentClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<PaymentClass> GetAllPayments()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonCheckout tsc, tblEmployeeServices tpe, tblPayments tp, tblSalons ts, tblSalonEmployees tse, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblTreatmentType tt , tblDuration td , tblCity tct, tblArea ta Where tsc.PaymentsId = tp.PaymentsId AND tct.CityId=ta.CityId And tct.CityId=ts.CityId AND tss.SalonServicesId=tpe.SalonServicesId And td.DurationId=tss.DurationId AND tpe.EmployeeServicesId = tsc.EmployeeServicesId AND tpe.SalonEmployeesId = tse.SalonEmployeesId AND ts.SalonsId = tse.SalonsId AND tc.CategoryId = ttt.CategoryId AND tt.TreatmentTitleId = ttt.TreatmentTitleId group by tsc.SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {

                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        Email = dr["Email"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        BusinessType = dr["BusinessType"].ToString(),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Website = dr["Website"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> GetOrderbyUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select c.BookingsId,s.BusinessName,(select sum(chairs) from tblSalonCheckout where SalonCheckoutId=c.SalonCheckoutId) as Chairs,p.PaymentsId,date_format(c.CreatedDate,'%d/%m/%Y')as Bookeddate from tblSalonCheckout c inner join tblSalons s on c.SalonsId=s.SalonsId inner join tblPayments p on p.PaymentsId=c.PaymentsId where p.UserId=" + UserId + " group by BookingsId order by p.PaymentsId desc;", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        BookingsId = dr["BookingsId"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        Chairs = dr["Chairs"].ToString(),
                        CreatedDate = dr["Bookeddate"].ToString(),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        Message = "Success"
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<PaymentClass> GetAllPaymentsBySalonsIdId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("  select * from tblSalonCheckout tsc, tblEmployeeServices tpe, tblPayments tp, tblSalons ts, tblSalonEmployees tse, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblTreatmentType tt , tblDuration td , tblCity tct, tblArea ta Where tsc.PaymentsId = tp.PaymentsId AND tct.CityId=ta.CityId And tct.CityId=ts.CityId AND tss.SalonServicesId=tpe.SalonServicesId And td.DurationId=tss.DurationId AND tpe.EmployeeServicesId = tsc.EmployeeServicesId AND tpe.SalonEmployeesId = tse.SalonEmployeesId AND ts.SalonsId = tse.SalonsId AND tc.CategoryId = ttt.CategoryId AND tt.TreatmentTitleId = ttt.TreatmentTitleId and ts.SalonsId='" + SalonsId + "' AND tsc.IsActive = '1' group by tsc.SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        Email = dr["Email"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        BusinessType = dr["BusinessType"].ToString(),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Website = dr["Website"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),

                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PaymentClass> GetAllPaymentsByPaymentsId(int PaymentsId)
        {
            try
            {
                int countryId = 0;
                MySqlCommand cmd = new MySqlCommand("SELECT *,date_format(tsc.BookingDate,'%d-%m-%Y') as Bookdate FROM tblSalonCheckout tsc, tblEmployeeServices tpe, tblPayments tp, tblSalons ts, tblSalonEmployees tse, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND td.DurationId = tss.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tpe.EmployeeServicesId = tsc.EmployeeServicesId AND tpe.SalonEmployeesId = tse.SalonEmployeesId AND ts.SalonsId = tsc.SalonsId AND tc.CategoryId = ttt.CategoryId AND tp.PaymentsId = '" + PaymentsId + "' GROUP BY tsc.SalonCheckoutId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CountryId"] != DBNull.Value)
                        countryId = Convert.ToInt32(dr["CountryId"]);
                    obj.Add(new PaymentClass
                    {

                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        Bookdate = dr["Bookdate"].ToString(),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),

                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        Email = dr["Email"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = countryId,
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        BusinessType = dr["BusinessType"].ToString(),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Website = dr["Website"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        PayableAmount = dr["PayableAmount"].ToString(),
                        //  TreatmentType = dr["TreatmentType"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        //  CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //   UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    dr.Close();
                    MySqlCommand cmd2 = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate FROM tblSalonCheckout tsc, tblPayments tp, tblSalons ts, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND td.DurationId = tss.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND ts.SalonsId = tsc.SalonsId AND tc.CategoryId = ttt.CategoryId AND tp.PaymentsId = '" + PaymentsId + "' GROUP BY tsc.SalonCheckoutId", con);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        obj.Add(new PaymentClass
                        {
                            SalonCheckoutId = Convert.ToInt32(dr2["SalonCheckoutId"]),
                            // EmployeeServicesId = Convert.ToInt32(dr2["EmployeeServicesId"]),
                            BookingsId = dr2["BookingsId"].ToString(),
                            Bookdate = dr2["Bookdate"].ToString(),
                            Price = dr2["Price"].ToString(),
                            Duration = dr2["Duration"].ToString(),
                            CityName = dr2["CityName"].ToString(),
                            AreaName = dr2["AreaName"].ToString(),
                            Email = dr2["Email"].ToString(),
                            SalonServicesId = Convert.ToInt32(dr2["SalonServicesId"]),
                            //  SalonEmployeesId = Convert.ToInt32(dr2["SalonEmployeesId"]),
                            UserId = Convert.ToInt32(dr2["UserId"]),
                            SalonsId = Convert.ToInt32(dr2["SalonsId"]),
                            CityId = Convert.ToInt32(dr2["CityId"]),
                            CountryId = countryId,
                            SalonsUniqueId = dr2["SalonsUniqueId"].ToString(),
                            CategoryId = Convert.ToInt32(dr2["CategoryId"]),
                            TreatmentTitleId = Convert.ToInt32(dr2["TreatmentTitleId"]),
                            TreatmentTypeId = dr2["TreatmentTypeId"].ToString(),
                            //   MemberTypeId = Convert.ToInt32(dr2["MemberTypeId"]),
                            PaymentsId = dr2["PaymentsId"].ToString(),
                            BookingDate = dr2["BookingDate"].ToString(),
                            BookingTime = dr2["BookingTime"].ToString(),
                            PaymentStatus = dr2["PaymentStatus"].ToString(),
                            //   EmployeeName = dr2["EmployeeName"].ToString(),
                            BusinessName = dr2["BusinessName"].ToString(),
                            PaymentType = dr2["PaymentType"].ToString(),
                            // PricingLevel = dr2["PricingLevel"].ToString(),
                            //   JobTitle = dr2["JobTitle"].ToString(),
                            //  Phone = dr2["Phone"].ToString(),
                            //  Gender = dr2["Gender"].ToString(),
                            //   StartDate = dr2["StartDate"].ToString(),
                            //  StartTime = dr2["StartTime"].ToString(),
                            //  EndDate = dr2["EndDate"].ToString(),
                            //  EndTime = dr2["EndTime"].ToString(),
                            //    About = dr2["About"].ToString(),
                            //     Image = dr2["Image"].ToString(),
                            ImagePath = dr2["ImagePath"].ToString(),
                            BusinessType = dr2["BusinessType"].ToString(),
                            Name = dr2["Name"].ToString(),
                            Address = dr2["Address"].ToString(),
                            PostalCode = dr2["PostalCode"].ToString(),
                            Website = dr2["Website"].ToString(),
                            GoogleMaps = dr2["GoogleMaps"].ToString(),
                            TreatmentTitle = dr2["TreatmentTitle"].ToString(),
                            PayableAmount = dr2["PayableAmount"].ToString(),
                            //  TreatmentType = dr2["TreatmentType"].ToString(),
                            IsActive = Convert.ToInt32(dr2["IsActive"]),
                            //  CreatedBy = Convert.ToInt32(dr2["CreatedBy"]),
                            //   UpdatedBy = Convert.ToInt32(dr2["UpdateBy"]),
                            CreatedDate = dr2["CreatedDate"].ToString(),
                            UpdatedDate = dr2["UpdatedDate"].ToString(),
                            Message = "Success",
                        });
                    }
                    if (!dr2.HasRows)
                    {
                        obj.Add(new PaymentClass
                        {
                            Message = "NoData"
                        });
                    }
                    return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PaymentClass> GetAllPaymentsByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" SELECT *,date_format(tsc.BookingDate,'%d-%m-%Y') as Bookdate FROM tblSalonCheckout tsc, tblEmployeeServices tpe, tblPayments tp, tblSalons ts, tblSalonEmployees tse, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND td.DurationId = tss.DurationId AND tpe.EmployeeServicesId = tsc.EmployeeServicesId AND tpe.SalonEmployeesId = tse.SalonEmployeesId AND ts.SalonsId = tsc.SalonsId AND tc.CategoryId = ttt.CategoryId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tp.UserId = '" + UserId + "' GROUP BY tsc.SalonCheckoutId DESC ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        Bookdate = dr["Bookdate"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Email = dr["Email"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        BusinessType = dr["BusinessType"].ToString(),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Website = dr["Website"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<PaymentClass> GetAllPaymentsByUserIdAndSaloncheckoutId(int UserId, int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" SELECT *,date_format(tsc.BookingDate,'%d-%m-%Y') as Bookdate FROM tblSalonCheckout tsc, tblEmployeeServices tpe, tblPayments tp, tblSalons ts, tblSalonEmployees tse, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND tss.SalonServicesId = tpe.SalonServicesId AND td.DurationId = tss.DurationId AND tpe.SalonEmployeesId = tse.SalonEmployeesId AND ts.SalonsId = tse.SalonsId AND tc.CategoryId = ttt.CategoryId AND tss.TreatmentTitleId = ttt.TreatmentTitleId and ta.AreaId=ts.AreaId  AND ts.SalonsId = tsc.SalonsId AND tp.UserId = '" + UserId + "' AND tsc.SalonCheckoutId='" + SalonCheckoutId + "' GROUP BY tsc.SalonCheckoutId DESC ", con); //AND tpe.EmployeeServicesId = tsc.EmployeeServicesId 
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        Bookdate = dr["Bookdate"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        Price = dr["Price"].ToString(),
                        ServicePrice = dr["ServicePrice"].ToString(),
                        PayableAmount = dr["PayableAmount"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Email = dr["Email"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        BusinessType = dr["BusinessType"].ToString(),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Website = dr["Website"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> Complete(string PaymentStatus, int IsActive, int UpdatedBy, int PaymentsId, int SalonCheckoutId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblPayments set PaymentStatus='" + PaymentStatus + "', IsActive='1',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where PaymentsId='" + PaymentsId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = new MySqlCommand("update tblSalonCheckout set PaymentStatus='" + PaymentStatus + "', IsActive='" + IsActive + "',  UpdateBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonCheckoutId='" + SalonCheckoutId + "' ", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                obj.Add(new PaymentClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<PaymentClass> GetAllPaymentsByUser(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate FROM tblSalonCheckout tsc, tblPayments tp, tblSalons ts, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND td.DurationId = tss.DurationId AND ts.SalonsId = tsc.SalonsId AND tc.CategoryId = ttt.CategoryId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tp.UserId = " + UserId + " GROUP BY tsc.SalonCheckoutId Order By tsc.SalonCheckoutId DESC", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        //   EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        Bookdate = dr["Bookdate"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        EvoucherNumber = dr["EvoucherNumber"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //  SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        //   PhoneNumber = dr["PhoneNumber"].ToString(),
                        //   Email = dr["Email"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //     MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        //   EmployeeName = dr["EmployeeName"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        //    PricingLevel = dr["PricingLevel"].ToString(),
                        //   JobTitle = dr["JobTitle"].ToString(),
                        //  Phone = dr["Phone"].ToString(),
                        //  Gender = dr["Gender"].ToString(),
                        //   StartDate = dr["StartDate"].ToString(),
                        //   StartTime = dr["StartTime"].ToString(),
                        //   EndDate = dr["EndDate"].ToString(),
                        //   EndTime = dr["EndTime"].ToString(),
                        //    About = dr["About"].ToString(),
                        //   Image = dr["Image"].ToString(),
                        //    ImagePath = dr["ImagePath"].ToString(),
                        //   BusinessType = dr["BusinessType"].ToString(),
                        //   Name = dr["Name"].ToString(),
                        //   Address = dr["Address"].ToString(),
                        //  PostalCode = dr["PostalCode"].ToString(),
                        //  Website = dr["Website"].ToString(),
                        //  GoogleMaps = dr["GoogleMaps"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdateBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> GetBookingDetailsByPaymentId(int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate FROM tblSalonCheckout tsc, tblPayments tp, tblSalons ts, tblSalonServices tss, tblCategory tc, tblTreatmentTitle ttt, tblDuration td, tblCity tct, tblArea ta WHERE tsc.PaymentsId = tp.PaymentsId AND tct.CityId = ta.CityId AND tct.CityId = ts.CityId AND tss.SalonServicesId = tsc.SalonServicesId AND td.DurationId = tss.DurationId AND ts.SalonsId = tsc.SalonsId AND tc.CategoryId = ttt.CategoryId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tsc.PaymentsId = " + PaymentsId + " GROUP BY tsc.SalonCheckoutId Order By tsc.SalonCheckoutId DESC", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new PaymentClass
                    {
                        SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                        BookingsId = dr["BookingsId"].ToString(),
                        Bookdate = dr["Bookdate"].ToString(),
                        BookingType = dr["BookingType"].ToString(),
                        EvoucherNumber = dr["EvoucherNumber"].ToString(),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        AreaName = dr["AreaName"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PaymentsId = dr["PaymentsId"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        PaymentStatus = dr["PaymentStatus"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new PaymentClass
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
                    obj.Add(new PaymentClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<PaymentClass> UpdateServicePrices(string Price, int Serviceid, int PaymentsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonCheckout set ServicePrice='" + Price + "' where SalonServicesId='" + Serviceid + "'and PaymentsId=" + PaymentsId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new PaymentClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new PaymentClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }




    }
    public class PaymentClass
    {
        public int SalonCheckoutId { get; set; }
        public int EmployeeServicesId { get; set; }
        public string BookingsId { get; set; }
        public string Bookdate { get; set; }
        public int SalonServicesId { get; set; }
        public int IsActive { get; set; }
        public int UserId { get; set; }
        public int SalonEmployeesId { get; set; }
        public int SalonsId { get; set; }
        public int MemberTypeId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string SalonsUniqueId { get; set; }
        public int CategoryId { get; set; }
        public int TreatmentTitleId { get; set; }
        public string TreatmentTypeId { get; set; }
        public string PaymentsId { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public string EmployeeName { get; set; }
        public string PricingLevel { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Website { get; set; }
        public string GoogleMaps { get; set; }
        public string TreatmentTitle { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        public string DurationId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PayableAmount { get; set; }
        public string BookingType { get; set; }
        public string EvoucherNumber { get; set; }
        public string ServicePrice { get; internal set; }
        public string Chairs { get; internal set; }
    }
}