using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class emailTemplateTypesController : ApiController
    {
        emailTemplateTypesDAL obj = new emailTemplateTypesDAL();
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> Getdata()
        {
            return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> GetdataTemplate()
        {
            return obj.GetdataTemplate();
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> GetdataTemplateIsActive()
        {
            return obj.GetdataTemplateIsActive();
        }

        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> GetbyId(int TemplateId)
        {
            return obj.GetbyId(TemplateId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> GetdatabyTemplateId(int TemplateTypeId)
        {
            return obj.GetdatabyTemplateId(TemplateTypeId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> Insert(string TemplateName,string Template, int IsActive, int CreatedBy, int TemplateTypeId)
        {
            return obj.Insert(TemplateName,Template, IsActive, CreatedBy, TemplateTypeId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> InsertTemplate(string TemplateType, int IsActive, int CreatedBy)
        {
            return obj.InsertTemplate(TemplateType, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> Update(string TemplateName, string Template, int UpdatedBy, int TemplateId, int TemplateTypeId)
        {
            return obj.Update(TemplateName,Template, UpdatedBy, TemplateId, TemplateTypeId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> UpdateTemplate(string TemplateType, int IsActive, int UpdatedBy, int TemplateTypeId)
        {
            return obj.UpdateTemplate(TemplateType, IsActive, UpdatedBy, TemplateTypeId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> Delete(int TemplateId)
        {
            return obj.Delete(TemplateId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> UpdateStatus(int Status, int UpdatedBy, int TemplateId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, TemplateId);
        }
        [HttpGet]
        public IEnumerable<emailTemplateTypesClass> UpdateTemplateStatus(int Status, int UpdatedBy, int TemplateTypeId)
        {
            return obj.UpdateTemplateStatus(Status, UpdatedBy, TemplateTypeId);
        }
        [HttpGet]
        public int SendEmail(string Email, string Mobile, string TemplateTypeId, string Content,string Name)
        {
            return obj.SendEmail(Email, Mobile, TemplateTypeId, Content,Name);
        }
    }
}
