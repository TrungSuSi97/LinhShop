using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using System.Data.Entity;
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly MainContext _context;

        public CouponsRepository(MainContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var existedCoupons = _context.Coupons.Where(x => x.Id == id).FirstOrDefault();

            if (existedCoupons != null)
            {
                _context.Coupons.Remove(existedCoupons);
                return _context.SaveChanges() > 0;
            }

            return false;
        }

        public IQueryable<CouponModel> GetListCoupons()
        {
            return _context.Coupons.Where(x => x.IsDeleted == false)
                .Select(x => new CouponModel
                {
                    Id = x.Id,
                    CreateBy = x.CreateBy,
                    CreatedDate = x.CreatedDate,
                    LastModifiedBy = x.LastModifiedBy,
                    CouponsCode = x.CouponsCode,
                    Reason = x.Reason,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    SendEmail = x.SendEmail,
                    Email = x.Email,
                    UserName = x.UserName,
                    DiscountPercent = x.DiscountPercent
                });
        }

        public bool InsertOrUpdate(CouponModel couponModel)
        {
            var existed = _context.Coupons.Where(x => x.Id == couponModel.Id).FirstOrDefault();
            if (existed != null)
            {
                existed.CreateBy = couponModel.CreateBy;
                existed.LastModifiedBy = couponModel.LastModifiedBy;
                existed.CouponsCode = couponModel.CouponsCode;
                existed.Reason = couponModel.Reason;
                existed.FromDate = couponModel.FromDate;
                existed.ToDate = couponModel.ToDate;
                existed.UserName = couponModel.UserName;
                existed.Email = couponModel.Email;
                existed.SendEmail = couponModel.SendEmail;
                existed.DiscountPercent = couponModel.DiscountPercent;
                _context.Entry(existed).State = EntityState.Modified;
            }
            else
            {
                var newCoupon = new Coupons
                {
                    CreatedDate = DateTime.Now,
                    CreateBy = couponModel.CreateBy,
                    LastModifiedBy = couponModel.LastModifiedBy,
                    CouponsCode = couponModel.CouponsCode,
                    Reason = couponModel.Reason,
                    FromDate = couponModel.FromDate,
                    ToDate = couponModel.ToDate,
                    Email = couponModel.Email,
                    UserName = couponModel.UserName,
                    SendEmail = couponModel.SendEmail,
                    DiscountPercent = couponModel.DiscountPercent
                };
                _context.Coupons.Add(newCoupon);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
