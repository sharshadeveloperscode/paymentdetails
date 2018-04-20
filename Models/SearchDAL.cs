using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;

namespace SalonAPI.Models
{
    public class SearchDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SearchClass> obj = new List<SearchClass>();
        public IEnumerable<SearchClass> Search(string PostCode, string TreatmentTitleId, string CheckDate)
        {
            try
            {
                if (PostCode != null || TreatmentTitleId != null || CheckDate != null)
                {
                    string CurDate = "";
                    if (CheckDate != null)
                    {
                        CurDate = CheckDate;
                    }
                    else
                    {
                        CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");
                    }


                    //   string time = DateTime.Now.ToString("HH:mm");
                    //  if (x >= 00:00 && x <= 12:00)

                    //if (time >= '00:00' && time <= '12:00')
                    {

                    }
                    //string session = "Morning";
                    //DateTime mytime = DateTime.Now;
                    //DateTime dt1 = Convert.ToDateTime("00:00");
                    //DateTime dt2 = Convert.ToDateTime("12:00");
                    //if(mytime >= dt1 && mytime <= dt2)
                    //{

                    //}
                    string session = "";
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }


                    //   string session = "Morning";
                    //MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblTreatmentType ttt WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1  AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND ss.TreatmentTypeId = ttt.TreatmentTypeId AND tt.TreatmentTitleId = ttt.TreatmentTitleId AND ttt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId like '" + TreatmentTitleId + "%' AND a.AreaId like '" + AreaId + "%' AND bh.Day = DAYNAME('" + CurDate + "') order by s.SalonsId", con);
                    //MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices=1 AND tt.TreatmentTitleId LIKE '" + TreatmentTitleId + "%' AND a.PostCode LIKE '" + PostCode + "%' AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId", con);
                    //con.Open();
                    //MySqlCommand cmd = new MySqlCommand(@"SELECT *, CASE WHEN B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 ELSE A.price END AS MonPrice, CASE WHEN B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 ELSE A.price END AS TuePrice, CASE WHEN B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 ELSE A.price END AS WedPrice, CASE WHEN B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 ELSE A.price END AS ThuPrice, CASE WHEN B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 ELSE A.price END AS FriPrice, CASE WHEN B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 ELSE A.price END AS SatPrice, CASE WHEN B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS SunPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId, ss.CategoryId, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices = 1 AND tt.TreatmentTitleId LIKE '%' AND a.PostCode LIKE '%' AND bh.Day = DAYNAME('2017-06-21') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = 'Morning') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId ORDER BY A.SalonsId , A.CategoryId", con);

                    //MySqlCommand cmd = new MySqlCommand(@"SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId, ss.CategoryId, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price,ss.Sale, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices = 1 AND ss.IsActive=1 AND tt.TreatmentTitleId LIKE '" + TreatmentTitleId+ "%' AND s.PostalCode LIKE '" + PostCode+"%' AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN(SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId, A.CategoryId", con);

                    MySqlCommand cmd = new MySqlCommand(@"SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId,ss.featuredServices, s.BusinessName, ss.SalonsId, ss.CategoryId, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price,ss.Sale, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId  AND ss.IsActive=1 AND tt.TreatmentTitleId LIKE '" + TreatmentTitleId + "%' AND s.PostalCode LIKE '" + PostCode + "%' AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN(SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId,A.featuredServices desc", con); // A.CategoryId,
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        SearchDAL comment = new SearchDAL();
                        obj.Add(new SearchClass
                        {

                            AreaId = Convert.ToInt32(dr["AreaId"]),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            BusinessName = dr["BusinessName"].ToString(),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            PostalCode = dr["PostalCode"].ToString(),
                            // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                            Note = dr["Note"].ToString(),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            DurationId = Convert.ToInt32(dr["DurationId"]),
                            UserId = Convert.ToInt32(dr["UserId"]),
                            MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                            //CountryId = Convert.ToInt32(dr["CountryId"]),
                            SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                            CityId = Convert.ToInt32(dr["CityId"]),
                            AreaName = dr["AreaName"].ToString(),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CityName = dr["CityName"].ToString(),
                            Image = dr["Image"].ToString(),
                            ImagePath = dr["ImagePath"].ToString(),
                            Description = dr["Description"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            featuredServices = dr["featuredServices"].ToString(),
                            //  Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList()
                            //  Salonrating = comment.Salonrating(Convert.ToInt32(dr["SalonsId"])).ToList();
                            Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                            Message = "Success"
                        });
                    }
                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                    return obj;
                }
                else
                {
                    string CurDate = "";
                    CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");


                    string session = "";
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }


                    //  string time = DateTime.Now.ToString("HH:mm");
                    // string session = "Morning";
                    //MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM tblSalonServices ss, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.DurationId = td.DurationId AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND s.IsActive = 1 AND c.IsActive = 1 AND a.IsActive = 1 AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId LIKE '%' AND s.PostalCode LIKE 'RM8 1TE%' AND ss.featuredServices=1 ORDER BY s.SalonsId", con);


                    MySqlCommand cmd = new MySqlCommand(@"SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId,ss.featuredServices, s.BusinessName, ss.SalonsId, ss.CategoryId,tt.TreatmentTitle, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price,ss.Sale, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId and s.AreaId=(select distinct AreaId from tblArea where AreaName='Central London' or AreaName='CentralLondon' or AreaName='Centrallondon' or AreaName='centrallondon' limit 1) AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices = 1 AND ss.IsActive=1 AND tt.TreatmentTitleId LIKE '%'  AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN(SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId, A.featuredServices desc", con); //A.CategoryId,
                    //AND s.PostalCode LIKE 'SE1 2AP'
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        SearchDAL comment = new SearchDAL();
                        obj.Add(new SearchClass
                        {
                            AreaId = Convert.ToInt32(dr["AreaId"]),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            BusinessName = dr["BusinessName"].ToString(),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            // Category = dr["Category"].ToString(),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            TreatmentTitle = dr["TreatmentTitle"].ToString(),
                            // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            Note = dr["Note"].ToString(),
                            PostalCode = dr["PostalCode"].ToString(),
                            // DurationId = Convert.ToInt32(dr["DurationId"]),
                            // UserId = Convert.ToInt32(dr["UserId"]),
                            MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                            //CountryId = Convert.ToInt32(dr["CountryId"]),
                            SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                            CityId = Convert.ToInt32(dr["CityId"]),
                            AreaName = dr["AreaName"].ToString(),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CityName = dr["CityName"].ToString(),
                            Image = dr["Image"].ToString(),
                            ImagePath = dr["ImagePath"].ToString(),
                            Description = dr["Description"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            featuredServices = dr["featuredServices"].ToString(),
                            //MonDay = dr["MonDay"].ToString(),
                            //TuesDay = dr["TuesDay"].ToString(),
                            //WednesDay = dr["WednesDay"].ToString(),
                            //ThursDay = dr["ThursDay"].ToString(),
                            //FriDay = dr["FriDay"].ToString(),
                            //SaturDay = dr["SaturDay"].ToString(),
                            //SunDay = dr["SunDay"].ToString(),
                            Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                            Message = "Success",
                        });
                    }
                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                    return obj;
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> SearchBasedonSalonName(string BusinessName)
        {
            try
            {

                string CurDate = "";
                CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");


                string session = "";
                DateTime mytime = DateTime.Now.AddMinutes(750);
                DateTime dt1 = DateTime.Parse("00:00:00 AM");
                DateTime dt2 = DateTime.Parse("11:59:59 AM");
                DateTime dt3 = DateTime.Parse("12:00:00 PM");
                DateTime dt4 = DateTime.Parse("04:59:59 PM");
                DateTime dt5 = DateTime.Parse("05:00:00 PM");
                DateTime dt6 = DateTime.Parse("11:59:59 PM");

                if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                {
                    session = "Morning";
                }
                if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                {
                    session = "AfterNoon";
                }
                if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                {
                    session = "Evening";
                }
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices ss, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.DurationId = td.DurationId AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND s.IsActive = 1 AND c.IsActive = 1 AND a.IsActive = 1 AND ss.featuredServices=1 AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId LIKE '%' AND a.AreaId LIKE '%' AND s.BusinessName LIKE '%" + BusinessName + "%' ORDER BY s.SalonsId", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId, ss.CategoryId, tt.TreatmentTitle, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price,ss.Sale, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND ss.IsActive=1 AND s.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices = 1 AND tt.TreatmentTitleId LIKE '%' AND a.AreaId LIKE '%' AND s.BusinessName='" + BusinessName + "' AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId , A.CategoryId", con);
                //SELECT *, ts.IsActive = 1 FROM tblSalons ts WHERE ts.BusinessName LIKE '%%'
                // MySqlCommand cmd = new MySqlCommand(" SELECT *  FROM tblSalons ts WHERE ts.IsActive = '1' and ts.BusinessName LIKE '%" + BusinessName + "%'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SearchDAL comment = new SearchDAL();
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        PostalCode = dr["PostalCode"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Note = dr["Note"].ToString(),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        DiscountPrice = dr["DiscountPrice"].ToString(),
                        SessionStart = dr["SessionStart"].ToString(),
                        SessionEnd = dr["SessionEnd"].ToString(),
                        Message = "Success",
                        Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }
            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> SearchBasedonCategoryId(int CategoryId)
        {
            try
            {
                string CurDate = "";
                CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");


                string session = "";
                DateTime mytime = DateTime.Now.AddMinutes(750);
                DateTime dt1 = DateTime.Parse("00:00:00 AM");
                DateTime dt2 = DateTime.Parse("11:59:59 AM");
                DateTime dt3 = DateTime.Parse("12:00:00 PM");
                DateTime dt4 = DateTime.Parse("04:59:59 PM");
                DateTime dt5 = DateTime.Parse("05:00:00 PM");
                DateTime dt6 = DateTime.Parse("11:59:59 PM");

                if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                {
                    session = "Morning";
                }
                if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                {
                    session = "AfterNoon";
                }
                if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                {
                    session = "Evening";
                }
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices ss, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblCategory tc WHERE ss.DurationId = td.DurationId AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND s.IsActive = 1 AND c.IsActive = 1 AND a.IsActive = 1 AND tt.TreatmentTitleId = ss.TreatmentTitleId AND ss.featuredServices = 1 AND tc.CategoryId=ss.CategoryId  AND tc.CategoryId='"+ CategoryId + "' ORDER BY s.SalonsId", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId,  tt.TreatmentTitle, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description,ss.Sale, tc.CategoryId FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td,tblCategory tc WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.IsActive = 1 AND  ss.IsActive=1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tc.CategoryId = ss.CategoryId AND ss.featuredServices = 1 AND tc.CategoryId = '" + CategoryId + "' AND bh.Day = DAYNAME('" + CurDate + "') ORDER BY s.SalonsId) AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId , A.CategoryId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SearchDAL comment = new SearchDAL();
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        Note = dr["Note"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        // UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        DiscountPrice = dr["DiscountPrice"].ToString(),
                        SessionStart = dr["SessionStart"].ToString(),
                        SessionEnd = dr["SessionEnd"].ToString(),
                        Message = "Success",
                        Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> SearchBasedonCityId(int CityId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices ss, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblTreatmentType ttt WHERE ss.DurationId = td.DurationId AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND s.IsActive = 1 AND c.IsActive = 1 AND a.IsActive = 1 AND ss.TreatmentTypeId = ttt.TreatmentTypeId AND tt.TreatmentTitleId = ttt.TreatmentTitleId AND ttt.TreatmentTitleId = ss.TreatmentTitleId AND c.CityId='" + CityId + "' ORDER BY s.SalonsId", con);
                //SELECT *, ts.IsActive = 1 FROM tblSalons ts WHERE ts.BusinessName LIKE '%%'
                // MySqlCommand cmd = new MySqlCommand(" SELECT *  FROM tblSalons ts WHERE ts.IsActive = '1' and ts.BusinessName LIKE '%" + BusinessName + "%'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SearchDAL comment = new SearchDAL();
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        //  TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Note = dr["Note"].ToString(),
                        Price = dr["Price"].ToString(),

                        Duration = dr["Duration"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        Sale = dr["Sale"].ToString(),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        //  ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        Message = "Success",
                        Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SearchClass> FilterSearch(int limit, string PriceRange, string Order, string StartTime, string EndTime, string StartPrice, string EndPrices, string Day, string AreaId, string TreatmentTitleId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblTreatmentType ttt WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1 AND ss.TreatmentTypeId = ttt.TreatmentTypeId AND tt.TreatmentTitleId = ttt.TreatmentTitleId AND ttt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId in (" + TreatmentTitleId + ") AND a.AreaId in (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ss.Price between " + StartPrice + " and " + EndPrices + " AND " + EndTime + " >=(SELECT StartTime FROM tblStartTime WHERE StartTimeId = bh.OpeningHours) AND " + StartTime + " <= (SELECT EndTime FROM tblEndTime WHERE EndTimeId = bh.ClosingHours) ORDER BY ss.Price " + PriceRange + " limit " + limit + "", con);
                //MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblTreatmentType ttt WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1 AND ss.TreatmentTypeId = ttt.TreatmentTypeId AND tt.TreatmentTitleId = ttt.TreatmentTitleId AND ttt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId in (" + TreatmentTitleId + ") AND a.AreaId in (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ss.Price between " + StartPrice + " and " + EndPrices + " ORDER BY " + PriceRange + " limit " + limit + "", con);
                //MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td, tblTreatmentType ttt WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1  AND ss.featuredServices=1   AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId in (" + TreatmentTitleId + ") AND a.AreaId in (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ss.Price between " + StartPrice + " and " + EndPrices + "  AND((bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours >= " + StartTime + " AND bh.ClosingHours <= " + EndTime + ") OR (bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours >= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours <= " + EndTime + ")) ORDER BY " + PriceRange + " " + Order + " limit " + limit + "", con);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1  AND ss.featuredServices=1   AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId in (" + TreatmentTitleId + ") AND a.AreaId in (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ss.Price between " + StartPrice + " and " + EndPrices + "  AND((bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours >= " + StartTime + " AND bh.ClosingHours <= " + EndTime + ") OR (bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours >= " + StartTime + " AND bh.ClosingHours >= " + EndTime + ") OR (bh.OpeningHours <= " + StartTime + " AND bh.ClosingHours <= " + EndTime + ")) ORDER BY ss.SalonsId, " + PriceRange + " " + Order + " limit " + limit + "", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        //   TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        Note = dr["Note"].ToString(),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        // UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SearchClass> NewFilterSearch(int limit, string PriceRange, string Order, string StartTime, string EndTime, string Day, string AreaId, string TreatmentTitleId, string StartPrice, string EndPrice)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalons s, tblBusinessHours bh, tblArea a WHERE s.SalonsId = bh.SalonsId AND s.SalonsId IN(SELECT ss.SalonsId FROM tblSalonServices ss WHERE ss.IsActive = 1 AND ss.TreatmentTitleId IN (" + TreatmentTitleId + ") AND ss.Price between " + StartPrice + " and " + EndPrice + " AND ss.featuredServices = 1)  AND s.AreaId = a.AreaId AND s.IsActive = 1 AND bh.IsActive = 1 AND a.IsActive = 1 AND a.AreaId IN (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ((bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "' AND bh.OpeningHours < '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "' AND bh.ClosingHours > '" + StartTime + "')) LIMIT " + limit + "", con);
                //string CurDate = "";
                //CurDate = DateTime.Now.AddHours(12).ToString("yyyy-MM-dd");


                //string session = "";
                //DateTime mytime = DateTime.Now.AddHours(12);
                //DateTime dt1 = DateTime.Parse("00:00:00 AM");
                //DateTime dt2 = DateTime.Parse("11:59:59 AM");
                //DateTime dt3 = DateTime.Parse("12:00:00 PM");
                //DateTime dt4 = DateTime.Parse("04:59:59 PM");
                //DateTime dt5 = DateTime.Parse("05:00:00 PM");
                //DateTime dt6 = DateTime.Parse("11:59:59 PM");

                //if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                //{
                //    session = "Morning";
                //}
                //if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                //{
                //    session = "AfterNoon";
                //}
                //if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                //{
                //    session = "Evening";
                //}

                //MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('"+CurDate+ "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId, ss.CategoryId, tt.TreatmentTitle, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1 AND ss.featuredServices = 1 AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId IN ("+TreatmentTitleId+") AND a.AreaId IN ("+AreaId+ ") AND bh.Day = DAYNAME('" + CurDate + "') AND ss.Price BETWEEN 0 AND 1000 AND ((bh.OpeningHours <= '1' AND bh.ClosingHours >= '48') OR (bh.OpeningHours >= '1' AND bh.ClosingHours <= '48') OR (bh.OpeningHours <= '1' AND bh.ClosingHours >= '48') OR (bh.OpeningHours >= '1' AND bh.ClosingHours >= '48' AND bh.OpeningHours < '48') OR (bh.OpeningHours <= '1' AND bh.ClosingHours<= '48' AND bh.ClosingHours > '1')) ORDER BY ss.SalonsId, Price DESC LIMIT 1000) AS A Left OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = 'Morning') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId ORDER BY A.SalonsId , A.CategoryId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SearchDAL comment = new SearchDAL();
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        // SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        // CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        // TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        //   TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        // TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        // TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //  Price = dr["Price"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        Note = dr["Note"].ToString(),


                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        // UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        // Description = dr["Description"].ToString(),
                        Message = "Success",
                        Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> NewFilterTreatmentType(int SalonsId, string StartPrice, string TreatmentTitleId, string EndPrices)
        {
            try
            {
                string CurDate = "";
                CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");


                string session = "";
                DateTime mytime = DateTime.Now.AddMinutes(750);
                DateTime dt1 = DateTime.Parse("00:00:00 AM");
                DateTime dt2 = DateTime.Parse("11:59:59 AM");
                DateTime dt3 = DateTime.Parse("12:00:00 PM");
                DateTime dt4 = DateTime.Parse("04:59:59 PM");
                DateTime dt5 = DateTime.Parse("05:00:00 PM");
                DateTime dt6 = DateTime.Parse("11:59:59 PM");

                if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                {
                    session = "Morning";
                }
                if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                {
                    session = "AfterNoon";
                }
                if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                {
                    session = "Evening";
                }


                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td  WHERE  tss.IsActive = 1 AND td.IsActive = 1 AND ttt.IsActive = 1 AND tss.DurationId = td.DurationId  AND ttt.TreatmentTitleId = tss.TreatmentTitleId AND ttt.TreatmentTitleId in ("+ TreatmentTitleId + ") AND tss.SalonsId = '" + SalonsId+ "' AND tss.featuredServices = 1  AND tss.Price between "+StartPrice+" AND "+EndPrices+" ORDER BY tss.Price ", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT tss.SalonServicesId, tss.SalonsId, tss.CategoryId, ttt.TreatmentTitle, tss.TreatmentTypeId, tss.TreatmentTitleId, tss.PricingTypeId, tss.Price,tss.Sale, td.Duration, td.DurationId, tss.CreatedBy, tss.CreatedDate, tss.Description FROM tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td WHERE tss.IsActive = 1 AND td.IsActive = 1 AND ttt.IsActive = 1 AND tss.DurationId = td.DurationId AND ttt.TreatmentTitleId = tss.TreatmentTitleId AND ttt.TreatmentTitleId IN (" + TreatmentTitleId + ") AND tss.SalonsId = '" + SalonsId + "' AND tss.featuredServices = 1 AND tss.Price BETWEEN " + StartPrice + " AND " + EndPrices + " ORDER BY tss.Price) AS A Left OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId  ORDER BY A.SalonsId , A.CategoryId", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        Duration = dr["Duration"].ToString(),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        DiscountPrice = dr["DiscountPrice"].ToString(),
                        SessionStart = dr["SessionStart"].ToString(),
                        SessionEnd = dr["SessionEnd"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<SearchClass> NewFilterSearch1(int limit, string PriceRange, string Order, string StartTime, string EndTime, string Day, string AreaId, string TreatmentTitleId, string StartPrice, string EndPrice)
        {
            try
            {
                /// if (Day != null)
                // {
                //  Day = Day;
                // DateTime date = DateTime.ParseExact(Day, "dd/MM/yyyy",
                //    CultureInfo.InvariantCulture);
                //   Day = date.ToString("yyyy-MM-dd");
                //  }
                //  else
                // {
                Day = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");
                // }



                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalons s, tblBusinessHours bh, tblArea a WHERE s.SalonsId = bh.SalonsId AND s.SalonsId IN(SELECT ss.SalonsId FROM tblSalonServices ss WHERE ss.IsActive = 1 AND ss.TreatmentTitleId IN (" + TreatmentTitleId + ")  AND ss.featuredServices = 1 AND ((ss.Price between " + StartPrice + " and " + EndPrice + " ) or (ss.Sale between " + StartPrice + " and " + EndPrice + " )))  AND s.AreaId = a.AreaId AND s.IsActive = 1 AND bh.IsActive = 1 AND a.IsActive = 1 AND a.AreaId IN (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ((bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "' AND bh.OpeningHours < '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "' AND bh.ClosingHours > '" + StartTime + "')) LIMIT " + limit + "", con);



                //group by A.SalonServicesId


                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalons s, tblBusinessHours bh, tblArea a WHERE s.SalonsId = bh.SalonsId AND s.SalonsId IN(SELECT ss.SalonsId FROM tblSalonServices ss WHERE ss.IsActive = 1 AND ss.TreatmentTitleId IN (" + TreatmentTitleId + ") AND ss.Price between " + StartPrice + " and " + EndPrice + " AND ss.featuredServices = 1)  AND s.AreaId = a.AreaId AND s.IsActive = 1 AND bh.IsActive = 1 AND a.IsActive = 1 AND a.AreaId IN (" + AreaId + ") AND bh.Day = DAYNAME('" + Day + "') AND ((bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "') OR (bh.OpeningHours >= '" + StartTime + "' AND bh.ClosingHours >= '" + EndTime + "' AND bh.OpeningHours < '" + EndTime + "') OR (bh.OpeningHours <= '" + StartTime + "' AND bh.ClosingHours <= '" + EndTime + "' AND bh.ClosingHours > '" + StartTime + "')) LIMIT " + limit + " group by ss.SalonServicesId", con);



                //string CurDate = "";
                //CurDate = DateTime.Now.AddHours(12).ToString("yyyy-MM-dd");


                //string session = "";
                //DateTime mytime = DateTime.Now.AddHours(12);
                //DateTime dt1 = DateTime.Parse("00:00:00 AM");
                //DateTime dt2 = DateTime.Parse("11:59:59 AM");
                //DateTime dt3 = DateTime.Parse("12:00:00 PM");
                //DateTime dt4 = DateTime.Parse("04:59:59 PM");
                //DateTime dt5 = DateTime.Parse("05:00:00 PM");
                //DateTime dt6 = DateTime.Parse("11:59:59 PM");

                //if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                //{
                //    session = "Morning";
                //}
                //if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                //{
                //    session = "AfterNoon";
                //}
                //if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                //{
                //    session = "Evening";
                //}

                //MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('"+CurDate+ "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT a.AreaId, ss.SalonServicesId, s.BusinessName, ss.SalonsId, ss.CategoryId, tt.TreatmentTitle, ss.TreatmentTypeId, s.PostalCode, ss.TreatmentTitleId, ss.PricingTypeId, s.Note, ss.Price, td.Duration, td.DurationId, s.UserId, s.MemberTypeId, s.SalonsUniqueId, c.CityId, a.AreaName, s.IsActive, ss.CreatedBy, ss.CreatedDate, c.CityName, s.Image, s.ImagePath, ss.Description FROM tblSalonServices ss, tblBusinessHours bh, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.SalonsId = bh.SalonsId AND ss.DurationId = td.DurationId AND bh.IsActive = 1 AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND a.AreaId = s.AreaId AND s.IsActive = 1 AND ss.featuredServices = 1 AND tt.TreatmentTitleId = ss.TreatmentTitleId AND tt.TreatmentTitleId IN ("+TreatmentTitleId+") AND a.AreaId IN ("+AreaId+ ") AND bh.Day = DAYNAME('" + CurDate + "') AND ss.Price BETWEEN 0 AND 1000 AND ((bh.OpeningHours <= '1' AND bh.ClosingHours >= '48') OR (bh.OpeningHours >= '1' AND bh.ClosingHours <= '48') OR (bh.OpeningHours <= '1' AND bh.ClosingHours >= '48') OR (bh.OpeningHours >= '1' AND bh.ClosingHours >= '48' AND bh.OpeningHours < '48') OR (bh.OpeningHours <= '1' AND bh.ClosingHours<= '48' AND bh.ClosingHours > '1')) ORDER BY ss.SalonsId, Price DESC LIMIT 1000) AS A Left OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = 'Morning') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId ORDER BY A.SalonsId , A.CategoryId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SearchDAL comment = new SearchDAL();
                    SearchDAL com = new SearchDAL();
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        // SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        // CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        // TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        //   TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        // TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        // TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //  Price = dr["Price"].ToString(),
                        // Duration = dr["Duration"].ToString(),
                        Note = dr["Note"].ToString(),


                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        // UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        //  CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        // Description = dr["Description"].ToString(),
                        Message = "Success",
                        Salonrating = comment.SalonRating(Convert.ToInt32(dr["SalonsId"])).ToList(),
                        filter = com.NewFilterTreatmentType1(Convert.ToInt32(dr["SalonsId"]), StartPrice, TreatmentTitleId, EndPrice).ToList()
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }
            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> NewFilterTreatmentType1(int SalonsId, string StartPrice, string TreatmentTitleId, string EndPrices)
        {
            try
            {
                string CurDate = "";
                CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");


                string session = "";
                DateTime mytime = DateTime.Now.AddMinutes(750);
                DateTime dt1 = DateTime.Parse("00:00:00 AM");
                DateTime dt2 = DateTime.Parse("11:59:59 AM");
                DateTime dt3 = DateTime.Parse("12:00:00 PM");
                DateTime dt4 = DateTime.Parse("04:59:59 PM");
                DateTime dt5 = DateTime.Parse("05:00:00 PM");
                DateTime dt6 = DateTime.Parse("11:59:59 PM");

                if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                {
                    session = "Morning";
                }
                if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                {
                    session = "AfterNoon";
                }
                if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                {
                    session = "Evening";
                }


                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td  WHERE  tss.IsActive = 1 AND td.IsActive = 1 AND ttt.IsActive = 1 AND tss.DurationId = td.DurationId  AND ttt.TreatmentTitleId = tss.TreatmentTitleId AND ttt.TreatmentTitleId in ("+ TreatmentTitleId + ") AND tss.SalonsId = '" + SalonsId+ "' AND tss.featuredServices = 1  AND tss.Price between "+StartPrice+" AND "+EndPrices+" ORDER BY tss.Price ", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT tss.SalonServicesId, tss.SalonsId, tss.CategoryId, ttt.TreatmentTitle, tss.TreatmentTypeId, tss.TreatmentTitleId, tss.PricingTypeId, tss.Price,tss.Sale, td.Duration, td.DurationId, tss.CreatedBy, tss.CreatedDate, tss.Description FROM tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td WHERE tss.IsActive = 1 AND td.IsActive = 1 AND ttt.IsActive = 1 AND tss.DurationId = td.DurationId AND ttt.TreatmentTitleId = tss.TreatmentTitleId AND ttt.TreatmentTitleId IN (" + TreatmentTitleId + ") AND tss.SalonsId = '" + SalonsId + "' AND tss.featuredServices = 1 AND ((tss.Price BETWEEN " + StartPrice + " AND " + EndPrices + ") or (tss.Sale BETWEEN " + StartPrice + " AND " + EndPrices + ") AND (tss.Sale!='null' AND tss.Sale!=0 AND tss.Sale!='')) ORDER BY tss.Price) AS A Left OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId , A.CategoryId", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        Duration = dr["Duration"].ToString(),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        DiscountPrice = dr["DiscountPrice"].ToString(),
                        SessionStart = dr["SessionStart"].ToString(),
                        SessionEnd = dr["SessionEnd"].ToString(),
                        Message = "Success",
                    });
                }
                //if (!dr.HasRows)
                //{
                //    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }














        public IEnumerable<SearchClass> SearchWithempty()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalons s, tblSalonServices ss ,tblCity c, tblArea a  WHERE s.SalonsId = ss.SalonsId  AND c.CityId = s.CityId  AND a.CityId = c.CityId  ORDER BY s.SalonsId ;", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentType = dr["TreatmentType"].ToString(),
                        //  TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        // TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Price = dr["Price"].ToString(),
                        Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> ViewSalonDetails(string SalonsId, string CheckDate)
        {
            try
            {

                if (SalonsId != null || CheckDate != null)
                {
                    string CurDate = "";
                    if (CheckDate != null)
                    {
                        CurDate = CheckDate;
                    }
                    else
                    {
                        CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");
                    }
                    string session = "";
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }


                    //MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblSalons ts, tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td, tblCategory tc, tblCity tct, tblArea ta WHERE ts.SalonsId = tss.SalonsId AND tss.DurationId = td.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tss.IsActive=1 AND tss.CategoryId = tc.CategoryId AND ts.CityId = tct.CityId AND ts.AreaId = ta.AreaId AND ts.SalonsId = '" + SalonsId + "'", con);

                    MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT ta.AreaId, tss.SalonServicesId, ts.BusinessName, tss.SalonsId, tss.CategoryId, ttt.TreatmentTitle, tss.TreatmentTypeId,tss.Sale, ts.PostalCode, tss.TreatmentTitleId, tss.PricingTypeId, ts.Note, tss.Price, td.Duration, td.DurationId,tc.Category,ts.CountryId, ts.UserId, ts.MemberTypeId, ts.SalonsUniqueId, tct.CityId, ta.AreaName, ts.IsActive, tss.CreatedBy, tss.CreatedDate, tct.CityName, ts.Image, ts.ImagePath, tss.Description FROM tblSalons ts, tblSalonServices tss, tblTreatmentTitle ttt, tblDuration td, tblCategory tc, tblCity tct, tblArea ta WHERE ts.SalonsId = tss.SalonsId AND tss.DurationId = td.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tss.IsActive = 1 AND tss.CategoryId = tc.CategoryId AND ts.CityId = tct.CityId AND ts.AreaId = ta.AreaId AND ts.SalonsId = '" + SalonsId + "') AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId group by A.SalonServicesId ORDER BY A.SalonsId , A.CategoryId", con);
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new SearchClass
                        {
                            AreaId = Convert.ToInt32(dr["AreaId"]),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            Category = dr["Category"].ToString(),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            TreatmentTitle = dr["TreatmentTitle"].ToString(),
                            PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            DurationId = Convert.ToInt32(dr["DurationId"]),
                            Note = dr["Note"].ToString(),
                            PostalCode = dr["PostalCode"].ToString(),
                            //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                            CountryId = Convert.ToInt32(dr["CountryId"]),
                            //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                            CityId = Convert.ToInt32(dr["CityId"]),
                            AreaName = dr["AreaName"].ToString(),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            //CreatedDate = dr["CreatedDate"].ToString(),

                            CityName = dr["CityName"].ToString(),
                            BusinessName = dr["BusinessName"].ToString(),
                            Image = dr["Image"].ToString(),
                            ImagePath = dr["ImagePath"].ToString(),
                            Description = dr["Description"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            Message = "Success",
                        });
                    }
                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                    return obj;
                }
                return obj;

            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> ViewSalonImages(string SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *,ts.Image as SalontableImage, ts.ImagePath as SalontableImagePath, tsi.Image as salonImagetableImage, tsi.ImagePath as SalonImagetableImagePath FROM tblSalons ts LEFT OUTER JOIN tblSalonImage tsi ON ts.SalonsId = tsi.SalonsId WHERE ts.SalonsId ='" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        //  AreaId = Convert.ToInt32(dr["AreaId"]),
                        //  SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        // CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        //  Category = dr["Category"].ToString(),
                        //  TreatmentType = dr["TreatmentType"].ToString(),
                        // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        // TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        // TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        //  PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // Price = dr["Price"].ToString(),
                        //  Duration = dr["Duration"].ToString(),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        // Note = dr["Note"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //   CityId = Convert.ToInt32(dr["CityId"]),
                        //  AreaName = dr["AreaName"].ToString(),
                        // IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        // CityName = dr["CityName"].ToString(),

                        Email = dr["Email"].ToString(),
                        Name = dr["Name"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        BusinessName = dr["BusinessName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        salonImagetableImage = dr["salonImagetableImage"].ToString(),
                        SalonImagetableImagePath = dr["SalonImagetableImagePath"].ToString(),
                        SalontableImagePath = dr["SalontableImagePath"].ToString(),
                        SalontableImage = dr["SalontableImage"].ToString(),
                        // Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> ViewBookingDetails(string SalonsId, string SalonServicesId, string CheckDate)
        {
            try
            {

                if (SalonsId != null || SalonServicesId != null || CheckDate != null)
                {
                    string CurDate = "";
                    if (CheckDate != null)
                    {
                        CurDate = CheckDate;
                    }
                    else
                    {
                        CurDate = DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd");

                        // CurDate = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    string session = "";                    
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    //  DateTime mytime = DateTime.Now;
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }

                    //MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices tss, tblSalons ts, tblTreatmentTitle ttt, tblDuration td, tblCategory tc WHERE tss.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tss.CategoryId = tc.CategoryId AND ts.SalonsId = '" + SalonsId + "' AND tss.SalonServicesId = '" + SalonServicesId + "'", con);
                    MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + CurDate + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + CurDate + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT tss.SalonServicesId, ts.BusinessName, tss.SalonsId, tss.CategoryId, ttt.TreatmentTitle, tss.TreatmentTypeId, ts.PostalCode, tss.TreatmentTitleId, tss.PricingTypeId, ts.Note, tss.Price, td.Duration, td.DurationId, ts.UserId, ts.MemberTypeId,tss.Sale, ts.SalonsUniqueId, ts.IsActive, tss.CreatedBy, tss.CreatedDate, ts.Image, ts.ImagePath,tc.Category, tss.Description FROM tblSalonServices tss, tblSalons ts, tblTreatmentTitle ttt, tblDuration td, tblCategory tc WHERE tss.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.TreatmentTitleId = ttt.TreatmentTitleId AND tss.CategoryId = tc.CategoryId AND ts.SalonsId = '" + SalonsId + "' AND tss.SalonServicesId = '" + SalonServicesId + "') AS A Left OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1) AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId ORDER BY A.SalonsId , A.CategoryId", con);
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new SearchClass
                        {
                            //AreaId = Convert.ToInt32(dr["AreaId"]),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            Category = dr["Category"].ToString(),

                            // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            TreatmentTitle = dr["TreatmentTitle"].ToString(),
                            // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                            DurationId = Convert.ToInt32(dr["DurationId"]),
                            //UserId = Convert.ToInt32(dr["UserId"]),
                            //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                            //CountryId = Convert.ToInt32(dr["CountryId"]),
                            //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                            //CityId = Convert.ToInt32(dr["CityId"]),
                            //AreaName = dr["AreaName"].ToString(),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            //CreatedDate = dr["CreatedDate"].ToString(),
                            //CityName = dr["CityName"].ToString(),
                            BusinessName = dr["BusinessName"].ToString(),
                            Image = dr["Image"].ToString(),
                            ImagePath = dr["ImagePath"].ToString(),
                            Description = dr["Description"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            Message = "Success",
                        });
                    }
                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                    return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SearchClass> ViewSalonCheckoutDetails(string BookingsId, string CheckDate)
        {
            try
            {
                con.Open();
                string value = CheckDate;
                char delimiter = ',';
                string[] substrings = value.Split(delimiter);
                for (int i = 0; i < substrings.Length; i++)
                {
                    //string CurDate = "";

                    // CurDate = substrings[i];

                    string session = "";
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }

                    //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblSalonServices tss, tblSalonCheckout tsc, tblEmployeeServices tes, tblSalonEmployees tse, tblSalons ts, tblCategory tc, tblDuration td, tblTreatmentTitle tt WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tes.SalonServicesId = tss.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tss.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.CategoryId = tc.CategoryId AND tss.TreatmentTitleId = tt.TreatmentTitleId AND tsc.EmployeeServicesId = '"+EmployeeServicesId+"' AND tsc.SalonCheckoutId = '"+SalonCheckoutId+"' AND ts.SalonsId = '"+SalonsId+"'", con);
                    //MySqlCommand cmd = new MySqlCommand("SELECT *,DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate,ts.Email as VenueEmail FROM tblSalonServices tss, tblSalonCheckout tsc, tblEmployeeServices tes, tblSalonEmployees tse, tblSalons ts, tblCategory tc, tblDuration td, tblTreatmentTitle tt WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tsc.SalonServicesId = tss.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.CategoryId = tc.CategoryId AND tss.TreatmentTitleId = tt.TreatmentTitleId AND tsc.BookingsId='" + BookingsId+"'", con);
                    //MySqlCommand cmd = new MySqlCommand("SELECT *, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, ts.Email AS VenueEmail FROM tblSalonServices tss, tblSalonCheckout tsc, tblEmployeeServices tes, tblSalonEmployees tse, tblSalons ts, tblCategory tc, tblDuration td, tblTreatmentTitle tt, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tsc.SalonServicesId = tss.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.CategoryId = tc.CategoryId AND tss.TreatmentTitleId = tt.TreatmentTitleId AND tsc.PaymentsId = tp.PaymentsId AND tsc.BookingsId = '" + BookingsId + "'", con);
                    MySqlCommand cmd = new MySqlCommand("SELECT *, CASE WHEN DAYNAME('" + substrings[i] + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM(SELECT ts.BusinessName, tss.SalonServicesId, tes.EmployeeServicesId, tsc.SalonCheckoutId, tsc.BookingDate, tsc.BookingTime, tse.EmployeeName, tss.SalonsId, tss.CategoryId, tt.TreatmentTitle, tss.TreatmentTypeId, ts.PostalCode, tss.TreatmentTitleId, tss.PricingTypeId, ts.Note, tss.Price, td.Duration, td.DurationId, ts.UserId, ts.MemberTypeId, tss.Sale, ts.SalonsUniqueId, ts.IsActive, tss.CreatedBy, tss.CreatedDate, ts.Image, ts.ImagePath, tc.Category, tss.Description, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, ts.Email AS VenueEmail FROM tblSalonServices tss, tblSalonCheckout tsc, tblEmployeeServices tes, tblSalonEmployees tse, tblSalons ts, tblCategory tc, tblDuration td, tblTreatmentTitle tt, tblPayments tp WHERE tsc.EmployeeServicesId = tes.EmployeeServicesId AND tsc.SalonServicesId = tss.SalonServicesId AND tes.SalonEmployeesId = tse.SalonEmployeesId AND tsc.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.CategoryId = tc.CategoryId AND tss.TreatmentTitleId = tt.TreatmentTitleId AND tsc.PaymentsId = tp.PaymentsId AND tsc.BookingsId = '" + BookingsId + "') AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId GROUP BY A.SalonServicesId ORDER BY A.SalonsId , A.CategoryId", con);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new SearchClass
                        {
                            //AreaId = Convert.ToInt32(dr["AreaId"]),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            VenueEmail = dr["VenueEmail"].ToString(),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                            SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            Bookdate = dr["Bookdate"].ToString(),
                            Category = dr["Category"].ToString(),
                            // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            TreatmentTitle = dr["TreatmentTitle"].ToString(),
                            // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                            DurationId = Convert.ToInt32(dr["DurationId"]),
                            //UserId = Convert.ToInt32(dr["UserId"]),
                            //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                            //CountryId = Convert.ToInt32(dr["CountryId"]),
                            //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                            //CityId = Convert.ToInt32(dr["CityId"]),
                            //AreaName = dr["AreaName"].ToString(),
                            //   IsActive = Convert.ToInt32(dr["IsActive"]),
                            //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            //CreatedDate = dr["CreatedDate"].ToString(),
                            //CityName = dr["CityName"].ToString(),
                            EmployeeName = dr["EmployeeName"].ToString(),
                            BookingDate = dr["BookingDate"].ToString(),
                            BookingTime = dr["BookingTime"].ToString(),
                            BusinessName = dr["BusinessName"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            // Image = dr["Image"].ToString(),
                            // ImagePath = dr["ImagePath"].ToString(),
                            //Description = dr["Description"].ToString(),
                            // PayableAmount =dr["PayableAmount"].ToString(),
                            Message = "Success",
                        });
                    }
                    dr.Close();
                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<SearchClass> ViewSalonOpeningHours(string SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("  select * from tblSalons ts, tblBusinessHours bh where bh.SalonsId = ts.SalonsId AND ts.SalonsId = '" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        //Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //TreatmentType = dr["TreatmentType"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        //BusinessName = dr["BusinessName"].ToString(),
                        Day = dr["Day"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        GoogleMaps = dr["GoogleMaps"].ToString(),
                        Address = dr["Address"].ToString(),
                        OpeningHours = dr["OpeningHours"].ToString(),
                        ClosingHours = dr["ClosingHours"].ToString(),
                        //Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> ViewSalonTimings(string SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" select * from tblBusinessHours bh ,tblSalons ts ,tblStartTime tst,tblEndTime tet where bh.SalonsId=ts.SalonsId AND bh.OpeningHours=tst.StartTimeId AND bh.ClosingHours=tet.EndTimeId AND ts.SalonsId='" + SalonsId + "' order by bh.BusinessHoursId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        //Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //TreatmentType = dr["TreatmentType"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        //BusinessName = dr["BusinessName"].ToString(),
                        Day = dr["Day"].ToString(),
                        //Image = dr["Image"].ToString(),
                        //ImagePath = dr["ImagePath"].ToString(),
                        //GoogleMaps = dr["GoogleMaps"].ToString(),
                        //Address = dr["Address"].ToString(),
                        OpeningHours = dr["OpeningHours"].ToString(),
                        ClosingHours = dr["ClosingHours"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        //Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SearchClass> EmployeesbasedonSalons(string SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" SELECT * FROM tblEmployeeServices tes, tblSalonEmployees tse WHERE tes.SalonEmployeesId=tse.SalonEmployeesId AND tes.SalonServicesId = '" + SalonServicesId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        Message = "Success",
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        // Price = dr["Price"].ToString(),
                        // Sale = dr["Sale"].ToString(),
                        //Duration = dr["Duration"].ToString(),
                        // SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //TreatmentType = dr["TreatmentType"].ToString(),
                        //   CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //   TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        // DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        //CreatedDate = dr["CreatedDate"].ToString(),
                        //CityName = dr["CityName"].ToString(),
                        // BusinessName = dr["BusinessName"].ToString(),
                        //Image = dr["Image"].ToString(),
                        //ImagePath = dr["ImagePath"].ToString(),
                        //GoogleMaps = dr["GoogleMaps"].ToString(),
                        // Address = dr["Address"].ToString(),
                        // OpeningHours = dr["OpeningHours"].ToString(),
                        //ClosingHours = dr["ClosingHours"].ToString(),
                        //CleanUpTime=dr["CleanUpTime"].ToString(),
                        // Description = dr["Description"].ToString(),

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SearchClass> ViewEmployeeAvailableTimings(int SalonServicesId, int SalonEmployeesId, string Date, int SalonsId)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM(SELECT es.EmployeeServicesId, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = se.StartTime) AS UnStartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = se.EndTime) AS UnEndTime, (SELECT StartTime FROM tblStartTime WHERE StartTimeId = bh.OpeningHours) AS BStartTime, (SELECT EndTime FROM tblEndTime WHERE EndTimeId = bh.ClosingHours) AS BEndTime, (select Duration from tblDuration where DurationId= (select DurationId from tblSalonServices where SalonServicesId = '" + SalonServicesId + "')) AS Duration,(select Price from tblSalonServices where SalonServicesId = 37) AS Price  FROM tblBusinessHours bh, tblSalonEmployees se, tblEmployeeServices es WHERE se.SalonsId = bh.SalonsId AND se.SalonEmployeesId = es.SalonEmployeesId AND bh.IsActive = 1 AND se.IsActive = 1 AND es.IsActive = 1 AND se.SalonEmployeesId = '" + SalonEmployeesId + "' AND es.SalonServicesId = '" + SalonServicesId + "' AND bh.Day = DAYNAME('" + Date + "') AND '" + Date + "' NOT BETWEEN se.StartDate AND se.EndDate) AS A Left outer join (select BookingDate,BookingTime,EmployeeServicesId from tblSalonCheckout where IsActive = 1 AND BookingDate = '" + Date + "') AS B ON A.EmployeeServicesId = B.EmployeeServicesId", con);


                MySqlCommand cmd = new MySqlCommand("SELECT tbh.Day, tst.StartTime, tet.EndTime,(SELECT st.StartTime FROM tblStartTime st LEFT OUTER JOIN tblSalonEmployees se ON st.StartTimeId = se.StartTime WHERE se.SalonsId = '" + SalonsId + "' AND '" + Date + "' BETWEEN se.StartDate AND se.EndDate AND se.SalonEmployeesId = '" + SalonEmployeesId + "' AND se.IsActive = 1) AS UnavailableStartTime, (SELECT et.EndTime FROM tblEndTime et LEFT OUTER JOIN tblSalonEmployees se ON et.EndTimeId = se.EndTime WHERE se.SalonsId = '" + SalonsId + "' AND '" + Date + "' BETWEEN se.StartDate AND se.EndDate AND se.SalonEmployeesId = '" + SalonEmployeesId + "' AND se.IsActive = 1) AS UnavailableEndTime,(SELECT st.StartDate FROM tblEmployeeLeaves st LEFT OUTER JOIN tblSalonEmployees se ON st.SalonEmployeesId = se.SalonEmployeesId WHERE se.SalonsId = '" + SalonsId + "' AND '" + Date + "' BETWEEN se.StartDate AND se.EndDate AND se.SalonEmployeesId = '" + SalonEmployeesId + "' AND se.IsActive = 1) AS unavainalblestartdate,(SELECT st.EndDate FROM tblEmployeeLeaves st LEFT OUTER JOIN tblSalonEmployees se ON st.SalonEmployeesId = se.SalonEmployeesId  WHERE  se.SalonsId = '" + SalonsId + "'  AND '" + Date + "' BETWEEN se.StartDate AND se.EndDate AND se.SalonEmployeesId = '" + SalonEmployeesId + "' AND se.IsActive = 1) AS unavainalbleenddate,tsc.BookingDate, tsc.BookingTime, (SELECT td.Duration FROM tblDuration td INNER JOIN tblSalonServices tss ON tss.DurationId = td.DurationId WHERE tss.SalonsId = '" + SalonsId + "' AND tss.SalonServicesId = '" + SalonServicesId + "' AND tss.IsActive = 1) AS Duration, (SELECT tcup.CleanUpTime FROM tblCleanUpTime tcup INNER JOIN tblSalonServices tss ON tss.CleanUpTime = tcup.CleanUpTimeId WHERE tss.SalonsId ='" + SalonsId + "' AND tss.SalonServicesId = '" + SalonServicesId + "' AND tss.IsActive = 1) AS CleanUpTime, (SELECT tp.BookingleadtimeforAppointments FROM tblPolicy tp WHERE tp.SalonsId ='" + SalonsId + "') AS LeadTime, (SELECT tss.Price FROM tblSalonServices tss WHERE tss.SalonsId = '" + SalonsId + "' AND tss.SalonServicesId = '" + SalonServicesId + "') AS Price FROM tblBusinessHours tbh INNER JOIN tblStartTime tst ON tbh.OpeningHours = tst.StartTimeId INNER JOIN tblEndTime tet ON tet.EndTimeId = tbh.ClosingHours LEFT OUTER JOIN tblSalonCheckout tsc ON tsc.SalonsId = '" + SalonsId + "' AND tsc.BookingDate = '" + Date + "' AND tsc.IsActive = 1 WHERE tbh.SalonsId = '" + SalonsId + "' AND tbh.IsActive = 1 AND tbh.Day = DAYNAME('" + Date + "')", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        UnStartTime = dr["UnavailableStartTime"].ToString(),
                        UnEndTime = dr["UnavailableEndTime"].ToString(),
                        UnStartDate = dr["unavainalblestartdate"].ToString(),
                        UnEndDate = dr["unavainalbleenddate"].ToString(),
                        BStartTime = dr["StartTime"].ToString(),
                        BEndTime = dr["EndTime"].ToString(),
                        BookingDate = dr["BookingDate"].ToString(),
                        BookingTime = dr["BookingTime"].ToString(),
                        CleanUpTime = dr["CleanUpTime"].ToString(),
                        LeadTime = dr["LeadTime"].ToString(),
                        //EmployeeName = dr["EmployeeName"].ToString(),
                        //AreaId = Convert.ToInt32(dr["AreaId"]),
                        Price = dr["Price"].ToString(),
                        //Sale = dr["Sale"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        //SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        //TreatmentType = dr["TreatmentType"].ToString(),
                        //CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        // Category = dr["Category"].ToString(),
                        //TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        //TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        //TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        // PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        //DurationId = Convert.ToInt32(dr["DurationId"]),
                        //UserId = Convert.ToInt32(dr["UserId"]),
                        //  MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        //SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        //CityId = Convert.ToInt32(dr["CityId"]),
                        //AreaName = dr["AreaName"].ToString(),
                        //  IsActive = Convert.ToInt32(dr["IsActive"]),
                        //CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
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
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> SearchBasedonFrontendandIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * FROM tblSalonServices ss, tblSalons s, tblCity c, tblArea a, tblTreatmentTitle tt, tblDuration td WHERE ss.DurationId = td.DurationId AND s.SalonsId = ss.SalonsId AND c.CityId = s.CityId AND a.CityId = c.CityId AND s.AreaId = a.AreaId AND s.IsActive = '1' AND c.IsActive = '1' AND a.IsActive = '1' AND tt.TreatmentTitleId = ss.TreatmentTitleId ORDER BY s.SalonsId", con);
                //SELECT *, ts.IsActive = 1 FROM tblSalons ts WHERE ts.BusinessName LIKE '%%'
                // MySqlCommand cmd = new MySqlCommand(" SELECT *  FROM tblSalons ts WHERE ts.IsActive = '1' and ts.BusinessName LIKE '%" + BusinessName + "%'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        AreaId = Convert.ToInt32(dr["AreaId"]),
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        BusinessName = dr["BusinessName"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        // TreatmentTypeId = Convert.ToInt32(dr["TreatmentTypeId"]),
                        TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                        PricingTypeId = Convert.ToInt32(dr["PricingTypeId"]),
                        Note = dr["Note"].ToString(),
                        Price = dr["Price"].ToString(),
                        Duration = dr["Duration"].ToString(),
                        TreatmentTitle = dr["TreatmentTitle"].ToString(),
                        DurationId = Convert.ToInt32(dr["DurationId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        MemberTypeId = Convert.ToInt32(dr["MemberTypeId"]),
                        Sale = dr["Sale"].ToString(),
                        //CountryId = Convert.ToInt32(dr["CountryId"]),
                        SalonsUniqueId = dr["SalonsUniqueId"].ToString(),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        AreaName = dr["AreaName"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        CityName = dr["CityName"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        Description = dr["Description"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SearchClass> BindTreatmentType(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonServices where IsActive=1 AND SalonsId='" + SalonsId + "' ", con);
                //SELECT *, ts.IsActive = 1 FROM tblSalons ts WHERE ts.BusinessName LIKE '%%'
                // MySqlCommand cmd = new MySqlCommand(" SELECT *  FROM tblSalons ts WHERE ts.IsActive = '1' and ts.BusinessName LIKE '%" + BusinessName + "%'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                        //  Duration= dr["Duration"].ToString(),
                        //  Price= dr["Price"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SearchClass> SalonRating(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select round(avg(OverallSatisfaction),2) as Averagerating from tblSalonReviews  where SalonsId=" + SalonsId + " and IsActive=1 ", con);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SearchClass
                    {
                        OverallSatisfaction = dr["Averagerating"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SearchClass
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
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SearchClass> GetEvoucherOrderSummary(string BookingsId, string CheckDate)
        {
            try
            {
                con.Open();
                string value = CheckDate;
                char delimiter = ',';
                string[] substrings = value.Split(delimiter);
                for (int i = 0; i < substrings.Length; i++)
                {
                    //string CurDate = "";

                    // CurDate = substrings[i];

                    string session = "";
                    DateTime mytime = DateTime.Now.AddMinutes(750);
                    DateTime dt1 = DateTime.Parse("00:00:00 AM");
                    DateTime dt2 = DateTime.Parse("11:59:59 AM");
                    DateTime dt3 = DateTime.Parse("12:00:00 PM");
                    DateTime dt4 = DateTime.Parse("04:59:59 PM");
                    DateTime dt5 = DateTime.Parse("05:00:00 PM");
                    DateTime dt6 = DateTime.Parse("11:59:59 PM");

                    if (mytime.TimeOfDay >= dt1.TimeOfDay && mytime.TimeOfDay <= dt2.TimeOfDay)
                    {
                        session = "Morning";
                    }
                    if (mytime.TimeOfDay >= dt3.TimeOfDay && mytime.TimeOfDay <= dt4.TimeOfDay)
                    {
                        session = "AfterNoon";
                    }
                    if (mytime.TimeOfDay >= dt5.TimeOfDay && mytime.TimeOfDay <= dt6.TimeOfDay)
                    {
                        session = "Evening";
                    }

                    MySqlCommand cmd = new MySqlCommand("SELECT distinct A.*,B.SessionStart,B.SessionEnd, CASE WHEN DAYNAME('" + substrings[i] + "') = 'Monday' && B.MonDay != 'Full price' THEN A.price * B.MonDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Tuesday' && B.TuesDay != 'Full price' THEN A.price * B.TuesDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Wednesday' && B.WednesDay != 'Full price' THEN A.price * B.WednesDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Thursday' && B.ThursDay != 'Full price' THEN A.price * B.ThursDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Friday' && B.FriDay != 'Full price' THEN A.price * B.FriDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Saturday' && B.SaturDay != 'Full price' THEN A.price * B.SaturDay / 100 WHEN DAYNAME('" + substrings[i] + "') = 'Sunday' && B.SunDay != 'Full price' THEN A.price * B.SunDay / 100 ELSE A.price END AS DiscountPrice FROM (SELECT ts.BusinessName, tss.SalonServicesId, tsc.SalonCheckoutId, tsc.BookingDate, tsc.BookingTime, tss.SalonsId, tss.CategoryId, tt.TreatmentTitle, tss.TreatmentTypeId, ts.PostalCode, tss.TreatmentTitleId, tss.PricingTypeId, ts.Note, tss.Price, td.Duration, td.DurationId, ts.UserId, ts.MemberTypeId, tss.Sale, ts.SalonsUniqueId, ts.IsActive, tss.CreatedBy, tss.CreatedDate, ts.Image, ts.ImagePath, tc.Category, tss.Description, DATE_FORMAT(tsc.BookingDate, '%d-%m-%Y') AS Bookdate, ts.Email AS VenueEmail FROM tblSalonServices tss, tblSalonCheckout tsc, tblSalons ts, tblCategory tc, tblDuration td, tblTreatmentTitle tt, tblPayments tp WHERE tsc.SalonServicesId = tss.SalonServicesId AND tsc.SalonsId = ts.SalonsId AND tss.DurationId = td.DurationId AND tss.CategoryId = tc.CategoryId AND tss.TreatmentTitleId = tt.TreatmentTitleId AND tsc.PaymentsId = tp.PaymentsId AND tsc.BookingsId = '" + BookingsId + "') AS A LEFT OUTER JOIN (SELECT * FROM tblDiscount tds WHERE tds.IsActive = 1 AND tds.Session = '" + session + "') AS B ON A.SalonsId = B.SalonsId AND A.CategoryId = B.CategoryId ORDER BY A.SalonsId , A.CategoryId", con);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj.Add(new SearchClass
                        {
                            //AreaId = Convert.ToInt32(dr["AreaId"]),
                            Price = dr["Price"].ToString(),
                            Sale = dr["Sale"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            VenueEmail = dr["VenueEmail"].ToString(),
                            SalonServicesId = Convert.ToInt32(dr["SalonServicesId"]),
                            SalonsId = Convert.ToInt32(dr["SalonsId"]),
                            //   EmployeeServicesId = Convert.ToInt32(dr["EmployeeServicesId"]),
                            SalonCheckoutId = Convert.ToInt32(dr["SalonCheckoutId"]),
                            TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            Bookdate = dr["Bookdate"].ToString(),
                            Category = dr["Category"].ToString(),
                            TreatmentTitleId = Convert.ToInt32(dr["TreatmentTitleId"]),
                            TreatmentTitle = dr["TreatmentTitle"].ToString(),
                            DurationId = Convert.ToInt32(dr["DurationId"]),
                            //  EmployeeName = dr["EmployeeName"].ToString(),
                            BookingDate = dr["BookingDate"].ToString(),
                            BookingTime = dr["BookingTime"].ToString(),
                            BusinessName = dr["BusinessName"].ToString(),
                            DiscountPrice = dr["DiscountPrice"].ToString(),
                            SessionStart = dr["SessionStart"].ToString(),
                            SessionEnd = dr["SessionEnd"].ToString(),
                            Message = "Success",
                        });
                    }

                    if (!dr.HasRows)
                    {
                        obj.Add(new SearchClass
                        {
                            Message = "NoData"
                        });
                        return obj;
                    }
                    dr.Close();
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SearchClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SearchClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

    }
    public class SearchClass
    {

        public int SalonServicesId { get; set; }
        public string Bookdate { get; set; }
        public int SalonsId { get; set; }
        public int CategoryId { get; set; }
        public string TreatmentTypeId { get; set; }
        public int TreatmentTitleId { get; set; }
        public int PricingTypeId { get; set; }
        public int DurationId { get; set; }
        public string Price { get; set; }
        public string Sale { get; set; }
        public string CleanUpTime { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int BusinessHoursId { get; set; }
        public string Day { get; set; }

        public string Image { get; set; }
        public string ImagePath { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
        public int UserId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int MemberTypeId { get; set; }
        public string PostalCode { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public int CountryId { get; set; }
        public string SalonsUniqueId { get; set; }
        public string Website { get; set; }

        public string CityName { get; set; }
        public string TreatmentType { get; set; }
        public string Note { get; set; }
        public int ManageYourBookings { get; set; }
        public string ReasonForSigningUp { get; set; }
        public string AreaName { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string Duration { get; set; }
        public string Category { get; set; }
        public string TreatmentTitle { get; set; }
        public string GoogleMaps { get; set; }
        public int EmployeeServicesId { get; set; }
        public int SalonEmployeesId { get; set; }
        public int SalonCheckoutId { get; set; }
        public string EmployeeName { get; set; }
        public string EndTime { get; set; }
        public string UnStartTime { get; set; }
        public string UnEndTime { get; set; }
        public string BStartTime { get; set; }
        public string BEndTime { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string StartTime { get; set; }
        public string SalontableImage { get; set; }
        public string SalontableImagePath { get; set; }
        public string salonImagetableImage { get; set; }
        public string SalonImagetableImagePath { get; set; }
        public string LeadTime { get; internal set; }
        public string VenueEmail { get; set; }
        public string MonPrice { get; set; }
        public string TuePrice { get; set; }
        public string WedPrice { get; set; }
        public string ThuPrice { get; set; }
        public string FriPrice { get; set; }
        public string SatPrice { get; set; }
        public string SunPrice { get; set; }
        public string DiscountPrice { get; set; }
        public string MonDay { get; set; }
        public string TuesDay { get; set; }
        public string WednesDay { get; set; }
        public string ThursDay { get; set; }
        public string SaturDay { get; set; }
        public string FriDay { get; set; }
        public string SunDay { get; set; }
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }
        public string PayableAmount { get; set; }
        public string OverallSatisfaction { get; set; }
        public List<SearchClass> Salonrating { get; set; }

        public List<SearchClass> filter { get; set; }
        public string featuredServices { get; internal set; }
        public string UnStartDate { get; internal set; }
        public string UnEndDate { get; internal set; }
    }

}