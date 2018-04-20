using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Net.Mime;
using SalonAPI.Controllers;
using System.Web.Hosting;

namespace PortalHydAPI.Controllers
{
    public class UploadController : ApiController
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);

        [HttpGet]
        public void SendSMS(string mobile)
        {


            string user = "PriorityServices";
            string password = "cshyd@1234";
            string genkey = "592128563";
            string number = mobile;
            string sender = "PRISER";
            string message = "Test";
            string sURL = "http://bulksmsapps.com/apisms.aspx?user=" + user + "&password=" + password + "&genkey=" + genkey + "&sender=" + sender + "&number=" + number + "&message=" + message + "";
            string sResponse = GetResponse(sURL);
        }
        public static string GetResponse(string sURL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
                request.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception)
            {
                return "";
            }
        }

        [HttpGet]
        public string SendWelcomeEmail(string MemberShipNo, string Name, string Email, string LoginName, string Password, string MemberShipFee)
        {
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/WelcomePage.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            string Message = "";
            myString = readFile;
            myString = myString.Replace("$$Name$$", Name);
            myString = myString.Replace("$$Email$$", Email);
            myString = myString.Replace("$$LoginName$$", LoginName);
            myString = myString.Replace("$$Password$$", Password);
            MailMessage Msg = new MailMessage();
            MailAddress fromMail = new MailAddress(ConfigurationManager.AppSettings["emailFrom"].ToString());
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress(Email));
            // Subject of e-mail
            Msg.Subject = "Welcome !!!";
            Msg.Body = myString.ToString();
            Msg.IsBodyHtml = true;
            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSL"].ToString());
            try
            {
                mSmtpClient.Send(Msg);
                Message = "Success";
            }
            catch (Exception)
            {
                Message = "fail";
            }
            return Message;
        }


        // Mail
        [HttpGet]
        public string SendEmail(string Email, string Message)
        {
            try
            {
                string message = Message;
                SmtpClient mailClient;
                MailMessage mailmsg = new MailMessage();
                mailmsg.IsBodyHtml = true;
                mailmsg.From = new MailAddress(ConfigurationManager.AppSettings["emailfrom"].ToString());
                mailmsg.To.Add(new MailAddress(Email));
                mailmsg.Subject = "Salons";
                StringBuilder msgBody = new StringBuilder();
                msgBody.AppendFormat(@"" + Message + "");
                mailmsg.Body = msgBody.ToString();
                mailClient = new SmtpClient(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServer"].ToString(), int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServerPort"].ToString()));
                NetworkCredential creed = new NetworkCredential(ConfigurationManager.AppSettings["emailfrom"], ConfigurationManager.AppSettings["password"]);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = creed;
                mailClient.EnableSsl = false;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.Send(mailmsg);

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [HttpGet]
        public string SendEmailNotifications(string Email, string Message)
        {
            try
            {
                string value = Email;
                char delimiter = ',';
                string[] substrings = value.Split(delimiter);
                for (int i = 0; i < substrings.Length; i++)
                {
                    string message = Message;
                    SmtpClient mailClient;
                    MailMessage mailmsg = new MailMessage();
                    mailmsg.IsBodyHtml = true;
                    mailmsg.From = new MailAddress(ConfigurationManager.AppSettings["emailfrom"].ToString());
                    mailmsg.To.Add(new MailAddress(substrings[i]));
                    mailmsg.Subject = "Salons";
                    StringBuilder msgBody = new StringBuilder();
                    msgBody.AppendFormat(@"" + Message + "");
                    mailmsg.Body = msgBody.ToString();
                    mailClient = new SmtpClient(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServer"].ToString(), int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpServerPort"].ToString()));
                    NetworkCredential creed = new NetworkCredential(ConfigurationManager.AppSettings["emailfrom"], ConfigurationManager.AppSettings["password"]);
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = creed;
                    mailClient.EnableSsl = false;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.Send(mailmsg);
                }
                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        [AcceptVerbs("GET", "POST")]
        public string UploadServiceImage()
        {
            string _imgname = string.Empty;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    DirectoryInfo di;
                    di = new DirectoryInfo(HostingEnvironment.MapPath("~/Files/ServiceImages/"));
                    var fileName = Path.GetFileName(pic.FileName);
                    var Name = fileName.Split('.');
                    //_imgname = HttpContext.Current.Request.Url.AbsoluteUri+"/Files/ServiceImages/"+fileName;
                    _imgname = fileName;
                    var _comPath = "";
                    _comPath = HostingEnvironment.MapPath("~/Files/ServiceImages/") + fileName;
                    var path = _comPath;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    pic.SaveAs(path);
                }
            }
            return _imgname;
        }




    }
}



