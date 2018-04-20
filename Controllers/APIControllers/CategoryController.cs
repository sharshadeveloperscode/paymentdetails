using SalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SalonAPI.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryDAL Obj = new CategoryDAL();

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> InsertCategory(string Category, string ImageName, string ImagePath, int CreatedBy)
        {
            return Obj.InsertCategory(Category,ImageName,ImagePath, CreatedBy);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> UpdateCategory(string Category, string ImageName, string ImagePath, int UpdatedBy, int CategoryId)
        {
            return Obj.UpdateCategory(Category, ImageName, ImagePath, UpdatedBy, CategoryId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> DeleteCategory(int CategoryId)
        {
            return Obj.DeleteCategory(CategoryId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> GetCategoryById(int CategoryId)
        {
            return Obj.GetCategoryById(CategoryId);
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> GetCategory()
        {
            return Obj.GetCategory();
        }

        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> UpdateStatus(int Status, int UpdatedBy, int CategoryId)
        {
            return Obj.UpdateStatus(Status, UpdatedBy, CategoryId);
        }
        [HttpGet]
        public IEnumerable<SalonAPI.Models.CategoryDAL.tblCategory> GetCategoryByIsActive()
        {
            return Obj.GetCategoryByIsActive();
        }
    }
}
