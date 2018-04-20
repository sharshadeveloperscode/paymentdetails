using System.Collections.Generic;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class SalonReviewsController : ApiController
    {
        SalonReviewsDAL obj = new SalonReviewsDAL();
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetUserReviews(int UserId)
        {
            return obj.GetUserReviews(UserId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetAvgRatings(int SalonsId)
        {
            return obj.GetAvgRatings(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetRatingsCount(int SalonsId)
        {
            return obj.GetRatingsCount(SalonsId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetDatabyId(int SalonReviewsId)
        {
            return obj.GetDatabyId(SalonReviewsId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> Insert(int SalonsId, int UserId, string TreatmnetRating, string Comment, int IsActive, int CreatedBy)
        {
            return obj.Insert(SalonsId, UserId, TreatmnetRating, Comment, IsActive, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> InsertSalonReviews(int SalonsId, int UserId, string Comment, decimal OverallSatisfaction, string Type, string SalonServiceId, string EmployeeId)
        {
            return obj.InsertSalonReviews(SalonsId, UserId, Comment, OverallSatisfaction, Type, SalonServiceId, EmployeeId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> InsertServiceReviews(string ServiceTitle, decimal ServiceRating, int SalonsId, int UserId, int SalonReviewsId, int IsActive, int CreatedBy, int SalonServicesId)
        {
            return obj.InsertServiceReviews(ServiceTitle, ServiceRating, SalonsId, UserId, SalonReviewsId, IsActive, CreatedBy, SalonServicesId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> Update(int SalonsId, int UserId, string TreatmnetRating, string Comment, int UpdatedBy, int SalonReviewsId)
        {
            return obj.Update(SalonsId, UserId, TreatmnetRating, Comment, UpdatedBy, SalonReviewsId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> UpdateStatus(int IsActive, int UpdatedBy, int SalonReviewsId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, SalonReviewsId);
        }
        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetDatabySalonsId(int SalonsId)
        {
            return obj.GetDatabySalonsId(SalonsId);
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetReviewByServiceId(int SalonServicesId)
        {
            return obj.GetReviewByServiceId(SalonServicesId);
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetReviewByEmployeeId(int EmployeeId)
        {
            return obj.GetReviewByEmployeeId(EmployeeId);
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetSalonReviews()
        {
            return obj.GetSalonReviews();
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetSalonReviewsById(int SalonsId)
        {
            return obj.GetSalonReviewsById(SalonsId);
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetServicesReviewBySalonsId(int SalonsId)
        {
            return obj.GetServicesReviewBySalonsId(SalonsId);
        }

        [HttpGet]
        public IEnumerable<SalonReviewsClass> GetEmployeeReviewBySalonsId(int SalonsId)
        {
            return obj.GetEmployeeReviewBySalonsId(SalonsId);
        }
    }
}
