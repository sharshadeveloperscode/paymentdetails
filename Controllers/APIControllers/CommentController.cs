using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;

namespace SalonAPI.Controllers
{
    public class CommentController : ApiController
    {
        CommentDAL obj = new CommentDAL();
        [HttpGet]
        public IEnumerable<tblComment> Getdata()
        {
            return obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<tblComment> GetComments(int SalonReviewsId)
        {
            return obj.GetComments(SalonReviewsId);
        }
        [HttpGet]
        public IEnumerable<tblComment> Insert(int SalonReviewsId, string Comment, int CreatedBy)
        {
            return obj.Insert(SalonReviewsId, Comment, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<tblComment> Update(int CommentId, int SalonReviewsId, string Comment)
        {
            return obj.Update(CommentId, SalonReviewsId, Comment);
        }


        [HttpGet]
        public IEnumerable<tblComment> Delete(int SalonServicesId)
        {
            return obj.Delete(SalonServicesId);
        }
        [HttpGet]
        public IEnumerable<tblComment> UpdateStatus(int IsActive, int UpdatedBy, int CommentId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, CommentId);
        }
        [HttpGet]
        public IEnumerable<tblComment> GetdataBySalonReviewsId(int SalonReviewsId)
        {
            return obj.GetdataBySalonReviewsId(SalonReviewsId);
        }
       
    }
}
