using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class SalonReviewsDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonReviewsClass> obj = new List<SalonReviewsClass>();



        public IEnumerable<SalonReviewsClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,u.Name as CustomerName from tblSalonReviews ts,tblSalons s,tblUsers u where ts.SalonsId=s.SalonsId AND ts.UserId=u.UserId order by ts.SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        CustomerName = dr["CustomerName"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetSalonReviewsById(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select *,u.Name as CustomerName from tblSalonReviews ts,tblSalons s,tblUsers u where ts.SalonsId=s.SalonsId AND ts.UserId=u.UserId and ts.SalonsId=" + SalonsId + " order by ts.SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        CustomerName = dr["CustomerName"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetSalonReviews()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select s.BusinessName,s.SalonsId,(select avg(OverallSatisfaction) as Rating from tblSalonReviews where SalonsId=sr.SalonsId)as Rating from tblSalonReviews sr inner join tblSalons s on s.SalonsId=sr.SalonsId and sr.IsActive=1 group by s.BusinessName order by sr.SalonsId desc;", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        OverallSatisfaction = dr["Rating"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SalonReviewsClass> GetUserReviews(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *,s.ImagePath as SalonImagePath  FROM tblSalonCheckout tsc, tblPayments tp, tblSalons s WHERE tsc.PaymentsId = tp.PaymentsId AND s.SalonsId=tsc.SalonsId AND tsc.IsActive = 4 AND tp.UserId = '" + UserId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //obj.Add(new SalonReviewsClass
                    //{
                    //    BusinessName = dr["BusinessName"].ToString(),
                    //    Name = dr["Name"].ToString(),
                    //    CustomerName = dr["CustomerName"].ToString(),
                    //    SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                    //    TreatmnetRating = dr["TreatmnetRating"].ToString(),
                    //    OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                    //    UserId = Convert.ToInt32(dr["UserId"]),
                    //    SalonsId = Convert.ToInt32(dr["SalonsId"]),
                    //    IsActive = Convert.ToInt32(dr["IsActive"]),
                    //    CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                    //    CreatedDate = dr["CreatedDate"].ToString(),
                    //    Comment = dr["Comment"].ToString(),
                    //    Message = "Success",
                    //});
                }
                if (!dr.HasRows)
                {
                    dr.Close();
                    obj.Add(new SalonReviewsClass
                    {
                        Message = "No Bookings"
                    });
                    return obj;
                }
                else
                {
                    int SalonsId1 = Convert.ToInt32(dr["SalonsId"]);
                    string SalonImagePath1 = dr["SalonImagePath"].ToString();
                    string BusinessName1 = dr["BusinessName"].ToString();
                    dr.Close();
                    MySqlCommand cmd2 = new MySqlCommand(" SELECT *,s.ImagePath as SalonImagePath FROM tblSalonReviews sr, tblCustomers c, tblSalons s WHERE c.UserId = sr.UserId AND s.SalonsId=sr.SalonsId AND sr.UserId = '" + UserId + "' GROUP BY sr.SalonsId DESC", con);
                    MySqlDataReader dr1 = cmd2.ExecuteReader();
                    while (dr1.Read())
                    {
                        obj.Add(new SalonReviewsClass
                        {
                            ProfileName = dr1["ProfileName"].ToString(),
                            SalonsId = Convert.ToInt32(dr1["SalonsId"]),
                            BusinessName = dr1["BusinessName"].ToString(),
                            SalonImagePath = dr1["SalonImagePath"].ToString(),
                            SalonReviewsId = Convert.ToInt32(dr1["SalonReviewsId"]),
                            OverallSatisfaction = dr1["OverallSatisfaction"].ToString(),
                            Message = "Success"
                        });
                        // return obj;
                    }
                    if (!dr1.HasRows)
                    {
                        dr1.Close();
                        obj.Add(new SalonReviewsClass
                        {
                            SalonsId = SalonsId1,
                            BusinessName = BusinessName1,
                            SalonImagePath = SalonImagePath1,
                            Message = "No Reviews"
                        });
                        //return obj;
                    }
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }











        public IEnumerable<SalonReviewsClass> GetAvgRatings(int SalonsId)
        {
            try
            {
                int i = 0;
                MySqlCommand cmd = new MySqlCommand("SELECT *,count(tsr.SalonReviewsId) as ReviewsCount, round(AVG(tsr.OverallSatisfaction),1) AS overallmax, round(AVG(tsr.Ambience),1) AS Ambiencemax, round(AVG(tsr.Staff),1) AS Staffmax, round( AVG(tsr.Cleanliness),1) AS Cleanlinesmax, round(AVG(tsr.Value), 1) AS valuemax FROM tblSalonReviews tsr where tsr.IsActive=1 and tsr.SalonsId='" + SalonsId + "' ", con);

                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    if (dr["ReviewsCount"] != null)
                    {
                        i = Convert.ToInt32(dr["ReviewsCount"]);
                    }


                    if (i > 0)
                    {
                        obj.Add(new SalonReviewsClass
                        {
                            overallmax = Convert.ToDecimal(dr["overallmax"]),
                            Ambiencemax = Convert.ToDecimal(dr["Ambiencemax"]),
                            Staffmax = Convert.ToDecimal(dr["Staffmax"]),
                            Cleanlinesmax = Convert.ToDecimal(dr["Cleanlinesmax"]),
                            valuemax = Convert.ToDecimal(dr["valuemax"]),
                            ReviewsCount = Convert.ToInt32(dr["ReviewsCount"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]),
                            CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Comment = dr["Comment"].ToString(),
                            Message = "Success",
                        });
                    }
                    else
                    {
                        obj.Add(new SalonReviewsClass
                        {
                            Message = "NoData"
                        });
                    }
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
                    {
                        Message = "NoData"
                    });
                    //return obj;
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonReviewsClass> GetRatingsCount(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT(select count(tsr.OverallSatisfaction) as overallcount from tblSalonReviews tsr where tsr.OverallSatisfaction>=4 and tsr.SalonsId='" + SalonsId + "') as overall5, (select count(tsr.OverallSatisfaction) as overallcount from tblSalonReviews tsr where tsr.OverallSatisfaction>=3 and tsr.OverallSatisfaction<4 and tsr.SalonsId='" + SalonsId + "') as overall4, (select count(tsr.OverallSatisfaction) as overallcount from tblSalonReviews tsr where tsr.OverallSatisfaction>=2 and tsr.OverallSatisfaction<3 and tsr.SalonsId='" + SalonsId + "') as overall3, (select count(tsr.OverallSatisfaction) as overallcount from tblSalonReviews tsr where tsr.OverallSatisfaction>='" + SalonsId + "' and tsr.OverallSatisfaction<2 and tsr.SalonsId='" + SalonsId + "') as overall2 , (select count(tsr.OverallSatisfaction) as overallcount from tblSalonReviews tsr where tsr.OverallSatisfaction<'" + SalonsId + "' and tsr.SalonsId='" + SalonsId + "') as overall1  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonReviewsClass
                    {
                        overall5 = Convert.ToInt32(dr["overall5"]),
                        overall4 = Convert.ToInt32(dr["overall4"]),
                        overall3 = Convert.ToInt32(dr["overall3"]),
                        overall2 = Convert.ToInt32(dr["overall2"]),
                        overall1 = Convert.ToInt32(dr["overall1"]),

                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetDatabyId(int SalonReviewsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblSalonReviews ts,tblSalons s,tblUsers u where ts.SalonsId=s.SalonsId AND ts.UserId=u.UserId AND SalonReviewsId='" + SalonReviewsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonReviewsClass
                    {
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonReviewsClass> Insert(int SalonsId, int UserId, string TreatmnetRating, string Comment, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonReviews(SalonsId,UserId,TreatmnetRating,Comment,IsActive,CreatedBy,CreatedDate) values('" + SalonsId + "'," + UserId + ",'" + TreatmnetRating + "','" + Comment + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonReviewsClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonReviewsClass> InsertSalonReviews(int SalonsId, int UserId, string Comment, decimal OverallSatisfaction, string Type, string SalonServiceId, string EmployeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonReviews(SalonsId,UserId,TreatmnetRating,Comment,IsActive,CreatedBy,CreatedDate,OverallSatisfaction,Type,SalonServiceId,EmployeeId) values('" + SalonsId + "'," + UserId + ",'" + OverallSatisfaction + "','" + Comment + "','1','" + UserId + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + OverallSatisfaction + "','" + Type + "','" + SalonServiceId + "','" + EmployeeId + "')", con);


                con.Open();
                cmd.ExecuteNonQuery();
                int SalonReviewsId = Convert.ToInt32(cmd.LastInsertedId);
                obj.Add(new SalonReviewsClass { Message = "Success", SalonReviewsId = SalonReviewsId });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        public IEnumerable<SalonReviewsClass> InsertServiceReviews(string ServiceTitle, decimal ServiceRating, int SalonsId, int UserId, int SalonReviewsId, int IsActive, int CreatedBy, int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonServiceReviews(ServiceTitle,ServiceRating,SalonsId,UserId,SalonReviewsId,IsActive,CreatedBy,CreatedDate,SalonServicesId) values('" + ServiceTitle + "'," + ServiceRating + ",'" + SalonsId + "','" + UserId + "','" + SalonReviewsId + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "'.'" + SalonServicesId + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonReviewsClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonReviewsClass> Update(int SalonsId, int UserId, string TreatmnetRating, string Comment, int UpdatedBy, int SalonReviewsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonReviews set SalonsId='" + SalonsId + "',UserId=" + UserId + ",TreatmnetRating='" + TreatmnetRating + "',Comment='" + Comment + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where SalonReviewsId=" + SalonReviewsId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonReviewsClass
                {
                    Message =
                    "Success"
                });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonReviewsClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonReviewsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonReviews set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonReviewsId='" + SalonReviewsId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonReviewsClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<SalonReviewsClass> GetDatabySalonsId(int SalonsId)
        {
            try
            {

                //MySqlCommand cmd = new MySqlCommand("select * from tblSalonReviews ts,tblSalons s,tblUsers u where ts.SalonsId=s.SalonsId AND ts.UserId=u.UserId AND s.SalonsId='" + SalonsId + "'", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *,tc.ImagePath as UserImagePath ,tc.FirstName as UserFirstName ,tc.LastName as UserLastName ,date_format(ts.CreatedDate,'%d %M %Y') as Reviewcreateddate FROM tblSalonReviews ts, tblSalons s, tblUsers u, tblCustomers tc WHERE ts.SalonsId = s.SalonsId AND ts.UserId = u.UserId AND tc.UserId=ts.UserId AND ts.IsActive=1 AND s.SalonsId = '" + SalonsId + "' order by SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CommentDAL Comment = new CommentDAL();
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UserImagePath = dr["UserImagePath"].ToString(),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        CreatedDate = dr["Reviewcreateddate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                        SalonReview = Comment.GetdataBySalonReviewsId(Convert.ToInt32(dr["SalonReviewsId"])).ToList()

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetServicesReviewBySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *,tc.ImagePath as UserImagePath ,tc.FirstName as UserFirstName ,tc.LastName as UserLastName ,date_format(ts.CreatedDate,'%d %M %Y') as Reviewcreateddate FROM tblSalonReviews ts, tblSalons s, tblUsers u, tblCustomers tc WHERE ts.SalonsId = s.SalonsId AND ts.UserId = u.UserId AND tc.UserId=ts.UserId AND ts.IsActive=1 AND ts.SalonServiceId in (select SalonServicesId from tblSalonServices where SalonsId='" + SalonsId + "') order by SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CommentDAL Comment = new CommentDAL();
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        TreatmentTypeId = dr["TreatmentTypeId"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UserImagePath = dr["UserImagePath"].ToString(),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        CreatedDate = dr["Reviewcreateddate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                        SalonReview = Comment.GetdataBySalonReviewsId(Convert.ToInt32(dr["SalonReviewsId"])).ToList()

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetReviewByServiceId(int SalonServicesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *,tc.ImagePath as UserImagePath ,tc.FirstName as UserFirstName ,tc.LastName as UserLastName ,date_format(ts.CreatedDate,'%d %M %Y') as Reviewcreateddate FROM tblSalonReviews ts, tblSalons s, tblUsers u, tblCustomers tc WHERE ts.SalonsId = s.SalonsId AND ts.UserId = u.UserId AND tc.UserId=ts.UserId AND ts.IsActive=1 AND ts.SalonServicesId = '" + SalonServicesId + "' order by SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CommentDAL Comment = new CommentDAL();
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UserImagePath = dr["UserImagePath"].ToString(),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        CreatedDate = dr["Reviewcreateddate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                        SalonReview = Comment.GetdataBySalonReviewsId(Convert.ToInt32(dr["SalonReviewsId"])).ToList()

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonReviewsClass> GetEmployeeReviewBySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *,tc.ImagePath as UserImagePath ,tc.FirstName as UserFirstName ,tc.LastName as UserLastName ,date_format(ts.CreatedDate,'%d %M %Y') as Reviewcreateddate FROM tblSalonReviews ts, tblSalons s, tblUsers u, tblCustomers tc,tblSalonEmployees se WHERE ts.SalonsId = s.SalonsId AND ts.UserId = u.UserId AND tc.UserId=ts.UserId AND se.SalonsId=s.SalonsId AND ts.IsActive=1 AND ts.EmployeeId in (select SalonEmployeesId from tblSalonEmployees where SalonsId='" + SalonsId + "') order by SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CommentDAL Comment = new CommentDAL();
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        EmployeeName=dr["EmployeeName"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UserImagePath = dr["UserImagePath"].ToString(),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        CreatedDate = dr["Reviewcreateddate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                        SalonReview = Comment.GetdataBySalonReviewsId(Convert.ToInt32(dr["SalonReviewsId"])).ToList()

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SalonReviewsClass> GetReviewByEmployeeId(int EmployeeId)
        {
            try
            {

                //MySqlCommand cmd = new MySqlCommand("select * from tblSalonReviews ts,tblSalons s,tblUsers u where ts.SalonsId=s.SalonsId AND ts.UserId=u.UserId AND s.SalonsId='" + SalonsId + "'", con);
                MySqlCommand cmd = new MySqlCommand("SELECT *,tc.ImagePath as UserImagePath ,tc.FirstName as UserFirstName ,tc.LastName as UserLastName ,date_format(ts.CreatedDate,'%d %M %Y') as Reviewcreateddate FROM tblSalonReviews ts, tblSalons s, tblUsers u, tblCustomers tc WHERE ts.SalonsId = s.SalonsId AND ts.UserId = u.UserId AND tc.UserId=ts.UserId AND ts.IsActive=1 AND ts.EmployeeId = '" + EmployeeId + "' order by SalonReviewsId desc", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CommentDAL Comment = new CommentDAL();
                    obj.Add(new SalonReviewsClass
                    {
                        BusinessName = dr["BusinessName"].ToString(),
                        Name = dr["Name"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        TreatmnetRating = dr["TreatmnetRating"].ToString(),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        UserImagePath = dr["UserImagePath"].ToString(),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        OverallSatisfaction = dr["OverallSatisfaction"].ToString(),
                        CreatedDate = dr["Reviewcreateddate"].ToString(),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",
                        SalonReview = Comment.GetdataBySalonReviewsId(Convert.ToInt32(dr["SalonReviewsId"])).ToList()

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonReviewsClass
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
                    obj.Add(new SalonReviewsClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonReviewsClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

    }



    public class SalonReviewsClass
    {
        public string BusinessName;
        public string Name;
        public int SalonReviewsId { get; set; }
        public int SalonsId { get; set; }
        public int UserId { get; set; }
        public string BookingsCount { get; set; }
        public decimal overallmax { get; set; }
        public decimal Ambiencemax { get; set; }
        public decimal Staffmax { get; set; }
        public decimal Cleanlinesmax { get; set; }
        public decimal valuemax { get; set; }
        public int ReviewsCount { get; set; }
        public int overall5 { get; set; }
        public int overall4 { get; set; }
        public int overall3 { get; set; }
        public int overall2 { get; set; }
        public int overall1 { get; set; }
        public string SalonImagePath { get; set; }
        public string Comment { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string TreatmnetRating { get; set; }
        public string OverallSatisfaction { get; set; }
        public string CustomerName { get; set; }
        public string ProfileName { get; set; }
        public string UserImagePath { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }

        public List<tblComment> SalonReview { get; set; }
        public string TreatmentTypeId { get; internal set; }
        public string EmployeeName { get; internal set; }
    }
}