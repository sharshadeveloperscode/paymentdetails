using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SalonAPI.Models
{
    public class SalonServicesDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonServicesClass> obj = new List<SalonServicesClass>();

        List<Schedular> objSchedular = new List<Schedular>();

        public IEnumerable<SalonServicesClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        Category = dr["Category"].ToString(),
                        Description = dr["Description"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),

                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> GetCategorysIsActive(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonServices tss,tblCategory tc where tss.CategoryId=tc.CategoryId and tss.IsActive=1 and tc.IsActive=1 and tss.SalonsId='" + SalonsId + "' group by tss.CategoryId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        Category = dr["Category"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonServicesClass> GetDatabyId(int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND ts.SalonServicesId='" + SalonServicesId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {

                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        featuredServices = Convert.ToInt32(dr["featuredServices"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> GetDiscountsbySalonsId(int SalonsId, int CategoryId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblDiscount where SalonsId='" + SalonsId + "' AND CategoryId='" + CategoryId + "' order by  DiscountId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {

                    obj.Add(new SalonServicesClass
                    {
                        DiscountId = Convert.ToInt32(dr["DiscountId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Session = dr["Session"].ToString(),
                        SessionStart = dr["SessionStart"].ToString(),
                        SessionEnd = dr["SessionEnd"].ToString(),
                        MonDay = dr["MonDay"].ToString(),
                        TuesDay = dr["TuesDay"].ToString(),
                        WednesDay = dr["WednesDay"].ToString(),
                        ThursDay = dr["ThursDay"].ToString(),
                        FriDay = dr["FriDay"].ToString(),
                        SaturDay = dr["SaturDay"].ToString(),
                        SunDay = dr["SunDay"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> FeratureServicesbySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId,d.Duration,t.CleanUpTime as Cleanuptime1 FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d,tblCleanUpTime t WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND t.CleanUpTimeId=ts.CleanUpTime AND ts.featuredServices=1 AND ts.SalonsId = '" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),

                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        featuredServices = Convert.ToInt32(dr["featuredServices"]),
                        Duration = dr["Duration"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime1 = dr["Cleanuptime1"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> GetDatabySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId,d.Duration,t.CleanUpTime as Cleanuptime1,(select count(*) from tblFavouriteSalonService where SalonServicesId=ts.SalonServicesId)as Favourite,(select avg(ServiceRating) from tblSalonServiceReviews where SalonServicesId=ts.SalonServicesId)as Rating FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d,tblCleanUpTime t WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND t.CleanUpTimeId=ts.CleanUpTime AND ts.SalonsId ='" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        Price = dr["Price"].ToString(),
                        Rating = dr["Rating"].ToString(),
                        Favourite = dr["Favourite"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime1 = dr["Cleanuptime1"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonServicesClass> GetDatabySalonsIdIsActive(int SalonsId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("select ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tt.TreatmentTypeId, tt.IsActive, tti.IsActive, tc.IsActive, tt.TreatmentType, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId from tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentType tt, tblTreatmentTitle tti, tblDuration d where ts.SalonsId = tsi.SalonsId and ts.CategoryId = tc.CategoryId and ts.TreatmentTypeId = tt.TreatmentTypeId and ts.TreatmentTitleId = tti.TreatmentTitleId and ts.DurationId = d.DurationId and tt.IsActive=1 and tti.IsActive=1 and tc.IsActive=1 and ts.SalonsId = '" + SalonsId + "'", con);
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.IsActive, tc.IsActive, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND ts.IsActive=1 AND tti.IsActive = 1 AND tc.IsActive = 1 AND ts.SalonsId = " + SalonsId + "", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),

                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),

                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonServicesClass> GetDatabyEmpId(int SalonEmployeesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tes.EmployeeServicesId, tes.IsActive AS Status, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d, tblSalonEmployees tse, tblEmployeeServices tes WHERE ts.SalonsId = tsi.SalonsId AND tse.SalonEmployeesId = tes.SalonEmployeesId AND ts.CategoryId = tc.CategoryId AND tes.SalonServicesId = ts.SalonServicesId AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND tes.SalonEmployeesId = '" + SalonEmployeesId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),

                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["Status"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> TreatmentTitlebasedonSalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonServices tss,tblSalons ts,tblTreatmentTitle tt,tblCategory tc,tblTreatmentType ttt,tblEmployeeServices tes,tblSalonEmployees tse where tss.TreatmentTitleId=tt.TreatmentTitleId AND tc.CategoryId=tss.CategoryId AND ttt.TreatmentTypeId=tss.TreatmentTypeId AND tes.SalonServicesId=tss.SalonServicesId AND tse.SalonEmployeesId=tes.SalonEmployeesId AND ts.SalonsId=tss.SalonsId AND ts.SalonsId='" + SalonsId + "' group by tss.SalonServicesId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //   Price = dr["Price"].ToString(),
                        //   Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //  Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // TreatmentType = dr["TreatmentType"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //DurationId = Convert.ToInt32(dr["DurationId"]),
                        //CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        // IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonServicesClass> GetUnAssDatabyEmpId(int SalonsId, int SalonEmployeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId FROM tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentTitle tti, tblDuration d, tblSalonEmployees se WHERE ts.SalonsId = tsi.SalonsId AND ts.CategoryId = tc.CategoryId AND ts.IsActive=1 AND ts.TreatmentTitleId = tti.TreatmentTitleId AND ts.DurationId = d.DurationId AND ts.SalonsId = " + SalonsId + " AND se.SalonsId = ts.SalonsId AND se.SalonEmployeesId = " + SalonEmployeeId + " AND ts.SalonServicesId NOT IN(SELECT SalonServicesId FROM tblEmployeeServices WHERE SalonEmployeesId = " + SalonEmployeeId + ")", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonServicesClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),

                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),

                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        CleanUpTime = Convert.ToInt32(dr["CleanUpTime"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonServicesClass
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
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SalonServicesClass> Insert(int SalonsId, int CategoryId, string TreatmentTypeId, int TreatmentTitleId, int PricingTypeId, int DurationId, string Price, string Sale, int CleanUpTime, string Description, int IsAcitve, int CreatedBy, int featuredServices, string ImagePath)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonServices(SalonsId,CategoryId,TreatmentTypeId,TreatmentTitleId,PricingTypeId,DurationId,Price,Sale,CleanUpTime,Description,IsActive,CreatedBy,CreatedDate,featuredServices,ImagePath) values('" + SalonsId + "','" + CategoryId + "','" + TreatmentTypeId + "','" + TreatmentTitleId + "','" + PricingTypeId + "','" + DurationId + "','" + Price + "','" + Sale + "'," + CleanUpTime + ",@Description,'" + IsAcitve + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + featuredServices + "',@ImagePath)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                cmd.ExecuteNonQuery();
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        public String[] MyString(string data)
        {
            string value = data;
            char delimiter = ',';
            string[] substrings = value.Split(delimiter);
            return substrings;
        }
        //public String[] MyString1(string data)
        //{
        //    string value = data;
        //    char delimiter = ',';
        //    string[] substrings = value.Split(delimiter);
        //    return substrings;
        //}
        public IEnumerable<SalonServicesClass> InsertDiscount(int CategoryId, int SalonsId, string Session, string SessionStart, string SessionEnd, string MonDay, string TuesDay, string WednesDay, string ThursDay, string FriDay, string SaturDay, string SunDay, int IsActive, int CreatedBy)
        {
            try
            {
                con.Open();
                //  string[] myCategoryId = MyString1(CategoryId);
                string[] mySession = MyString(Session);
                string[] mySessionStart = MyString(SessionStart);
                string[] mySessionEnd = MyString(SessionEnd);
                string[] myMonDay = MyString(MonDay);
                string[] myTuesDay = MyString(TuesDay);
                string[] myWednesDay = MyString(WednesDay);
                string[] myThursDay = MyString(ThursDay);
                string[] myFriDay = MyString(FriDay);
                string[] mySaturDay = MyString(SaturDay);
                string[] mySunDay = MyString(SunDay);

                //   for (int k = 0; k < myCategoryId.Length; k++)
                //   {
                for (int i = 0; i < mySession.Length; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into tblDiscount(CategoryId,SalonsId,Session,SessionStart, SessionEnd, MonDay, TuesDay, WednesDay, ThursDay, FriDay, SaturDay,SunDay, IsActive, CreatedBy, CreatedDate)values(" + CategoryId + "," + SalonsId + ",'" + mySession[i] + "','" + mySessionStart[i] + "','" + mySessionEnd[i] + "','" + myMonDay[i] + "','" + myTuesDay[i] + "','" + myWednesDay[i] + "','" + myThursDay[i] + "','" + myFriDay[i] + "','" + mySaturDay[i] + "','" + mySunDay[i] + "'," + IsActive + "," + CreatedBy + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", con);

                    cmd.ExecuteNonQuery();
                    // }
                }
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonServicesClass> Update(int SalonsId, int CategoryId, string TreatmentTypeId, int TreatmentTitleId, int PricingTypeId, int DurationId, string Price, string Sale, int CleanUpTime, string Description, int UpdatedBy, int featuredServices, int SalonServicesId, string ImagePath)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonServices set SalonsId='" + SalonsId + "', CategoryId='" + CategoryId + "',TreatmentTypeId='" + TreatmentTypeId + "',TreatmentTitleId='" + TreatmentTitleId + "',PricingTypeId='" + PricingTypeId + "',DurationId='" + DurationId + "',Price='" + Price + "',Sale='" + Sale + "', CleanUpTime='" + CleanUpTime + "',Description=@Description, UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', featuredServices='" + featuredServices + "',ImagePath=@ImagePath where SalonServicesId=" + SalonServicesId + "", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                cmd.ExecuteNonQuery();
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonServicesClass> UpdateDiscount(int CategoryId, int SalonsId, string Session, string SessionStart, string SessionEnd, string MonDay, string TuesDay, string WednesDay, string ThursDay, string FriDay, string SaturDay, string SunDay, int IsActive, int UpdatedBy)
        {
            try
            {
                con.Open();
                //  string[] myCategoryId = MyString1(CategoryId);
                string[] mySession = MyString(Session);
                string[] mySessionStart = MyString(SessionStart);
                string[] mySessionEnd = MyString(SessionEnd);
                string[] myMonDay = MyString(MonDay);
                string[] myTuesDay = MyString(TuesDay);
                string[] myWednesDay = MyString(WednesDay);
                string[] myThursDay = MyString(ThursDay);
                string[] myFriDay = MyString(FriDay);
                string[] mySaturDay = MyString(SaturDay);
                string[] mySunDay = MyString(SunDay);

                //   for (int k = 0; k < myCategoryId.Length; k++)
                //  {
                for (int i = 0; i < mySession.Length; i++)
                {


                    MySqlCommand cmd = new MySqlCommand("Update tblDiscount set CategoryId=" + CategoryId + ",SalonsId=" + SalonsId + ",Session='" + mySession[i] + "',SessionStart='" + mySessionStart[i] + "',SessionEnd='" + mySessionEnd[i] + "',MonDay='" + myMonDay[i] + "', TuesDay='" + myTuesDay[i] + "', WednesDay='" + myWednesDay[i] + "', ThursDay='" + myThursDay[i] + "', FriDay='" + myFriDay[i] + "', SaturDay='" + mySaturDay[i] + "', SunDay='" + mySunDay[i] + "', IsActive=" + IsActive + ", UpdatedBy=" + UpdatedBy + ", UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where SalonsId=" + SalonsId + " AND Session='" + mySession[i] + "' AND CategoryId=" + CategoryId + " ", con);

                    cmd.ExecuteNonQuery();
                    //  }
                }


                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }


        public IEnumerable<SalonServicesClass> Delete(int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSalonServices where SalonServicesId='" + SalonServicesId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonServicesClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonServices set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonServicesId='" + SalonServicesId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<SalonServicesClass> UpdateFetureService(int featuredServices, int UpdatedBy, int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonServices set featuredServices='" + featuredServices + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonServicesId='" + SalonServicesId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonServicesClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        //public IEnumerable<Schedular> GetEmployeeBookings(int SalonId)
        //{
        //    try
        //    {
        //        //MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT  'Tuesday' AS Day,sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate, (SELECT bhs.StartTime FROM tblStartTime bhs WHERE bhs.StartTimeId = (SELECT bh.OpeningHours FROM tblBusinessHours bh WHERE bh.SalonsId = " + SalonId + " AND bh.Day = 'Monday')) AS OpeningTime, (SELECT bhe.EndTime FROM tblEndTime bhe WHERE bhe.EndTimeId = (SELECT bh.ClosingHours FROM tblBusinessHours bh WHERE bh.SalonsId = " + SalonId + " AND bh.Day = 'Monday')) AS ClosingTime, (SELECT sst.StartTime FROM tblStartTime sst WHERE sst.StartTimeId = se.StartTime AND se.SalonsId = " + SalonId + ") AS StartTime, (SELECT sse.EndTime FROM tblEndTime sse WHERE sse.EndTimeId = se.EndTime AND se.SalonsId = " + SalonId + ") AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime WHERE sc.SalonsId = " + SalonId + "", con);

        //        //MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, bh.Day,ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = bh.OpeningHours AND bh.SalonsId = 1) AS OpeningTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = bh.ClosingHours AND bh.SalonsId = 1) AS ClosingTime, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = se.StartTime AND se.SalonsId = 1) AS StartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = se.EndTime AND se.SalonsId = 1) AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime INNER JOIN tblBusinessHours bh ON bh.SalonsId = sc.SalonsId WHERE sc.SalonsId =" + SalonId + "", con);

        //        MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate, bh.Day, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = (SELECT OpeningHours FROM tblBusinessHours WHERE SalonsId = "+SalonId+ " AND Day = 'Monday')) AS OpeningTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = (SELECT ClosingHours FROM tblBusinessHours WHERE SalonsId = " + SalonId + " AND Day = 'Monday')) AS ClosingTime, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = se.StartTime) AS StartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = se.EndTime AND se.SalonsId = " + SalonId + ") AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime INNER JOIN tblBusinessHours bh ON bh.SalonsId = sc.SalonsId WHERE sc.SalonsId = " + SalonId + " AND bh.IsActive = 0", con);

        //        con.Open();
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        while(dr.Read())
        //        {
        //            objSchedular.Add(new Schedular
        //            {
        //                BookingDate=dr["BookingDate"].ToString(),
        //                BookingTime=dr["BookingTime"].ToString(),
        //                Service = dr["TreatmentTypeId"].ToString(),
        //                EmployeeName = dr["EmployeeName"].ToString(),
        //                EmployeeId = dr["SalonEmployeesId"].ToString(),
        //                Duration = dr["Duration"].ToString(),
        //                CleanUpTime = dr["CleanUpTime"].ToString(),
        //                StartDate = dr["StartDate"].ToString(),
        //                EndDate = dr["EndDate"].ToString(),
        //                OpeningTime = dr["OpeningTime"].ToString(),
        //                ClosingTime = dr["ClosingTime"].ToString(),
        //                StartTime = dr["StartTime"].ToString(),
        //                EndTime = dr["EndTime"].ToString(),
        //                Day = dr["Day"].ToString(),
        //                Message ="Success"
        //            });
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        objSchedular.Add(new Schedular
        //        {
        //            Message = "Fail"
        //        });
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return objSchedular;
        //}



        public IEnumerable<Schedular> GetEmployeeBookings(int SalonId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT  'Tuesday' AS Day,sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate, (SELECT bhs.StartTime FROM tblStartTime bhs WHERE bhs.StartTimeId = (SELECT bh.OpeningHours FROM tblBusinessHours bh WHERE bh.SalonsId = " + SalonId + " AND bh.Day = 'Monday')) AS OpeningTime, (SELECT bhe.EndTime FROM tblEndTime bhe WHERE bhe.EndTimeId = (SELECT bh.ClosingHours FROM tblBusinessHours bh WHERE bh.SalonsId = " + SalonId + " AND bh.Day = 'Monday')) AS ClosingTime, (SELECT sst.StartTime FROM tblStartTime sst WHERE sst.StartTimeId = se.StartTime AND se.SalonsId = " + SalonId + ") AS StartTime, (SELECT sse.EndTime FROM tblEndTime sse WHERE sse.EndTimeId = se.EndTime AND se.SalonsId = " + SalonId + ") AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime WHERE sc.SalonsId = " + SalonId + "", con);

                //MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, bh.Day,ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = bh.OpeningHours AND bh.SalonsId = 1) AS OpeningTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = bh.ClosingHours AND bh.SalonsId = 1) AS ClosingTime, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = se.StartTime AND se.SalonsId = 1) AS StartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = se.EndTime AND se.SalonsId = 1) AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime INNER JOIN tblBusinessHours bh ON bh.SalonsId = sc.SalonsId WHERE sc.SalonsId =" + SalonId + "", con);

                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT sc.BookingDate, sc.BookingTime, se.SalonEmployeesId, se.EmployeeName, ss.TreatmentTypeId, td.Duration, ct.CleanUpTime, se.StartDate, se.EndDate,  '0' AS OpeningTime, '0' AS ClosingTime, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = se.StartTime) AS StartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = se.EndTime AND se.SalonsId = " + SalonId + ") AS EndTime FROM tblSalonCheckout sc INNER JOIN tblEmployeeServices es ON es.EmployeeServicesId = sc.EmployeeServicesId INNER JOIN tblSalonEmployees se ON se.SalonEmployeesId = es.SalonEmployeesId AND se.SalonsId = sc.SalonsId INNER JOIN tblSalonServices ss ON ss.SalonServicesId = es.SalonServicesId INNER JOIN tblDuration td ON td.DurationId = ss.DurationId INNER JOIN tblCleanUpTime ct ON ct.CleanUpTimeId = ss.CleanUpTime WHERE sc.SalonsId = " + SalonId + " AND sc.IsActive not in (0,2) AND sc.BookingDate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objSchedular.Add(new Schedular
                    {
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        Service = dr["TreatmentTypeId"].ToString(),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        EmployeeId = dr["SalonEmployeesId"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        CleanUpTime = dr["CleanUpTime"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        OpeningTime = dr["OpeningTime"].ToString(),
                        ClosingTime = dr["ClosingTime"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        // Day = dr["Day"].ToString(),
                        Message = "Success"
                    });
                }
            }
            catch (Exception)
            {
                objSchedular.Add(new Schedular
                {
                    Message = "Fail"
                });
            }
            finally
            {
                con.Close();
            }
            return objSchedular;
        }

        public IEnumerable<Schedular> GetEmployeeServices(int EmployeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblEmployeeServices te INNER JOIN tblSalonServices ts ON ts.SalonServicesId = te.SalonServicesId WHERE te.SalonEmployeesId=" + EmployeeId + " and te.IsActive=1", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objSchedular.Add(new Schedular
                    {
                        //  BookingDate = dr["BookingDate"].ToString(),
                        //  BookingTime = dr["BookingTime"].ToString(),
                        Service = dr["TreatmentTypeId"].ToString(),
                        EmployeeServiceId = dr["EmployeeServicesId"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //   EmployeeId = dr["SalonEmployeesId"].ToString(),
                        //   Duration = dr["Duration"].ToString(),
                        //    CleanUpTime = dr["CleanUpTime"].ToString(),
                        //    StartDate = dr["StartDate"].ToString(),
                        //    EndDate = dr["EndDate"].ToString(),
                        //    OpeningTime = dr["OpeningTime"].ToString(),
                        //    ClosingTime = dr["ClosingTime"].ToString(),
                        //    StartTime = dr["StartTime"].ToString(),
                        //    EndTime = dr["EndTime"].ToString(),
                        //     Day = dr["Day"].ToString(),
                        Message = "Success"
                    });
                }
            }
            catch (Exception)
            {
                objSchedular.Add(new Schedular
                {
                    Message = "Fail"
                });
            }
            finally
            {
                con.Close();
            }
            return objSchedular;
        }


        public string updateEmployeeUnavaialble(string StartDate, string StartTime, string EndDate, string EndTime, int EmployeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonEmployees set StartDate='" + StartDate + "',StartTime='" + StartTime + "',EndDate='" + EndDate + "',EndTime='" + EndTime + "' where SalonEmployeesId=" + EmployeeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
            }
            finally
            {
                con.Close();
            }

        }

        public IEnumerable<Schedular> GetEmployeeServicesPrice(int ServiceId)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblEmployeeServices te INNER JOIN tblSalonServices ts ON ts.SalonServicesId = te.SalonServicesId inner join tblDuration td on td.DurationId=ts.DurationId WHERE te.EmployeeServicesId=" + ServiceId + "", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objSchedular.Add(new Schedular
                    {
                        //  BookingDate = dr["BookingDate"].ToString(),
                        SalonServicesId = dr["SalonServicesId"].ToString(),
                        Price = dr["Price"].ToString(),
                        //  EmployeeName = dr["EmployeeName"].ToString(),
                        //   EmployeeId = dr["SalonEmployeesId"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //    CleanUpTime = dr["CleanUpTime"].ToString(),
                        //    StartDate = dr["StartDate"].ToString(),
                        //    EndDate = dr["EndDate"].ToString(),
                        //    OpeningTime = dr["OpeningTime"].ToString(),
                        //    ClosingTime = dr["ClosingTime"].ToString(),
                        //    StartTime = dr["StartTime"].ToString(),
                        //    EndTime = dr["EndTime"].ToString(),
                        //     Day = dr["Day"].ToString(),
                        Message = "Success"
                    });
                }
            }
            catch (Exception)
            {
                objSchedular.Add(new Schedular
                {
                    Message = "Fail"
                });
            }
            finally
            {
                con.Close();
            }
            return objSchedular;
        }
    }





    public class SalonServicesClass
    {
        public int SalonServicesId { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Sale { get; set; }
        public int SalonsId { get; set; }
        public string Category { get; set; }
        public string TreatmentTitle { get; set; }
        public int CategoryId { get; set; }
        public string TreatmentTypeId { get; set; }
        public int TreatmentTitleId { get; set; }
        public int featuredServices { get; set; }
        public int PricingTypeId { get; set; }
        public int DurationId { get; set; }
        public int CleanUpTime { get; set; }
        public string CleanUpTime1 { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int EmployeeServicesId { get; set; }
        public string Session { get; set; }
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }
        public string MonDay { get; set; }
        public string TuesDay { get; set; }
        public string WednesDay { get; set; }
        public string ThursDay { get; set; }
        public string FriDay { get; set; }
        public string SaturDay { get; set; }
        public string SunDay { get; set; }
        public int DiscountId { get; internal set; }
        public string Duration { get; internal set; }
        public string ImagePath { get; internal set; }
        public string Favourite { get; internal set; }
        public string Rating { get; internal set; }
    }

    // schedluar class

    //public class Schedular
    //{
    //    public string BookingDate { get; set; }
    //    public string BookingTime { get; set; }
    //    public string Category { get; set; }
    //    public string Service { get; set; }
    //    public string EmployeeName { get; set; }
    //    public string Duration { get; set; }
    //    public string CleanUpTime { get; set; }
    //    public string Message { get; set; }
    //    public string EmployeeId { get; internal set; }
    //    public string StartDate { get; internal set; }
    //    public string EndDate { get; internal set; }
    //    public string OpeningTime { get; internal set; }
    //    public string ClosingTime { get; internal set; }
    //    public string StartTime { get; internal set; }
    //    public string EndTime { get; internal set; }
    //    public string Day { get; internal set; }
    //}
    public class Schedular
    {
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string Category { get; set; }
        public string Service { get; set; }
        public string EmployeeName { get; set; }
        public string Duration { get; set; }
        public string CleanUpTime { get; set; }
        public string Message { get; set; }
        public string EmployeeId { get; internal set; }
        public string StartDate { get; internal set; }
        public string EndDate { get; internal set; }
        public string OpeningTime { get; internal set; }
        public string ClosingTime { get; internal set; }
        public string StartTime { get; internal set; }
        public string EndTime { get; internal set; }
        public string Day { get; internal set; }
        public string EmployeeServiceId { get; internal set; }
        public string Price { get; internal set; }
        public string SalonServicesId { get; internal set; }
    }
}