using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Hosting;
using System.Web.Mvc;

namespace HRM_Backend.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

       

     [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadCategoryImages()
     {
         string _imgname = string.Empty;
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
             if (pic.ContentLength > 0)
             {
                 DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/"));

                 //  foreach (FileInfo file in di.GetFiles())
                 //  {
                 //     file.Delete();
                 //  }

                 var fileName = Path.GetFileName(pic.FileName);
                 var _ext = Path.GetExtension(pic.FileName);

                 _imgname = Guid.NewGuid().ToString();
                 _imgname = _imgname + _ext;
                 var _comPath = Server.MapPath("/Files/") + _imgname;


                 ViewBag.Msg = _comPath;
                 var path = _comPath;

                 if (System.IO.File.Exists(path))
                 {
                     System.IO.File.Delete(path);
                 }

                 // Saving Image in Original Mode
                 pic.SaveAs(path);

                 //// resizing image
                 //MemoryStream ms = new MemoryStream();
                 //WebImage img = new WebImage(_comPath);

                 //if (img.Width > 200)
                 //    img.Resize(200, 200);
                 //img.Save(_comPath);
                 //// end resize
             }
         }
         return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
     }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadTreatmentTitleImages()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/"));

                    //  foreach (FileInfo file in di.GetFiles())
                    //  {
                    //     file.Delete();
                    //  }

                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    _imgname = _imgname + _ext;
                    var _comPath = Server.MapPath("/Files/") + _imgname;


                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    //// resizing image
                    //MemoryStream ms = new MemoryStream();
                    //WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //img.Save(_comPath);
                    //// end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
     public JsonResult SaveSalonDisplayImages()
     {
         string _imgname = string.Empty;
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
             if (pic.ContentLength > 0)
             {
                 DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/SalonDisplayImages/"));

                 //  foreach (FileInfo file in di.GetFiles())
                 //  {
                 //     file.Delete();
                 //  }

                 var fileName = Path.GetFileName(pic.FileName);
                 var _ext = Path.GetExtension(pic.FileName);

                 _imgname = Guid.NewGuid().ToString();
                 _imgname = _imgname + _ext;
                 var _comPath = Server.MapPath("/Files/SalonDisplayImages/") + _imgname;


                 ViewBag.Msg = _comPath;
                 var path = _comPath;

                 if (System.IO.File.Exists(path))
                 {
                     System.IO.File.Delete(path);
                 }

                 // Saving Image in Original Mode
                 pic.SaveAs(path);

                 //// resizing image
                 //MemoryStream ms = new MemoryStream();
                 //WebImage img = new WebImage(_comPath);

                 //if (img.Width > 200)
                 //    img.Resize(200, 200);
                 //img.Save(_comPath);
                 //// end resize
             }
         }
         return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
     }





     [AcceptVerbs(HttpVerbs.Post)]
     public JsonResult UploadSalonEmolyeesImages()
     {
         string _imgname = string.Empty;
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
             if (pic.ContentLength > 0)
             {
                 DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/SalonEmployeesImages/"));

                 //  foreach (FileInfo file in di.GetFiles())
                 //  {
                 //     file.Delete();
                 //  }

                 var fileName = Path.GetFileName(pic.FileName);
                 var _ext = Path.GetExtension(pic.FileName);

                 _imgname = Guid.NewGuid().ToString();
                 _imgname = _imgname + _ext;
                 var _comPath = Server.MapPath("/Files/SalonEmployeesImages/") + _imgname;


                 ViewBag.Msg = _comPath;
                 var path = _comPath;

                 if (System.IO.File.Exists(path))
                 {
                     System.IO.File.Delete(path);
                 }

                 // Saving Image in Original Mode
                 pic.SaveAs(path);

                 //// resizing image
                 //MemoryStream ms = new MemoryStream();
                 //WebImage img = new WebImage(_comPath);

                 //if (img.Width > 200)
                 //    img.Resize(200, 200);
                 //img.Save(_comPath);
                 //// end resize
             }
         }
         return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
     }




     [AcceptVerbs(HttpVerbs.Post)]
     public JsonResult UploadSalonImages()
     {
         string _imgname = string.Empty;
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
             if (pic.ContentLength > 0)
             {
                 DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/SalonImages/"));

                 //  foreach (FileInfo file in di.GetFiles())
                 //  {
                 //     file.Delete();
                 //  }

                 var fileName = Path.GetFileName(pic.FileName);
                 var _ext = Path.GetExtension(pic.FileName);

                 _imgname = Guid.NewGuid().ToString();
                 _imgname = _imgname + _ext;
                 var _comPath = Server.MapPath("/Files/SalonImages/") + _imgname;


                 ViewBag.Msg = _comPath;
                 var path = _comPath;

                 if (System.IO.File.Exists(path))
                 {
                     System.IO.File.Delete(path);
                 }

                 // Saving Image in Original Mode
                 pic.SaveAs(path);

                 //// resizing image
                 //MemoryStream ms = new MemoryStream();
                 //WebImage img = new WebImage(_comPath);

                 //if (img.Width > 200)
                 //    img.Resize(200, 200);
                 //img.Save(_comPath);
                 //// end resize
             }
         }
         return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
     }


        //Test Images For Testing purpose
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadTestImages()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/TestImages/"));

                    //  foreach (FileInfo file in di.GetFiles())
                    //  {
                    //     file.Delete();
                    //  }

                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    _imgname = _imgname + _ext;
                    var _comPath = Server.MapPath("/Files/TestImages/") + _imgname;


                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    //// resizing image
                    //MemoryStream ms = new MemoryStream();
                    //WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //img.Save(_comPath);
                    //// end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }
        // Coupen Images

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CoupenImages()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/CoupenImages/"));

                    //  foreach (FileInfo file in di.GetFiles())
                    //  {
                    //     file.Delete();
                    //  }

                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    _imgname = _imgname + _ext;
                    var _comPath = Server.MapPath("/Files/CoupenImages/") + _imgname;


                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    //// resizing image
                    //MemoryStream ms = new MemoryStream();
                    //WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //img.Save(_comPath);
                    //// end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }







        [AcceptVerbs(HttpVerbs.Post)]
     public JsonResult CustomerProfileImages()
     {
         string _imgname = string.Empty;
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
             if (pic.ContentLength > 0)
             {
                 DirectoryInfo di = new DirectoryInfo(Server.MapPath("/Files/CustomerProfileImages/"));

                 //  foreach (FileInfo file in di.GetFiles())
                 //  {
                 //     file.Delete();
                 //  }

                 var fileName = Path.GetFileName(pic.FileName);
                 var _ext = Path.GetExtension(pic.FileName);

                 _imgname = Guid.NewGuid().ToString();
                 _imgname = _imgname + _ext;
                 var _comPath = Server.MapPath("/Files/CustomerProfileImages/") + _imgname;


                 ViewBag.Msg = _comPath;
                 var path = _comPath;

                 if (System.IO.File.Exists(path))
                 {
                     System.IO.File.Delete(path);
                 }

                 // Saving Image in Original Mode
                 pic.SaveAs(path);

                 //// resizing image
                 //MemoryStream ms = new MemoryStream();
                 //WebImage img = new WebImage(_comPath);

                 //if (img.Width > 200)
                 //    img.Resize(200, 200);
                 //img.Save(_comPath);
                 //// end resize
             }
         }
         return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
     }
      

    }
}