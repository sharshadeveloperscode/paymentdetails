using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;
using System.Data;

namespace SalonAPI.Models
{
    public class MobileSalonDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonsDAL.tblSalons> objSalons = new List<SalonsDAL.tblSalons>();
        List<SalonEmployeesClass> objEmp = new List<SalonEmployeesClass>();
        List<SalonServicesClass> objSalSer = new List<SalonServicesClass>();

        public IEnumerable<SalonsDAL.tblSalons> GetActiveSalons(int? UserId = null)        
        {
            try
            {                
                MySqlCommand cmd = new MySqlCommand("SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Reviews FROM tblSalons s LEFT OUTER JOIN tblFavouriteSalons f ON s.SalonsId = f.SalonsId AND f.UserId = '" + UserId + "' WHERE s.IsActive = '1';", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objSalons.Add(new SalonsDAL.tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        BusinessType = Convert.ToInt32(dt.Rows[i]["BusinessType"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        ManageYourBookings = Convert.ToInt32(dt.Rows[i]["ManageYourBookings"]),
                        ReasonForSigningUp = Convert.ToInt32(dt.Rows[i]["ReasonForSigningUp"]),
                        BusinessName = dt.Rows[i]["BusinessName"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Website = dt.Rows[i]["Website"].ToString(),
                        GoogleMaps = dt.Rows[i]["GoogleMaps"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Reviews = dt.Rows[i]["Reviews"].ToString(),
                        Rating = dt.Rows[i]["Rating"].ToString(),
                        FavouriteId = dt.Rows[i]["FavId"].ToString(),
                        Popularity = dt.Rows[i]["Popularity"].ToString(),
                        //Limit = dt.Rows[i]["Limit"].ToString(),
                        Available = dt.Rows[i]["Available"].ToString(),
                        ClassId = dt.Rows[i]["ClassId"].ToString(),
                        Noofchairs = dt.Rows[i]["Noofchairs"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    objSalons.Add(new SalonsDAL.tblSalons { Message = "NoData" });
                    return objSalons;
                }
                return objSalons;
            }
            catch (Exception ex)
            {
                objSalons.Add(new SalonsDAL.tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return objSalons;
            }
        }     
        
        public IEnumerable<SalonsDAL.tblSalons> GetSalonsbyTreatmentTitle(int? TreatmentTitle=null, int? UserId=null)
        {
            try
            {
                var cond = "";
                if(TreatmentTitle != null)
                {
                    cond = "and tt.TreatmentTitleId = " + TreatmentTitle;
                }
                // SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Reviews, IFNULL((SELECT FavId FROM tblFavouriteSalons where SalonsId = s.SalonsId and UserId = 431),0) AS FavId FROM tblSalons s, tblSalonServices ss, tblCategory c, tblTreatmentTitle tt WHERE s.SalonsId = ss.SalonsId AND c.CategoryId = tt.CategoryId AND ss.TreatmentTitleId = tt.TreatmentTitleId AND s.IsActive = 1 AND ss.IsActive = 1 AND c.IsActive = 1 AND tt.IsActive = 1 GROUP BY s.BusinessName
                //select *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Reviews from tblSalons s, tblSalonServices ss, tblCategory c, tblTreatmentTitle tt where s.SalonsId = ss.SalonsId and c.CategoryId = tt.CategoryId and ss.TreatmentTitleId = tt.TreatmentTitleId and s.IsActive = 1 and ss.IsActive = 1 and c.IsActive = 1 and tt.IsActive = 1 " + cond + " group by s.BusinessName
                MySqlCommand cmd = new MySqlCommand("SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId), 0) AS Reviews, IFNULL((SELECT FavId FROM tblFavouriteSalons where SalonsId = s.SalonsId and UserId = " + UserId + "),0) AS FavId FROM tblSalons s, tblSalonServices ss, tblCategory c, tblTreatmentTitle tt WHERE s.SalonsId = ss.SalonsId AND c.CategoryId = tt.CategoryId AND ss.TreatmentTitleId = tt.TreatmentTitleId AND s.IsActive = 1 AND ss.IsActive = 1 AND c.IsActive = 1 AND tt.IsActive = 1 GROUP BY s.BusinessName", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objSalons.Add(new SalonsDAL.tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        BusinessType = Convert.ToInt32(dt.Rows[i]["BusinessType"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        ManageYourBookings = Convert.ToInt32(dt.Rows[i]["ManageYourBookings"]),
                        ReasonForSigningUp = Convert.ToInt32(dt.Rows[i]["ReasonForSigningUp"]),
                        BusinessName = dt.Rows[i]["BusinessName"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Website = dt.Rows[i]["Website"].ToString(),
                        GoogleMaps = dt.Rows[i]["GoogleMaps"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Reviews = dt.Rows[i]["Reviews"].ToString(),
                        Rating = dt.Rows[i]["Rating"].ToString(),
                        FavouriteId = dt.Rows[i]["FavId"].ToString(),
                        Popularity = dt.Rows[i]["Popularity"].ToString(),
                        //Limit = dt.Rows[i]["Limit"].ToString(),
                        Available = dt.Rows[i]["Available"].ToString(),
                        ClassId = dt.Rows[i]["ClassId"].ToString(),
                        Noofchairs = dt.Rows[i]["Noofchairs"].ToString(),
                        Message = "Success"
                    });
                }
                return objSalons;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    objSalons.Add(new SalonsDAL.tblSalons { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objSalons;
                }
                else
                {
                    objSalons.Add(new SalonsDAL.tblSalons { Message = "Error", ErrorMessage = ex.Message });
                    return objSalons;
                }

            }
            catch (Exception ex)
            {
                objSalons.Add(new SalonsDAL.tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return objSalons;
            }
            finally
            {
                con.Close();
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public IEnumerable<SalonServicesClass> GetDatabySalonsIdIsActive(int SalonsId, int UserId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("select ts.*, tsi.SalonsId, tc.CategoryId, tc.Category, tt.TreatmentTypeId, tt.IsActive, tti.IsActive, tc.IsActive, tt.TreatmentType, tti.TreatmentTitleId, tti.TreatmentTitle, d.DurationId from tblSalonServices ts, tblSalons tsi, tblCategory tc, tblTreatmentType tt, tblTreatmentTitle tti, tblDuration d where ts.SalonsId = tsi.SalonsId and ts.CategoryId = tc.CategoryId and ts.TreatmentTypeId = tt.TreatmentTypeId and ts.TreatmentTitleId = tti.TreatmentTitleId and ts.DurationId = d.DurationId and tt.IsActive=1 and tti.IsActive=1 and tc.IsActive=1 and ts.SalonsId = '" + SalonsId + "'", con);
                MySqlCommand cmd = new MySqlCommand(" select ss.*, c.Category, tt.TreatmentTitle, d.Duration, IFNULL((SELECT fss.FavId FROM tblFavouriteSalonService fss where fss.SalonServicesId = ss.SalonServicesId and fss.UserId = "+ UserId +"), 0) AS FavId from tblSalonServices ss, tblCategory c, tblTreatmentTitle tt, tblDuration d WHERE ss.CategoryId = c.CategoryId AND ss.TreatmentTitleId = tt.TreatmentTitleId AND ss.DurationId = d.DurationId AND ss.IsActive = 1 AND c.IsActive = 1 AND tt.IsActive = 1 AND d.IsActive = 1 AND ss.SalonsId = "+ SalonsId, con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objSalSer.Add(new SalonServicesClass
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
                        Favourite = dr["FavId"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    objSalSer.Add(new SalonServicesClass
                    {
                        Message = "NoData"
                    });
                    return objSalSer;
                }
                return objSalSer;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    objSalSer.Add(new SalonServicesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return objSalSer;
                }
                else
                {
                    objSalSer.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                    return objSalSer;
                }

            }
            catch (Exception ex)
            {
                objSalSer.Add(new SalonServicesClass { Message = "Error", ErrorMessage = ex.Message });
                return objSalSer;
            }
            finally
            {
                con.Close();
            }
        }
    }
}