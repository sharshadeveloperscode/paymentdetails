using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SalonAPI.Models
{
    public class CommentDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblComment> obj = new List<tblComment>();

        public IEnumerable<tblComment> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblComment", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblComment
                    {
                        CommentId = Convert.ToInt32(dr["CommentId"]),
                        SalonReviewsId = Convert.ToInt32(dr["Price"]),
                        Comment = dr["Comment"].ToString(),                        
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new tblComment
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
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }           
            
        }

        public IEnumerable<tblComment> GetComments(int SalonReviewsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select tc.*,tcc.FirstName,tcc.LastName from tblComment tc,tblSalonReviews tsr,tblUsers tu,tblCustomers tcc where tc.SalonReviewsId=tsr.SalonReviewsId AND tcc.UserId=tu.UserId AND tsr.UserId=tu.UserId and tc.SalonReviewsId="+ SalonReviewsId, con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblComment
                    {
                        CommentId = Convert.ToInt32(dr["CommentId"]),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        Comment = dr["Comment"].ToString(),
                        IsActive= Convert.ToInt32(dr["IsActive"]),
                        FirstName =dr["FirstName"].ToString(),
                        LastName=dr["LastName"].ToString(),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new tblComment
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
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }



        public IEnumerable<tblComment> GetdataBySalonReviewsId(int SalonReviewsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblComment c,tblUsers u,tblCustomers cu WHERE c.CreatedBy=u.UserId AND cu.UserId=c.CreatedBy AND c.SalonReviewsId = "+SalonReviewsId+" AND c.IsActive = 1", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new tblComment
                    {
                        CommentId = Convert.ToInt32(dr["CommentId"]),
                        FirstName=dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        SalonReviewsId = Convert.ToInt32(dr["SalonReviewsId"]),
                        Comment = dr["Comment"].ToString(),
                        Message = "Success",

                    });
                }
                //if (!dr.HasRows)
                //{
                //    obj.Add(new tblComment
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
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        public IEnumerable<tblComment> Insert(int SalonReviewsId,string Comment, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblComment(SalonReviewsId,Comment,IsActive,CreatedBy,CreatedDate) values('" + SalonReviewsId + "','"+ Comment + "',1,'" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblComment { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }


       



        public IEnumerable<tblComment> Update(int CommentId, int SalonReviewsId, string Comment)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblComment set SalonReviewsId=" + SalonReviewsId + ", Comment='" + Comment + "' where CommentId=" + CommentId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblComment { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<tblComment> Delete(int CommentId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblComment where CommentId='" + CommentId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new tblComment { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblComment { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<tblComment> UpdateStatus(int IsActive, int UpdatedBy, int CommentId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblComment set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where CommentId='" + CommentId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new tblComment { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblComment { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class tblComment
    {
        public int CommentId { get; set; }
        public int SalonReviewsId { get; set; }
        public string Comment { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int IsActive { get; internal set; }
    }

}