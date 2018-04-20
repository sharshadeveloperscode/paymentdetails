using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace SalonAPI.Models
{
    public class CustomersDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<tblCustomers> obj = new List<tblCustomers>();

        public IEnumerable<tblCustomers> GetCustomers()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCustomers", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblCustomers
                    {
                        CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        ProfileName = dt.Rows[i]["ProfileName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblCustomers { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblCustomers> GetCustomersId(int CustomerId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCustomers where CustomerId=" + CustomerId, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblCustomers
                    {
                        CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]),

                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        ProfileName = dt.Rows[i]["ProfileName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        Address= dt.Rows[i]["Address"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblCustomers> GetCustomersDetailsByUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCustomers where UserId=" + UserId, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblCustomers
                    {
                        CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]),

                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        ProfileName = dt.Rows[i]["ProfileName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<tblCustomers> GetUserId(int UserId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(" select *,tc.ProfileName as customerProfileName, tc.PostalCode as customerPostcode, tc.Email as customerEmail, tc.Password as customerPassword, tu.UserName as custUserName, tc.PhoneNumber as custPhoneNumber from tblCustomers tc, tblUsers tu where tc.UserId=tu.UserId AND tu.UserId='"+UserId+"'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblCustomers
                    {
                        customerProfileName= dt.Rows[i]["customerProfileName"].ToString(),
                        customerPostcode = dt.Rows[i]["customerPostcode"].ToString(),
                        customerEmail = dt.Rows[i]["customerEmail"].ToString(),
                        customerPassword = dt.Rows[i]["customerPassword"].ToString(),
                        custUserName = dt.Rows[i]["custUserName"].ToString(),
                        custPhoneNumber = dt.Rows[i]["custPhoneNumber"].ToString(),
                        CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]),
                        Address= dt.Rows[i]["Address"].ToString(),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        UserName = dt.Rows[i]["UserName"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        ProfileName = dt.Rows[i]["ProfileName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

   
        public IEnumerable<tblCustomers> UpdateCustomers(string FirstName,string LastName,string PhoneNumber, string ProfileName,string PostalCode, 
            int MemberTypeId,int Gender, string Note,string Newsletter, string Email,string Password,int UserId, string Image,string ImagePath, int UpdatedBy, int CustomerId,string Address, int Age = 0)
        {
            try
            {

                MySqlCommand cmd1 = new MySqlCommand("update tblUsers set UserName='" + Email + "',Password='" + Password + "',Email='" + Email + "' where UserId='" + UserId + "' ", con);
                con.Open();
                cmd1.ExecuteNonQuery();


                MySqlCommand cmd = new MySqlCommand("update tblCustomers set UserId='" + UserId + "', FirstName='" + FirstName + "',PhoneNumber='" + PhoneNumber + "', LastName='" + LastName + "',ProfileName='" + ProfileName + "',PostalCode='" + PostalCode + "',MemberTypeId='" + MemberTypeId + "',Gender='" + Gender + "',Note=@Note,Newsletter='" + Newsletter + "',Email='" + Email + "',Password='" + Password + "' ,Image='" + Image + "',ImagePath='" + ImagePath + "' ,  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', Address='"+Address+"', Age = "+Age+" where CustomerId='" + CustomerId + "' ", con);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.ExecuteNonQuery();
                con.Close();

                obj.Add(new tblCustomers { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblCustomers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblCustomers> UpdateFECustomers(string PhoneNumber, string Email, string Password, int UserId, string Image, string ImagePath, int UpdatedBy, int CustomerId,string ProfileName,string PostalCode,string Address,int Gender,string FirstName,string LastName)
        {
            try
            {

                MySqlCommand cmd1 = new MySqlCommand("update tblUsers set UserName='" + Email + "',Password='" + Password + "' where UserId='" + UserId + "' ", con);
                con.Open();
                cmd1.ExecuteNonQuery();


                MySqlCommand cmd = new MySqlCommand("update tblCustomers set UserId='" + UserId + "', PhoneNumber='" + PhoneNumber + "',Email='" + Email + "',Password='" + Password + "' ,Image='" + Image + "',ImagePath='" + ImagePath + "' ,  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',ProfileName='"+ ProfileName + "',PostalCode='"+ PostalCode + "',Address='"+ Address + "',Gender="+Gender+ ",FirstName='"+ FirstName + "',LastName='"+ LastName + "' where CustomerId='" + CustomerId + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();

                obj.Add(new tblCustomers { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblCustomers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<tblCustomers> InsertCustomers(string FirstName, string LastName,string PhoneNumber, string ProfileName, string PostalCode,
            int MemberTypeId, int Gender, string Note, string Newsletter, string Email, string Password,string Image ,string ImagePath, int CreatedBy,string Address)
        
        {
            try
            {

                MySqlCommand cmd1 = new MySqlCommand("insert into tblUsers (Name,RoleId,UserName,MobileNumber,Password,Email,CreatedBy,CreatedDate,Status) values ('" + FirstName + "','" + 9 + "','" + Email + "', '" + PhoneNumber + "','" + Password + "','" + Email + "','" + CreatedBy + "' ,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1)", con);
                con.Open();
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("select UserId from tblUsers order by UserId DESC limit 1", con);
                MySqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                int UserId = Convert.ToInt32(dr["UserId"]);
                dr.Close();
                MySqlCommand cmd = new MySqlCommand("insert into tblCustomers(FirstName,LastName,ProfileName,PhoneNumber,PostalCode,MemberTypeId,Gender,Note,Newsletter,Email,Password,Image,ImagePath, UserId,IsActive,CreatedBy,CreatedDate,Address) values('" + FirstName + "','" + LastName + "', '" + ProfileName + "','" + PhoneNumber + "','" + PostalCode + "','" + MemberTypeId + "','" + Gender + "',@Note,'" + Newsletter + "','" + Email + "','" + Password + "','" + Image + "','" + ImagePath + "', '" + UserId + "', '" + 1 + "', '" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+Address+"')", con);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new tblCustomers { Message = "Success", UserId= UserId });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new tblCustomers { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else if (ex.Message.Contains("Duplicate"))
                {
                    obj.Add(new tblCustomers { Message = "Duplicate", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
        public IEnumerable<tblCustomers> GetCustomersBySearch(string prefix)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tblCustomers where ProfileName like '%" + prefix + "%' and IsActive=1", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj.Add(new tblCustomers
                    {
                        CustomerId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        Image = dt.Rows[i]["Image"].ToString(),
                        ImagePath = dt.Rows[i]["ImagePath"].ToString(),
                        FirstName = dt.Rows[i]["FirstName"].ToString(),
                        LastName = dt.Rows[i]["LastName"].ToString(),
                        PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                        PostalCode = dt.Rows[i]["PostalCode"].ToString(),
                        ProfileName = dt.Rows[i]["ProfileName"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Note = dt.Rows[i]["Note"].ToString(),
                        Password = dt.Rows[i]["Password"].ToString(),
                        Gender = Convert.ToInt32(dt.Rows[i]["Gender"]),
                        MemberTypeId = Convert.ToInt32(dt.Rows[i]["MemberTypeId"]),
                        CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                        Newsletter = dt.Rows[i]["Newsletter"].ToString(),
                        IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]),
                        UserId = Convert.ToInt32(dt.Rows[i]["UserId"]),
                        UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString(),
                        Message = "Success"
                    });
                }
                if (dt.Rows.Count == 0)
                {
                    obj.Add(new tblCustomers { Message = "NoData" });
                    return obj;
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }

        public IEnumerable<tblCustomers> DeleteCustomers(int CustomerId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblCustomers where CustomerId='" + CustomerId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new tblCustomers { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }


        public IEnumerable<tblCustomers> UpdateStatus(int IsActive, int UpdatedBy, int CustomerId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblCustomers set IsActive='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where CustomerId='" + CustomerId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("update tblUsers set Status='" + IsActive + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where UserId=(select UserId from tblCustomers where CustomerId='" + CustomerId + "') ", con);
                 cmd2.ExecuteNonQuery();

                obj.Add(new tblCustomers { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new tblCustomers { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }


        }



        //class for tblCustomers
        public class tblCustomers
        {
           
            public string customerProfileName { get; set; }
            public string customerPostcode { get; set; }
            public string customerEmail { get; set; }

            public string customerPassword { get; set; }
            public string custUserName { get; set; }
            public string custPhoneNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ProfileName { get; set; }
            public string PostalCode { get; set; }
            public int MemberTypeId { get; set; }
            public int Gender { get; set; }
            public int UserId { get; set; }
            public string Note { get; set; }
            public string Newsletter { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public int CustomerId { get; set; }
            public string UserName { get; set; }
            public int IsActive { get; set; }

            public string Message { get; set; }
            public string ErrorMessage { get; set; }
            public string PhoneNumber { get; set; }

            public string Image { get; set; }
            public string ImagePath { get; set; }
            public string Address { get;  set; }
        }

    }
}