using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
namespace SalonAPI.Models
{
    public class SalonEmployeesDAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbSalon"].ConnectionString);
        List<SalonEmployeesClass> obj = new List<SalonEmployeesClass>();
        public IEnumerable<SalonEmployeesClass> GetData()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ts.*,tbs.SalonsId from tblSalonEmployees ts,tblSalons tbs where ts.SalonsId=tbs.SalonsId ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonEmployeesClass
                    {
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        DOJ = dr["DOJ"].ToString(),
                        Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : Convert.ToInt32(dr["Age"]),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonEmployeesClass
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
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonEmployeesClass> GetDatabySalonsId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ts.*, tbs.SalonsId from tblSalonEmployees ts, tblSalons tbs where ts.SalonsId = tbs.SalonsId AND tbs.SalonsId='" + SalonsId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonEmployeesClass
                    {
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        DOJ = dr["DOJ"].ToString(),
                        Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : Convert.ToInt32(dr["Age"]),
                        Message = "Success",

                    });
                }
                if (!dr.HasRows)
                {
                    obj.Add(new SalonEmployeesClass
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
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonEmployeesClass> GetDatabyId(int SalonEmployeesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ts.*,tbs.SalonsId,date_format(ts.StartDate,'%m/%d/%Y') as StartDate1,date_format(ts.EndDate,'%m/%d/%Y') as EndDate1 from tblSalonEmployees ts,tblSalons tbs where ts.SalonsId=tbs.SalonsId and ts.SalonEmployeesId='" + SalonEmployeesId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonEmployeesClass
                    {
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        StartDate = dr["StartDate1"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate1"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        DOJ = dr["DOJ"].ToString(),
                        Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : Convert.ToInt32(dr["Age"]),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonEmployeesClass> GetLeavesByEmployeeId(int SalonEmployeesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct date_format(el.EndDate,'%m/%d/%Y') as EndDate1,date_format(el.StartDate,'%m/%d/%Y') as StartDate1,el.Comments,st.StartTime,et.EndTime from tblEmployeeLeaves el inner join tblStartTime st on el.StartTIme=st.StartTimeId inner join tblEndTime et on et.EndTimeId=el.EndTime where el.SalonEmployeesId='" + SalonEmployeesId + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonEmployeesClass
                    {
                      
                        StartDate = dr["StartDate1"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate1"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["Comments"].ToString(),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }


        public IEnumerable<SalonEmployeesClass> GetDataUserbyId(int SalonsId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select ts.*,tbs.SalonsId from tblSalonEmployees ts,tblSalons tbs where ts.SalonsId=tbs.SalonsId and ts.SalonsId='" + SalonsId + "'  ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new SalonEmployeesClass
                    {
                        SalonEmployeesId = Convert.ToInt32(dr["SalonEmployeesId"]),
                        EmployeeName = dr["EmployeeName"].ToString(),
                        PricingLevel = dr["PricingLevel"].ToString(),
                        JobTitle = dr["JobTitle"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        EndTime = dr["EndTime"].ToString(),
                        About = dr["About"].ToString(),
                        Image = dr["Image"].ToString(),
                        ImagePath = dr["ImagePath"].ToString(),
                        SalonsId = Convert.ToInt32(dr["SalonsId"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = dr["CreatedDate"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        DOJ = dr["DOJ"].ToString(),
                        Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : Convert.ToInt32(dr["Age"]),
                        Message = "Success",
                    });
                }
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("duplicate entry"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<SalonEmployeesClass> Insert(string EmployeeName, string PricingLevel, string JobTitle, string Phone, string Gender, string Email, string StartDate, string StartTime, string EndDate, string EndTime, string About, int SalonsId, string Image, string ImagePath, int IsActive, int CreatedBy, string DOB = null, string DOJ = null, int Age = 0)
        {
            try
            {
                StartDate = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd");
                EndDate = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd");
                MySqlCommand cmd = new MySqlCommand("insert into tblSalonEmployees(EmployeeName,PricingLevel,JobTitle,Phone,Gender,Email,StartDate,StartTime,EndDate,EndTime,About,SalonsId,Image,ImagePath,IsActive,CreatedBy,CreatedDate,DOB,DOJ,Age) values('" + EmployeeName + "','" + PricingLevel + "','" + JobTitle + "','" + Phone + "','" + Gender + "','" + Email + "','" + StartDate + "','" + StartTime + "','" + EndDate + "','" + EndTime + "','@About','" + SalonsId + "','" + Image + "','" + ImagePath + "','" + IsActive + "','" + CreatedBy + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + DOB + "','" + DOJ + "'," + Age + " )", con);
                con.Open();
                cmd.Parameters.AddWithValue("@About", About);
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.LastInsertedId);

                MySqlCommand cmd2 = new MySqlCommand("insert into tblEmployeeLeaves(StartDate, StartTime, EndDate, EndTime, SalonEmployeesId, Status, CreatedDate, CreatedBy, UpdatedDate, UpdatedBy,Comments)values('" + StartDate+"','"+StartTime+"', '"+EndDate+"', '"+EndTime+"', "+id+ ", 1,'"+ DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' , '"+ CreatedBy + "', '"+DateTime.Now.AddMinutes(750).ToString("yyyy - MM - dd hh: mm:ss")+"', '"+ CreatedBy + "','" + About + "')", con);
                cmd2.ExecuteNonQuery();


                MySqlCommand cmd1 = new MySqlCommand("select SalonEmployeesId from tblSalonEmployees order by SalonEmployeesId desc limit 1", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int SalonEmployeesId1 =Convert.ToInt32(dt.Rows[0]["SalonEmployeesId"]);
               

                obj.Add(new SalonEmployeesClass { Message = "Success", SalonEmployeesId = SalonEmployeesId1 });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else if (ex.Message.Contains("Duplicate"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "Duplicate", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonEmployeesClass> Update(string EmployeeName, string PricingLevel, string JobTitle, string Phone, string Gender, string Email, string StartDate, string StartTime, string EndDate, string EndTime, string About, int SalonsId, string Image, string ImagePath, int UpdatedBy, int SalonEmployeesId, string DOB = null, string DOJ = null, int Age = 0)
        {
            try
            {
              //  Convert.ToDateTime(DeliveryDate).ToString("yyyy-MM-dd HH:mm:ss")
                StartDate =Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd");
                EndDate =Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd");
                MySqlCommand cmd = new MySqlCommand("update tblSalonEmployees set EmployeeName='" + EmployeeName + "',PricingLevel='" + PricingLevel + "',JobTitle='" + JobTitle + "',Phone='" + Phone + "',Gender='" + Gender + "',Email='" + Email + "',StartDate='" + StartDate + "',StartTime='" + StartTime + "',EndDate='" + EndDate + "',EndTime='" + EndTime + "',About='@About',SalonsId='" + SalonsId + "',Image='" + Image + "',ImagePath='" + ImagePath + "',UpdatedBy='" + UpdatedBy + "', UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', DOB='" + DOB + "', DOJ='" + DOJ + "', Age=" + Age + " where SalonEmployeesId='" + SalonEmployeesId + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@About",About);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("insert into tblEmployeeLeaves(StartDate, StartTime, EndDate, EndTime, SalonEmployeesId, Status, CreatedDate, CreatedBy, UpdatedDate, UpdatedBy,Comments)values('" + StartDate + "','" + StartTime + "', '" + EndDate + "', '" + EndTime + "', " + SalonEmployeesId + ", 1,'" + DateTime.Now.AddMinutes(750).ToString("yyyy-MM-dd hh:mm:ss") + "' , '" + UpdatedBy + "', '" + DateTime.Now.AddMinutes(750).ToString("yyyy - MM - dd hh: mm:ss") + "', '" + UpdatedBy + "','" + About + "')", con);
                cmd2.ExecuteNonQuery();


                obj.Add(new SalonEmployeesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<SalonEmployeesClass> Delete(int SalonEmployeesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from tblSalonEmployees where SalonEmployeesId='" + SalonEmployeesId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                obj.Add(new SalonEmployeesClass { Message = "Success" });
                return obj;
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                {
                    obj.Add(new SalonEmployeesClass { Message = "UniqueConstraint", ErrorMessage = ex.Message });
                    return obj;
                }
                else
                {
                    obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                    return obj;
                }

            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
            finally
            {
                con.Close();
            }

        }
        public IEnumerable<SalonEmployeesClass> UpdateStatus(int Status, int UpdatedBy, int SalonEmployeesId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tblSalonEmployees set IsActive='" + Status + "',  UpdatedBy='" + UpdatedBy + "',UpdatedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString() + "' where SalonEmployeesId='" + SalonEmployeesId + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                obj.Add(new SalonEmployeesClass { Message = "Success" });
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(new SalonEmployeesClass { Message = "Error", ErrorMessage = ex.Message });
                return obj;
            }
        }
    }
    public class SalonEmployeesClass
    {
        public int SalonEmployeesId { get; set; }
        public string EmployeeName { get; set; }
        public string PricingLevel { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }
        public int SalonsId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdateBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public int Age { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}