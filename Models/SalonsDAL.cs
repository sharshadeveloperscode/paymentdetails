using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
namespace SalonAPI.Models
{
    public class SalonsDAL
    {
        MySqlConnection con2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblSalons> obj = new List<tblSalons>();

        public IEnumerable<tblSalons> GetSalons()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,tblPopularity.Popularity as popular from tblSalons,tblPopularity", con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        PopularityId = dt.Rows[i]["PopularityId"].ToString(),
                        Popularity = dt.Rows[i]["popular"].ToString(),
                        Limit = dt.Rows[i]["PLimit"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public string UpdatePopularity(int Popularity, int UpdatedBy, int PopularityId, int Limit)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("update tblPopularity set Popularity=@Popularity,UpdatedBy=@UpdatedBy,PLimit=@Limit,UpdatedDate=@UpdatedDate where PopularityId=@PopularityId", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Popularity", Popularity);
                        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                        cmd.Parameters.AddWithValue("@PopularityId", PopularityId);
                        cmd.Parameters.AddWithValue("@Limit", Limit);
                        cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now.AddMinutes(750));
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

            }
        }


        public IEnumerable<tblSalons> GetSalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,(select sum(Chairs) from tblSalonCheckout where IsActive=4 and SalonsId=" + SalonsId + ") as chairs from tblSalons where SalonsId=" + SalonsId, con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        BusinessType = Convert.ToInt32(dt.Rows[i]["BusinessType"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"]),
                        ManageYourBookings = Convert.ToInt32(dt.Rows[i]["ManageYourBookings"]),
                        ReasonForSigningUp = Convert.ToInt32(dt.Rows[i]["ReasonForSigningUp"]),
                        BusinessName = dt.Rows[i]["BusinessName"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Website = dt.Rows[i]["Website"].ToString(),
                        GoogleMaps = dt.Rows[i]["GoogleMaps"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        FrontendStatus = Convert.ToInt32(dt.Rows[i]["FrontendStatus"]),
                        Noofchairs = dt.Rows[i]["Noofchairs"].ToString(),
                        Available = dt.Rows[i]["Available"].ToString(),
                        chairs = dt.Rows[i]["chairs"].ToString(),
                        Popularity = dt.Rows[i]["Popularity"].ToString(),
                        ClassId = dt.Rows[i]["ClassId"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<tblSalons> GetSalonIdByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select SalonsId from tblSalons where UserId=" + UserId, con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select s.*,(select sum(Chairs) from tblSalonCheckout where IsActive=4 and SalonsId=s.SalonsId) as chairs from tblSalons s where s.UserId=" + UserId, con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        BusinessType = Convert.ToInt32(dt.Rows[i]["BusinessType"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"]),
                        ManageYourBookings = Convert.ToInt32(dt.Rows[i]["ManageYourBookings"]),
                        ReasonForSigningUp = Convert.ToInt32(dt.Rows[i]["ReasonForSigningUp"]),
                        BusinessName = dt.Rows[i]["BusinessName"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        Website = dt.Rows[i]["Website"].ToString(),
                        GoogleMaps = dt.Rows[i]["GoogleMaps"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Noofchairs = dt.Rows[i]["Noofchairs"].ToString(), // String.IsNullOrEmpty(dt.Rows[i]["Noofchairs"].ToString()) ? "0" : dt.Rows[i]["Noofchairs"].ToString(),
                        Available = dt.Rows[i]["Available"].ToString(),
                        chairs = dt.Rows[i]["chairs"].ToString(),
                        Popularity = dt.Rows[i]["Popularity"].ToString(),
                        ClassId = dt.Rows[i]["ClassId"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> UpdateSalons(string BusinessName, string Address, string Name, string PostalCode, int MemberTypeId, string Note, string PhoneNumber, string Email, string Password, int BusinessType, int CityId, int AreaId, int CountryId, int ManageYourBookings, int ReasonForSigningUp, string Website, string GoogleMaps, string Image, string ImagePath, int UpdatedBy, int FrontendStatus, int SalonsId, int Noofchairs, int Available, int Popularity, int ClassId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalons set  BusinessName='" + BusinessName + "',Address='" + Address + "',Name='" + Name + "',  PostalCode='" + PostalCode + "',MemberTypeId='" + MemberTypeId + "',AreaId='" + AreaId + "',CountryId='" + CountryId + "', Note=@Note,PhoneNumber='" + PhoneNumber + "',Email='" + Email + "',Password='" + Password + "' ,BusinessType='" + BusinessType + "',CityId='" + CityId + "',ManageYourBookings='" + ManageYourBookings + "',ReasonForSigningUp='" + ReasonForSigningUp + "', Website='" + Website + "',GoogleMaps='" + GoogleMaps + "',Image='" + Image + "',ImagePath='" + ImagePath + "' ,  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',FrontendStatus='" + FrontendStatus + "',Noofchairs='" + Noofchairs + "',Available=" + Available + ",Popularity=" + Popularity + ",ClassId=" + ClassId + " where SalonsId='" + SalonsId + "' ", con2);
                con2.Open();
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = new MySqlCommand("select UserId from tblSalons where SalonsId='" + SalonsId + "'", con2);
                MySqlDataReader dr = cmd1.ExecuteReader();

                dr.Read();
                int i = Convert.ToInt32(dr["UserId"]);
                dr.Close();
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("update tblUsers set UserName='" + Email + "',Password='" + Password + "',Name='" + BusinessName + "',Email='" + Email + "' where UserId='" + i + "' ", con2);

                cmd2.ExecuteNonQuery();


                obj.Add(new tblSalons { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblSalons { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con2.Close();
            }
        }

        public IEnumerable<tblSalons> InsertSalons(string BusinessName, string Address, string Name, string PostalCode, int MemberTypeId, string Note, string PhoneNumber, string Email, string Password, int BusinessType, int CityId, int AreaId, int CountryId, int ManageYourBookings, int ReasonForSigningUp, string Website, string GoogleMaps, string Image, string ImagePath, int CreatedBy, int FrontendStatus, int Noofchairs, int Popularity, int ClassId)
        {
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("insert into tblUsers (Name,RoleId,UserName,Password,Email,MobileNumber, CreatedBy,CreatedDate,Status) values ('" + BusinessName + "','" + 10 + "','" + Email + "','" + Password + "','" + Email + "','" + PhoneNumber + "', '" + CreatedBy + "' , '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1)", con2);
                con2.Open();
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("select UserId from tblUsers order by UserId DESC limit 1", con2);
                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                int UserId = Convert.ToInt32(dr["UserId"]);
                dr.Close();

                MySqlCommand cmd3 = new MySqlCommand("select SalonsId from tblSalons order by SalonsId DESC limit 1", con2);
                MySqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                int Number = Convert.ToInt32(dr3["SalonsId"]);
                dr3.Close();

                Random generator = new Random();
                int RandomNumber = generator.Next(100000, 1000000);
                string currentYear = DateTime.Now.Year.ToString();
                string UniqueNumber = currentYear + "_" + "Salon" + "_" + RandomNumber + "_" + Number;


                MySqlCommand cmd = new MySqlCommand("insert into tblSalons(UserId,BusinessName,IsActive,Address,Name,PostalCode,MemberTypeId,Note,PhoneNumber,Email,Password,BusinessType,CityId,AreaId,CountryId,ManageYourBookings,ReasonForSigningUp,SalonsUniqueId,Website,GoogleMaps,Image,ImagePath, CreatedBy,CreatedDate,FrontendStatus,Noofchairs,Available,Popularity,ClassId) values ('" + UserId + "','" + BusinessName + "','" + 1 + "','" + Address + "','" + Name + "','" + PostalCode + "','" + MemberTypeId + "',@Note,'" + PhoneNumber + "','" + Email + "','" + Password + "','" + BusinessType + "', '" + CityId + "','" + AreaId + "','" + CountryId + "','" + ManageYourBookings + "','" + ReasonForSigningUp + "','" + UniqueNumber + "','" + Website + "','" + GoogleMaps + "', '" + Image + "','" + ImagePath + "',  '" + CreatedBy + "' ,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + FrontendStatus + "','" + Noofchairs + "','" + Noofchairs + "'," + Popularity + "," + ClassId + ")", con2);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.ExecuteNonQuery();
                con2.Close();
                obj.Add(new tblSalons { Message = "Success", UserId = UserId, Email = Email });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Duplicate entry"))
                {
                    obj.Add(new tblSalons { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<tblSalons> DeleteSalons(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSalons where SalonsId='" + SalonsId + "'", con2);
                con2.Open();
                cmd.ExecuteNonQuery();
                con2.Close();
                obj.Add(new tblSalons { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<tblSalons> UpdateStatus(int IsActive, int UpdatedBy, int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalons set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonsId='" + SalonsId + "' ", con2);
                con2.Open();
                cmd.ExecuteNonQuery();
                con2.Close();
                obj.Add(new tblSalons { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetActiveSalons()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews FROM tblSalons s left outer join tblFavouriteSalons f on s.SalonsId=f.SalonsId WHERE s.IsActive = '1';", con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetSalonsByPopularity()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews FROM tblSalons s WHERE s.IsActive = '1' order by Popularity desc;", con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetPopularSalonsByReviews()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews FROM tblSalons s WHERE s.IsActive = '1' order by Reviews desc;", con2);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetPopularSalons()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_GetPopularSalons", con2);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetSalonsBySearch(int Id, string Type)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Sp_Get_Salons_By_Search", con2);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Type", Type);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
                    {
                        SalonsId = Convert.ToInt32(dt.Rows[i]["SalonsId"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        BusinessType = Convert.ToInt32(dt.Rows[i]["BusinessType"]),
                        CityId = Convert.ToInt32(dt.Rows[i]["CityId"]),
                        AreaId = Convert.ToInt32(dt.Rows[i]["AreaId"]),
                        CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"]),
                        ManageYourBookings = Convert.ToInt32(dt.Rows[i]["ManageYourBookings"]),
                        ReasonForSigningUp = Convert.ToInt32(dt.Rows[i]["ReasonForSigningUp"]),
                        BusinessName = dt.Rows[i]["BusinessName"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        Website = dt.Rows[i]["Website"].ToString(),
                        GoogleMaps = dt.Rows[i]["GoogleMaps"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        FrontendStatus = Convert.ToInt32(dt.Rows[i]["FrontendStatus"]),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblSalons> GetSalonsByFilter(string StartPrice, string EndPrice, string Date, string Chairs, string City, string Class)
        {
            try
            {
                string day = null;
                if(Date!="" && Date!=null)
                {
                    day = Convert.ToDateTime(Date).DayOfWeek.ToString();
                }
                MySqlCommand cmd = new MySqlCommand("Sp_SalonsFilterSearch", con2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("startprice", StartPrice);
                cmd.Parameters.AddWithValue("endprice", EndPrice);
                cmd.Parameters.AddWithValue("dayname", day);
                cmd.Parameters.AddWithValue("chairs", Chairs);
                cmd.Parameters.AddWithValue("city", City);
                cmd.Parameters.AddWithValue("class", Class);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblSalons
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
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblSalons { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblSalons { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        //class for tblSalons
        public class tblSalons
        {
            public string BusinessName { get; set; }
            public string Address { get; set; }
            public string Name { get; set; }
            public string PostalCode { get; set; }
            public int MemberTypeId { get; set; }
            public int FrontendStatus { get; set; }
            public string Note { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public int SalonsId { get; set; }
            public int UserId { get; set; }
            public int CityId { get; set; }
            public int AreaId { get; set; }
            public int CountryId { get; set; }
            public int ManageYourBookings { get; set; }
            public int ReasonForSigningUp { get; set; }
            public int BusinessType { get; set; }
            public int IsActive { get; set; }
            public string Website { get; set; }
            public string GoogleMaps { get; set; }
            public string Image { get; set; }
            public string ImagePath { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
            public string Noofchairs { get; internal set; }
            public string Available { get; internal set; }
            public string chairs { get; internal set; }
            public string Reviews { get; internal set; }
            public string Rating { get; internal set; }
            public string Popularity { get; internal set; }
            public string PopularityId { get; internal set; }
            public string Limit { get; internal set; }
            public string ClassId { get; internal set; }
            public string FavouriteId { get; internal set; }
        }

    }
}