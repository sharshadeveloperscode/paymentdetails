using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace Salon.Controllers.AdminControllers
{
    public class SalonController : Controller
    {

        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Testing()
        {
            return View();
        }
        public ActionResult RolesList()
        {
            return View();
        }
        public ActionResult Roles()
        {
            return View();
        }
        public ActionResult StartPage()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult UsersList()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult PageList()
        {
            return View();
        }
        public ActionResult UserPermissions()
        {
            return View();
        }
        public ActionResult UnAuthorization()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult CustomersList()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

        public ActionResult SalonsList()
        {
            return View();
        }

        public ActionResult Salons()
        {
            return View();
        }


        public ActionResult TreatmentTitle()
        {
            return View();
        }

        public ActionResult TreatmentTitleList()
        {
            return View();
        }

        public ActionResult City()
        {
            return View();
        }
        public ActionResult CityList()
        {
            return View();
        }
        public ActionResult VoucherType()
        {
            return View();
        }
        public ActionResult VoucherTypeList()
        {
            return View();
        }
        public ActionResult Area()
        {
            return View();
        }
        public ActionResult AreaList()
        {
            return View();
        }
        public ActionResult MemberType()
        {
            return View();
        }
        public ActionResult MemberTypeList()
        {
            return View();
        }
        public ActionResult BusinessType()
        {
            return View();
        }
        public ActionResult BusinessTypeList()
        {
            return View();
        }
        public ActionResult ManageYourBookings()
        {
            return View();
        }
        public ActionResult ManageYourBookingsList()
        {
            return View();
        }
        public ActionResult Signingup()
        {
            return View();
        }
        public ActionResult SigningupList()
        {
            return View();
        }
        public ActionResult TreatmentType()
        {
            return View();
        }
        public ActionResult TreatmentTypeList()
        {
            return View();
        }
        public ActionResult emailTemplateTypes()
        {
            return View();
        }
        public ActionResult emailTemplateTypesList()
        {
            return View();
        }
        public ActionResult EmailType()
        {
            return View();
        }
        public ActionResult EmailTypeList()
        {
            return View();
        }
        public ActionResult SalonDetails()
        {
            return View();
        }
        public ActionResult OpeningHours()
        {
            return View();
        }



        public ActionResult CategoryList()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult StartTime()
        {
            return View();
        }
        public ActionResult StartTimeList()
        {
            return View();
        }
        public ActionResult EndTime()
        {
            return View();
        }
        public ActionResult EndTimeList()
        {
            return View();
        }
        public ActionResult CleanUpTime()
        {
            return View();
        }
        public ActionResult CleanUpTimeList()
        {
            return View();
        }
        public ActionResult PricingType()
        {
            return View();
        }
        public ActionResult PricingTypeList()
        {
            return View();
        }
        public ActionResult Duration()
        {
            return View();
        }
        public ActionResult DurationList()
        {
            return View();
        }
        public ActionResult SalonServices()
        {
            return View();
        }
        public ActionResult SalonServicesList()
        {
            return View();
        }

        public ActionResult SalonEmployeesList()
        {
            return View();
        }

        public ActionResult SalonEmployees()
        {
            return View();
        }

        public ActionResult BusinessDashboard()
        {
            return View();
        }
        public ActionResult SalonBookingdetails()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }
        public ActionResult Comment()
        {
            return View();
        }
        public ActionResult SalonComment()
        {
            return View();
        }
        public ActionResult AdminScheduler()
        {
            return View();
        }
        public ActionResult SalonsScheduler()
        {
            return View();
        }
        public ActionResult AddScheduler()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult NewsLetterList()
        {
            return View();
        }
        public ActionResult Billings()
        {
            return View();
        }
        public ActionResult BookingCancellations()
        {
            return View();
        }
        public ActionResult TodayBookings()
        {
            return View();
        }
        public ActionResult AdminTodayBookings()
        {
            return View();
        }
        public ActionResult AdminBookingCancellations()
        {
            return View();
        }
        public ActionResult OldCustomers()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }
        public ActionResult ActualBookings()
        {
            return View();
        }
        public ActionResult Clients()
        {
            return View();
        }
        public ActionResult AddClients()
        {
            return View();
        }
        public ActionResult SalesReports()
        {
            return View();
        }

        public ActionResult AdminInvoice()
        {
            return View();
        }

        public ActionResult SalonInvoice()
        {
            return View();
        }
        public ActionResult Discount()
        {
            return View();
        }
        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        public ActionResult HtmlCreate(string mydata)
        {
            //string testing = form["test"].ToString();
            var data = System.AppDomain.CurrentDomain.BaseDirectory + "/tcpdf/examples/invoice.html";
            using (StreamWriter sw = System.IO.File.CreateText(data))
            {
                sw.WriteLine(mydata);
            }

            return Redirect("http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php");

            //Request.RawUrl= "http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php";
            //return RedirectToAction("SalonInvoice");
            // return Json(new { url = "http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php" });
            //  return Redirect("http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php");
            //  returnRedirect("http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php");
            //window.location.href = "http://hogarbarber.developerscode.in/tcpdf/examples/appypdf.php";

        }

        public ActionResult Schedular()
        {
            return View();
        }

        public ActionResult MyCalendar()
        {
            return View();
        }

        public ActionResult Translate()
        {
            return View();
        }

        public ActionResult FullCalender()
        {
            return View();
        }

        public ActionResult FullC()
        {
            return View();
        }

        public ActionResult SalonSchedular()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult GiftCoupon()
        {
            return View();
        }
        public ActionResult AdminBilling()
        {
            return View();
        }

        public ActionResult SalonFullCalendar()
        {
            return View();
        }
        public ActionResult ClassesList()
        {
            return View();
        }
        public ActionResult Classes()
        {
            return View();
        }
        public ActionResult UploadImage(HttpPostedFileBase hpfb)
        {
            var FileName = Path.GetFileName(hpfb.FileName);
            var path = Path.Combine(Server.MapPath("~/Files/ServiceImages"), FileName);
            return View();
        }

        public ActionResult ServiceReviews()
        {
            return View();
        }

        public ActionResult SalonReviews()
        {
            return View();
        }

    }
}
