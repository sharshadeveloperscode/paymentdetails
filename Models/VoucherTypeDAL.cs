using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Collections;

namespace SalonAPI.Models
{
    public class VoucherTypeDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<VoucherTypeClass> obj = new List<VoucherTypeClass>();

        //Getdata
        public IEnumerable<VoucherTypeClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(v.FromDate, '%d-%m-%Y') AS Fromdate1, DATE_FORMAT(v.ToDate, '%d-%m-%Y') AS Todate1 FROM tblVoucherType v where CouponName not in('Giftcard') and IsActive=1 ORDER BY VoucherTypeId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new VoucherTypeClass
                    {
                        VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                        GiftCoupon = dr["CouponCode"].ToString(),

                        FromDate1 = dr["Fromdate1"].ToString(),
                        ToDate1 = dr["Todate1"].ToString(),
                        CouponName = dr["CouponName"].ToString(),
                        //  VoucherTypeName = dr["VoucherTypeName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        // CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        // CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        // Get Gift Coupons 
        public IEnumerable<VoucherTypeClass> GetGiftCoupons()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT v.VoucherTypeId,v.Email,v.CouponCode,v.Status, v.CreatedDate, v.UpdatedDate,c.FirstName,c.LastName,DATE_FORMAT(v.ToDate, '%d/%m/%Y') AS Todate1 FROM tblVoucherType v, tblUsers u, tblCustomers c WHERE v.CouponName = 'Giftcard' AND v.UserId=u.UserId AND c.UserId=u.UserId AND v.Status NOT IN(0)", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new VoucherTypeClass
                    {
                        VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                        GiftCoupon = dr["CouponCode"].ToString(),
                        ToDate = dr["Todate1"].ToString(),
                        Status = Convert.ToInt32(dr["Status"]),
                        Email = dr["Email"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        // Total Active Salons
        public IEnumerable<VoucherTypeClass> TotalSalonsIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalons where IsActive=1", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new VoucherTypeClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //  VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                        //   VoucherTypeName = dr["VoucherTypeName"].ToString(),
                        //   IsActive = Convert.ToInt32(dr["IsActive"]),
                        //   CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        //    CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //
        public IEnumerable<VoucherTypeClass> CoupenApplicable(string CouponCode, string Salons, string Email)
        {

            //string URL = "http://www.google.com";
            //System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            //System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            //DateTime date = DateTime.Parse(res2.Headers["Date"]);

            //String Date = date.ToString("yyyy-MM-dd");

            string Date = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");

            //if (CouponCode.StartWith("hr") == true) {
            //}
            try
            {
                MySqlCommand cmd9 = new MySqlCommand("select * from tblVoucherType v where v.CouponCode='" + CouponCode + "'", con);
                con.Open();
                MySqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    //obj.Add(new VoucherTypeClass
                    //{
                    //    //  DiscountAmount = dr["DiscountAmount"].ToString(),
                    //    //  VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                    //    // Salons = dr["Salons"].ToString(),
                    //    //  Message = "Success",
                    //      CouponName = dr9["CouponName"].ToString(),
                    //      CouponCode = dr9["CouponName"].ToString(),
                    //});
                    string CouponName = dr9["CouponName"].ToString();
                    string CouponCode1 = dr9["CouponCode"].ToString();
                    if (CouponName == "Giftcard")
                    {
                        dr9.Close();
                        GiftCouponApplicable(CouponCode1, Email);
                        return obj;
                    }
                }
                if (!dr9.IsClosed)
                    dr9.Close();
                ///////
                MySqlCommand cmd = new MySqlCommand("select * from tblVoucherType v where v.CouponCode='" + CouponCode + "' AND  '" + Date + "' between v.FromDate AND v.ToDate AND v.IsActive=1", con);
                //  con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //obj.Add(new VoucherTypeClass
                    //{
                    //  DiscountAmount = dr["DiscountAmount"].ToString(),
                    //  VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                    // Salons = dr["Salons"].ToString(),
                    //  Message = "Success",
                    //  CouponName = dr["CouponName"].ToString();
                    //});
                }
                if (!dr.HasRows)
                {
                    dr.Close();
                    obj.Add(new VoucherTypeClass
                    {
                        Message = "Coupon Code Expired or Invalid",
                        DiscountAmount = 0,
                    });
                    return obj;
                }
                else
                {
                    //  int amount = Convert.ToInt32(dr["MinimumAmount"]);
                    string CouponName = dr["CouponName"].ToString();

                    string Salonsids = dr["Salons"].ToString();
                    int discountAmount = Convert.ToInt32(dr["DiscountAmount"]);
                    string couponcode = dr["couponcode"].ToString();
                    int voucherid = Convert.ToInt32(dr["VoucherTypeId"]);
                    //if (CouponName == "Giftcard")
                    //{

                    //}
                    dr.Close();
                    // MySqlCommand cmd2 = new MySqlCommand("select count(*) from tblVoucherType v where v.CouponCode='" + CouponCode + "' AND v.MinimumAmount<='" + MinimumAmount + "'", con);
                    // int j = Convert.ToInt32(cmd2.ExecuteScalar());
                    ////if(j==0)
                    // {
                    //     obj.Add(new VoucherTypeClass
                    //     {
                    //         Message = "Minimum Total Transaction Value Is " + amount,
                    //         DiscountAmount = 0,
                    //     });
                    //     return obj;
                    // }
                    //else
                    // {


                    string value = Salonsids;
                    char delimiter = ',';
                    string[] substrings = value.Split(delimiter);
                    int k = 0;
                    for (int i = 0; i < substrings.Length; i++)
                    {
                        if (substrings[i] == Salons)
                        {
                            k = 1;
                        }
                    }
                    if (k == 1)
                    {
                        obj.Add(new VoucherTypeClass
                        {
                            Message = "Coupon Code Applied Successfully",
                            DiscountAmount = discountAmount,
                            //   MinimumAmount= amount,
                            VoucherTypeId = voucherid,
                            GiftCoupon = couponcode,
                            CouponName = CouponName,
                            Salons = Salonsids,
                            // MinimumAmount= Convert.ToInt32(dr["MinimumAmount"]),
                            // VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                            //  CouponCode = dr["CouponCode"].ToString(),
                        });
                        return obj;
                    }
                    else
                    {
                        obj.Add(new VoucherTypeClass
                        {
                            Message = "Coupon Not Applicable For This Salon ",
                        });
                        return obj;
                    }

                    //   }
                }
                // return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<VoucherTypeClass> GiftCouponApplicable(string CouponCode, string Email)
        {
            string URL = "http://www.google.com";
            System.Net.HttpWebRequest rq2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
            System.Net.HttpWebResponse res2 = (System.Net.HttpWebResponse)rq2.GetResponse();
            DateTime date = DateTime.Parse(res2.Headers["Date"]);

            String Date = date.ToString("yyyy-MM-dd");
            try
            {

                MySqlCommand cmd = new MySqlCommand("select * from tblVoucherType v where v.CouponCode='" + CouponCode + "' AND  '" + Date + "' between v.FromDate AND v.ToDate AND v.Status=1 AND v.Email='" + Email + "'", con);
                // con.Open();

                MySqlDataReader dr2 = cmd.ExecuteReader();
                //  dr.Close();
                while (dr2.Read())
                {
                    obj.Add(new VoucherTypeClass
                    {
                        // TotalAmount = dr2["TotalAmount"].ToString(),
                        VoucherTypeId = Convert.ToInt32(dr2["VoucherTypeId"]),
                        DiscountAmount = Convert.ToInt32(dr2["TotalAmount"]),
                        GiftCoupon = dr2["CouponCode"].ToString(),
                        CouponName = dr2["CouponName"].ToString(),
                        // Salons = dr["Salons"].ToString(),
                        Message = "Coupon Code Applied Successfully",
                    });
                }

                if (!dr2.HasRows)
                {
                    dr2.Close();
                    obj.Add(new VoucherTypeClass
                    {
                        Message = "Coupon Code Expired or Invalid",
                        // DiscountAmount = 0,
                    });
                    return obj;
                }

                //else
                //{
                //    int Voucherid = Convert.ToInt32(dr2["VoucherTypeId"]);
                //    dr2.Close();
                //    MySqlCommand cmd1 = new MySqlCommand("update tblVoucherType set Status=2 where VoucherTypeId='" + Voucherid + "'", con);
                //    cmd1.ExecuteNonQuery();
                //}
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        // Update Gift Voucher
        public IEnumerable<VoucherTypeClass> UpdateVoucherCoupon(int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblVoucherType set Status=2 where VoucherTypeId='" + VoucherTypeId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        // Update Voucer Status And UserId based On Voucher Type Id
        public IEnumerable<VoucherTypeClass> UpdateVoucherStatus(int UserId, int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblVoucherType set Status=1,UserId='" + UserId + "'  where VoucherTypeId='" + VoucherTypeId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        //   GetbyId
        public IEnumerable<VoucherTypeClass> GetbyId(int VoucherId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,date_format(v.FromDate,'%d/%m/%Y') as Fromdate1,date_format(v.ToDate,'%d/%m/%Y') as Todate1 from tblVoucherType v  where VoucherTypeId='" + VoucherId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new VoucherTypeClass
                    {
                        VoucherTypeId = Convert.ToInt32(dr["VoucherTypeId"]),
                        CouponName = dr["CouponName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        GiftCoupon = dr["CouponCode"].ToString(),
                        FromDate1 = dr["Fromdate1"].ToString(),
                        ToDate1 = dr["Todate1"].ToString(),
                        // MinimumAmount = Convert.ToInt32(dr["MinimumAmount"]),
                        DiscountAmount = Convert.ToInt32(dr["DiscountAmount"]),
                        Salons = dr["Salons"].ToString(),
                        Description = dr["Description"].ToString(),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //Insert
        public IEnumerable<VoucherTypeClass> Insert(string VoucherTypeName, int IsAcitve, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblVoucherType(VoucherTypeName,IsActive,CreatedBy,CreatedDate) values('" + VoucherTypeName + "','" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        // Insert New
        public IEnumerable<VoucherTypeClass> InsertNew(string CouponName, string CouponCode, string FromDate, string ToDate, int DiscountAmount, string Salons, string Image, string ImagePath, string Description, int IsActive, int CreatedBy, int MinimumAmount)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblVoucherType(CouponName,CouponCode,FromDate,ToDate,DiscountAmount,Salons,Image,ImagePath,Description,IsActive,CreatedBy,CreatedDate,MinimumAmount) values('" + CouponName + "','" + CouponCode + "','" + FromDate + "','" + ToDate + "','" + DiscountAmount + "','" + Salons + "','" + Image + "','" + ImagePath + "','" + Description + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + MinimumAmount + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        //Update
        public IEnumerable<VoucherTypeClass> Update(string VoucherTypeName, int UpdatedBy, int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblVoucherType set VoucherTypeName='" + VoucherTypeName + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where VoucherTypeId=" + VoucherTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        //update New 
        public IEnumerable<VoucherTypeClass> UpdateNew(string CouponName, string CouponCode, string FromDate, string ToDate, int DiscountAmount, string Salons, string Image, string ImagePath, string Description, int IsActive, int UpdatedBy, int MinimumAmount, int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblVoucherType set CouponName='" + CouponName + "',CouponCode='" + CouponCode + "',FromDate='" + FromDate + "',ToDate='" + ToDate + "',DiscountAmount='" + DiscountAmount + "',Salons='" + Salons + "',Image='" + Image + "',ImagePath='" + ImagePath + "',Description='" + Description + "',IsActive='" + IsActive + "',UpdatedBy='" + UpdatedBy + "',MinimumAmount='" + MinimumAmount + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where VoucherTypeId=" + VoucherTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        //Delete
        public IEnumerable<VoucherTypeClass> Delete(int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblVoucherType where VoucherTypeId='" + VoucherTypeId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<VoucherTypeClass> UpdateStatus(int Status, int UpdatedBy, int VoucherTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblVoucherType set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where VoucherTypeId='" + VoucherTypeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new VoucherTypeClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<VoucherTypeClass> insertGiftVoucher(int Amount, string Quantity, string Email, string Address, int TotalAmount, int UserId, int Status, int CreatedBy, string Description, string PaymentStatus, int IsActive, string PaymentType)
        {
            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {

                MySqlCommand cmd3 = new MySqlCommand("select VoucherTypeId from tblVoucherType order by VoucherTypeId DESC limit 1", con, tran);
                MySqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                int Number = Convert.ToInt32(dr3["VoucherTypeId"]);
                dr3.Close();

                Random generator = new Random();
                int RandomNumber = generator.Next(100000, 1000000);
                string currentYear = DateTime.Now.Year.ToString();
                string Giftcard = "" + RandomNumber + Number;
                string CouponName1 = "Giftcard";
                string FromDate1 = DateTime.Now.ToString("yyyy-MM-dd");
                string dateInString = FromDate1;
                DateTime startDate = DateTime.Parse(dateInString);
                DateTime expiryDate = startDate.AddDays(30);
                string ToDate1 = Convert.ToDateTime(expiryDate).ToString("yyyy-MM-dd");
                //  endDate = endDate.AddDays(addedDays);
                //  string ToDate1 = FromDate1.AddDays(30);
                MySqlCommand cmd = new MySqlCommand("insert into tblVoucherType(Amount,Quantity,Email,Address,TotalAmount,UserId,CouponName,CouponCode,Status,CreatedBy,CreatedDate,Description,FromDate,ToDate)values(" + Amount + ",'" + Quantity + "','" + Email + "','" + Address + "'," + TotalAmount + "," + UserId + ",'" + CouponName1 + "','" + Giftcard + "'," + Status + "," + CreatedBy + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Description + "','" + FromDate1 + "','" + ToDate1 + "')", con, tran);
                cmd.ExecuteNonQuery();
                int giftcardId = Convert.ToInt32(cmd.LastInsertedId);
                MySqlCommand cmd1 = new MySqlCommand("insert into tblPayments(UserId,PaymentType,PaymentStatus,IsActive,CreatedBy,CreatedDate,GiftcardId) values('" + UserId + "','" + PaymentType + "','" + PaymentStatus + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + giftcardId + "' )", con, tran);
                cmd1.ExecuteNonQuery();
                int Paymenid = Convert.ToInt32(cmd1.LastInsertedId);
                obj.Add(new VoucherTypeClass { Message = "Success", VoucherTypeId = giftcardId, PaymentsId = Paymenid, GiftCoupon = Giftcard });
                tran.Commit();
                return obj;
            }
            catch (MySqlException ex)
            {
                tran.Rollback();
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }


        public IEnumerable<VoucherTypeClass> UpdateGiftVoucher(int UserId, int Status, int UpdatedBy, string PaymentStatus, int IsActive, string PaymentType, int VoucherTypeId, string OriginalAmount, string DiscountAmount, string PayableAmount, string CouponCode, int PaymentsId)
        {
            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {
                //int Amount, string Quantity, string Email, string Address, int TotalAmount, int UserId, int Status, int CreatedBy,string Description,string PaymentStatus,int IsActive,string PaymentType
                MySqlCommand cmd = new MySqlCommand("Update tblVoucherType set UserId=" + UserId + ", Status=" + Status + ", UpdatedBy=" + UpdatedBy + ", UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where VoucherTypeId=" + VoucherTypeId + "", con, tran);
                cmd.ExecuteNonQuery();
                //,PaymentStatus='"+PaymentStatus+"',IsActive='"+IsActive+ "',PaymentType='"+PaymentType+"'
                MySqlCommand cmd1 = new MySqlCommand("update tblPayments set UserId='" + UserId + "',PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',IsActive='" + IsActive + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',OriginalAmount='" + OriginalAmount + "',DiscountAmount='" + DiscountAmount + "',PayableAmount='" + PayableAmount + "',CouponCode='" + CouponCode + "',VoucherTypeId='" + VoucherTypeId + "' where PaymentsId=" + PaymentsId + "", con, tran);
                cmd1.ExecuteNonQuery();
                string CouponCode1 = CouponCode;
                obj.Add(new VoucherTypeClass { Message = "Success", GiftCoupon = CouponCode });
                tran.Commit();
                return obj;
            }
            catch (MySqlException ex)
            {
                tran.Rollback();
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new VoucherTypeClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new VoucherTypeClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }


    }
    public class VoucherTypeClass
    {
        public int VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string BusinessName { get; set; }
        public int SalonsId { get; set; }
        public string Salons { get; set; }
        public string GiftCoupon { get; set; }
        public int MinimumAmount { get; set; }
        public int DiscountAmount { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate1 { get; set; }
        public string FromDate1 { get; set; }
        public string CouponName { get; set; }
        public string Description { get; internal set; }
        public int PaymentsId { get; set; }
        public string TotalAmount { get; internal set; }
        public int Status { get; internal set; }
        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}