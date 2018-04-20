using Salon.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Salon.Controllers.APIControllers
{
    public class ClassesApiController : ApiController
    {
        ClassesDAL obj = new ClassesDAL();

        [AcceptVerbs("GET", "POST")]
        public string SaveClass(string ClassName, int UserId)
        {
            return obj.SaveClass(ClassName, UserId);
        }

        [AcceptVerbs("GET", "POST")]
        public string UpdateClass(string ClassName, int UserId, int ClassId)
        {
            return obj.UpdateClass(ClassName, UserId, ClassId);
        }

        [AcceptVerbs("GET", "POST")]
        public string UpdateClassStatus(int Status, int ClassId)
        {
            return obj.UpdateClassStatus(Status, ClassId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblClasses> GetClasses()
        {
            return obj.GetClasses();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblClasses> GetActiveClasses()
        {
            return obj.GetActiveClasses();
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<tblClasses> GetClassById(int ClassId)
        {
            return obj.GetClassById(ClassId);
        }
    }
}
