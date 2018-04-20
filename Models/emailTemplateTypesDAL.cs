using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace SalonAPI.Models
{
    public class emailTemplateTypesDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<emailTemplateTypesClass> obj = new List<emailTemplateTypesClass>();
        public IEnumerable<emailTemplateTypesClass> Getdata()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblemailTemplateTypes tet,tblEmailTemplate tt where tt.TemplateTypeId=tet.TemplateTypeId", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new emailTemplateTypesClass
                    {
                        TemplateId = Convert.ToInt32(dr["TemplateId"]),
                        TemplateTypeId= Convert.ToInt32(dr["TemplateId"]),
                        TemplateType= dr["TemplateType"].ToString(),
                        TemplateName = dr["TemplateName"].ToString(),
                        Template = dr["Template"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new emailTemplateTypesClass
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
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<emailTemplateTypesClass> GetdataTemplate()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblEmailTemplate", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new emailTemplateTypesClass
                    {
                        TemplateTypeId = Convert.ToInt32(dr["TemplateTypeId"]),
                        TemplateType = dr["TemplateType"].ToString(),
                      //  Template = dr["Template"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new emailTemplateTypesClass
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
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<emailTemplateTypesClass> GetdatabyTemplateId(int TemplateTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblEmailTemplate where TemplateTypeId='" + TemplateTypeId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new emailTemplateTypesClass
                    {
                        TemplateTypeId = Convert.ToInt32(dr["TemplateTypeId"]),
                        TemplateType = dr["TemplateType"].ToString(),
                       // Template = dr["Template"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
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
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<emailTemplateTypesClass> GetdataTemplateIsActive()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tblEmailTemplate where IsActive=1", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new emailTemplateTypesClass
                    {
                        TemplateTypeId = Convert.ToInt32(dr["TemplateTypeId"]),
                        TemplateType = dr["TemplateType"].ToString(),
                        //  Template = dr["Template"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        // UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        // UpdatedDate = dr["UpdatedDate"].ToString(),
                        Message = "Success",
                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new emailTemplateTypesClass
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
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<emailTemplateTypesClass> GetbyId(int TemplateId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblemailTemplateTypes where TemplateId='" + TemplateId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new emailTemplateTypesClass
                    {
                        TemplateId = Convert.ToInt32(dr["TemplateId"]),
                        TemplateName = dr["TemplateName"].ToString(),
                        TemplateTypeId= Convert.ToInt32(dr["TemplateTypeId"]),
                        Template = dr["Template"].ToString(),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
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
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<emailTemplateTypesClass> Insert(string TemplateName,string Template, int IsActive, int CreatedBy,int TemplateTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblemailTemplateTypes(TemplateName,Template,IsActive,CreatedBy,CreatedDate,TemplateTypeId) values('" + TemplateName + "','" + Template + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','"+ TemplateTypeId + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<emailTemplateTypesClass> InsertTemplate(string TemplateType, int IsActive, int CreatedBy)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tblEmailTemplate(TemplateType,IsActive,CreatedBy,CreatedDate) values('" + TemplateType + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }

        public IEnumerable<emailTemplateTypesClass> Update(string TemplateName, string Template, int UpdatedBy, int TemplateId, int TemplateTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblemailTemplateTypes set TemplateName='" + TemplateName + "',Template='" + Template + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',TemplateTypeId='" + TemplateId + "' where TemplateId=" + TemplateTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<emailTemplateTypesClass> UpdateTemplate(string TemplateType, int IsActive, int UpdatedBy, int TemplateTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEmailTemplate set TemplateType='" + TemplateType + "',IsActive='"+IsActive+ "',UpdatedBy='"+ UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where TemplateTypeId=" + TemplateTypeId + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<emailTemplateTypesClass> Delete(int TemplateId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblemailTemplateTypes where TemplateId='" + TemplateId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new emailTemplateTypesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<emailTemplateTypesClass> UpdateStatus(int Status, int UpdatedBy, int TemplateId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblemailTemplateTypes set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where TemplateId='" + TemplateId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<emailTemplateTypesClass> UpdateTemplateStatus(int Status, int UpdatedBy, int TemplateTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblEmailTemplate set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where TemplateTypeId='" + TemplateTypeId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new emailTemplateTypesClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new emailTemplateTypesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public String[] MyString(string data)
        {
            string value = data;
            char delimiter = ',';
            string[] substrings = value.Split(delimiter);
            return substrings;
        }
        public int SendEmail(string Email, string Mobile, string TemplateTypeId, string Content,string Name)

        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblEmailTemplate WHERE TemplateTypeId = "+TemplateTypeId+"", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    string[] myEmail = MyString(Email);
                    string[] myMobile = MyString(Mobile);
                    string[] myName = MyString(Name);
                    string[] myContent = MyString(Content);
                    for (int i = 0; i < myEmail.Length; i++)
                    {
                        //string message = 
                        // StreamReader reader = new StreamReader();
                        //dt.Rows[0]["TemplateType"].ToString() + ".html"));
                        StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Files/Templates/" + "index4.html"));
                        string readFile = reader.ReadToEnd();
                        string myString = "";
                        myString = readFile;
                        myString = myString.Replace("$$Content$$", myContent[i]);
                        myString = myString.Replace("$$Content1$$", myName[i]);
                        myString = myString.Replace("$$Footer$$", "Thank You,<br/> ETicketing<br />");
                        SmtpClient mailClient;
                        MailMessage mailmsg = new MailMessage();
                        mailmsg.IsBodyHtml = true;
                        mailmsg.From = new MailAddress(ConfigurationManager.AppSettings["emailFrom"].ToString());
                        mailmsg.To.Add(new MailAddress(myEmail[i]));
                        mailmsg.Subject = dt.Rows[0]["TemplateType"].ToString();
                        StringBuilder msgBody = new StringBuilder();
                        //msgBody.AppendFormat(@"<table width='100%'>");
                        //msgBody.AppendFormat(@"<tr><td>UserName : " + Email + "<br /></td></tr>");
                        //msgBody.AppendFormat(@"<tr><td>Password :  ET123456 <br /></td></tr>");
                        msgBody.AppendFormat(@"" + myString.ToString() + "");
                        msgBody.AppendFormat(@"<script>alert('Hello');</script>");
                        //msgBody.AppendFormat(@"<tr><td>Thank You,<br/> ETicketing<br /></td></tr>");
                        //msgBody.AppendFormat(@"</table>");
                        mailmsg.Body = msgBody.ToString();
                        mailClient = new SmtpClient(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServer"].ToString(), int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServerPort"].ToString()));
                        NetworkCredential creed = new NetworkCredential(ConfigurationManager.AppSettings["emailFrom"], ConfigurationManager.AppSettings["password"]);
                        mailClient.UseDefaultCredentials = false;
                        mailClient.Credentials = creed;
                        mailClient.EnableSsl = false;
                        mailClient.Send(mailmsg);
                    }
                    return 1;
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
    public class emailTemplateTypesClass
    {
        public int TemplateTypeId { get; set; }
        public string Template { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string TemplateType { get;  set; }
    }
}