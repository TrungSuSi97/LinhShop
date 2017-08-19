using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface ICouponsRepository
    {
        IQueryable<CouponModel> GetListCoupons();
        bool InsertOrUpdate(CouponModel couponModel);
        bool Delete(int id);
    }
}
