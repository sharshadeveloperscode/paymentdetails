using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace Salon.Helper
{
    public class dbHelper
    {
        MySqlConnection con2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        public MySqlConnection GetConnection()
        {
            return con2;
        }

        public void opencon()
        {
            if (con2.State == ConnectionState.Closed)
            {
                con2.Open();
            }
        }

        public void closecon()
        {
            if (con2.State == ConnectionState.Open)
            {
                con2.Close();
            }
        }

        public void SendSMS(string mobile, string sms)
        {
           // string sender = "MFBOOK";
            string sender = "MGNINF";
            string number = mobile;
            //string message = sms;
            string user = "dcteam";
            string password = "98d39sdk@000";
            string genkey = "737089527";

            string sURL = "http://bulksmsapps.com/apisms.aspx?user=" + user + "&password=" + password + "&genkey=" + genkey + "&sender=" + sender + "&number=" + number + "&message=" + sms + "";
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



    }
}