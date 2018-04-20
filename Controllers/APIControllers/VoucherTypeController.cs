using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalonAPI.Models;
namespace SalonAPI.Controllers
{
    public class VoucherTypeController : ApiController
    {
        VoucherTypeDAL obj = new VoucherTypeDAL();
        [HttpGet]
        public IEnumerable<VoucherTypeClass> Getdata()
        {
          return  obj.Getdata();
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> GetGiftCoupons()
        {
            return obj.GetGiftCoupons();
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> TotalSalonsIsActive()
        {
            return obj.TotalSalonsIsActive();
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> CoupenApplicable(string CouponCode,  string Salons, string Email)
        {
            return obj.CoupenApplicable(CouponCode, Salons, Email);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> GiftCouponApplicable(string CouponCode, string Email)
        {
            return obj.GiftCouponApplicable(CouponCode, Email);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> GetbyId(int VoucherId)
        {
            return obj.GetbyId(VoucherId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> Insert(string VoucherTypeName, int IsAcitve, int CreatedBy)
        {
            return obj.Insert(VoucherTypeName, IsAcitve, CreatedBy);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> InsertNew(string CouponName, string CouponCode, string FromDate, string ToDate, int DiscountAmount, string Salons, string Image, string ImagePath, string Description, int IsActive, int CreatedBy,int MinimumAmount)
        {
            return obj.InsertNew(CouponName, CouponCode, FromDate, ToDate, DiscountAmount, Salons, Image, ImagePath, Description, IsActive, CreatedBy, MinimumAmount);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> Update(string VoucherTypeName, int UpdatedBy, int VoucherTypeId)
        {
            return obj.Update(VoucherTypeName, UpdatedBy, VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> UpdateVoucherCoupon(int VoucherTypeId)
        {
            return obj.UpdateVoucherCoupon(VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> UpdateNew(string CouponName, string CouponCode, string FromDate, string ToDate, int DiscountAmount, string Salons, string Image, string ImagePath, string Description, int IsActive, int UpdatedBy, int MinimumAmount, int VoucherTypeId)
        {
            return obj.UpdateNew(CouponName, CouponCode, FromDate, ToDate, DiscountAmount, Salons, Image, ImagePath, Description, IsActive, UpdatedBy, MinimumAmount, VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> Delete(int VoucherTypeId)
        {
            return obj.Delete(VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> UpdateStatus(int Status, int UpdatedBy, int VoucherTypeId)
        {
            return obj.UpdateStatus(Status, UpdatedBy, VoucherTypeId);
        }
        [HttpGet]
        public IEnumerable<VoucherTypeClass> UpdateVoucherStatus(int UserId, int VoucherTypeId)
        {
            return obj.UpdateVoucherStatus(UserId, VoucherTypeId);
        }

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<VoucherTypeClass> insertGiftVoucher(int Amount, string Quantity, string Email, string Address, int TotalAmount, int UserId, int Status, int CreatedBy, string Description, string PaymentStatus, int IsActive, string PaymentType)
        {
            return obj.insertGiftVoucher( Amount,  Quantity,  Email,  Address,  TotalAmount,  UserId,  Status,  CreatedBy,  Description,  PaymentStatus,  IsActive,  PaymentType);
        }


        [AcceptVerbs("GET", "POST")]
        public IEnumerable<VoucherTypeClass> UpdateGiftVoucher(int UserId,  int Status, int UpdatedBy, string PaymentStatus, int IsActive, string PaymentType, int VoucherTypeId, string OriginalAmount, string DiscountAmount, string PayableAmount, string CouponCode, int PaymentsId)
        {
            return obj.UpdateGiftVoucher( UserId,  Status,  UpdatedBy,  PaymentStatus,  IsActive,  PaymentType,  VoucherTypeId,  OriginalAmount,  DiscountAmount,  PayableAmount,  CouponCode,PaymentsId);
        }

    }
}
