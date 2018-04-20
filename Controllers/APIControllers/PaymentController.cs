using System.Collections.Generic;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class PaymentController : ApiController
    {
        PaymentDAL obj = new PaymentDAL();
        [HttpGet]
         public IEnumerable<PaymentClass> GetData()
        {
            return obj.GetData();
        }
        [HttpGet]
        public IEnumerable<PaymentClass> GetDatabyId(int PaymentsId)
        {
            return obj.GetDatabyId(PaymentsId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> Insert( int UserId, string PaymentType,string PaymentStatus, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(UserId, PaymentType, PaymentStatus, IsAcitve, CreatedBy);
        }
        [HttpGet]
         public IEnumerable<PaymentClass> Update(int BookingsId, int UserId, string PaymentType, string PaymentStatus,int IsActive, int UpdatedBy, int PaymentsId)
        {
            return obj.Update(UserId, PaymentType, PaymentStatus,IsActive, UpdatedBy, PaymentsId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> UpdateNew(int UserId, string PaymentType, string PaymentStatus, int IsActive, int PaymentsId, int Isthisforyou, string ReferenceName, string OriginalAmount, string DiscountAmount, string PayableAmount, string CouponCode, int VoucherTypeId)
        {
            return obj.UpdateNew(UserId, PaymentType, PaymentStatus, IsActive, PaymentsId, Isthisforyou, ReferenceName, OriginalAmount, DiscountAmount, PayableAmount, CouponCode, VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> Delete(int PaymentsId)
        {
            return obj.Delete(PaymentsId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> UpdateStatus(int IsActive, int UpdatedBy, int PaymentsId)
        {
            return obj.UpdateStatus(IsActive, UpdatedBy, PaymentsId);
        }

        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPayments()
        {
            return obj.GetAllPayments();
        }
        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPaymentsBySalonsIdId(int SalonsId)
        {
            return obj.GetAllPaymentsBySalonsIdId(SalonsId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPaymentsByPaymentsId(int PaymentsId)
        {
            return obj.GetAllPaymentsByPaymentsId(PaymentsId);
        }

        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPaymentsByUserId(int UserId)
        {
            return obj.GetAllPaymentsByUserId(UserId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPaymentsByUserIdAndSaloncheckoutId(int UserId, int SalonCheckoutId)
        {
            return obj.GetAllPaymentsByUserIdAndSaloncheckoutId(UserId, SalonCheckoutId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> Complete(string PaymentStatus, int IsActive, int UpdatedBy, int PaymentsId, int SalonCheckoutId)
        {
            return obj.Complete(PaymentStatus, IsActive, UpdatedBy, PaymentsId, SalonCheckoutId);
        }
        [HttpGet]
        public IEnumerable<PaymentClass> GetAllPaymentsByUser(int UserId)
        {
            return obj.GetAllPaymentsByUser(UserId);
        }

        [HttpGet]
        public IEnumerable<PaymentClass> UpdateServicePrices(string Price, int Serviceid, int PaymentsId)
        {
            return obj.UpdateServicePrices(Price,Serviceid,PaymentsId);
        }

        [HttpGet]
        public IEnumerable<PaymentClass> GetOrderbyUserId(int UserId)
        {
            return obj.GetOrderbyUserId(UserId);
        }

        [HttpGet]
        public IEnumerable<PaymentClass> GetBookingDetailsByPaymentId(int PaymentsId)
        {
            return obj.GetBookingDetailsByPaymentId(PaymentsId);
        }
    }
}
