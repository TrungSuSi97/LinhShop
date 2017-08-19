using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface IOrderRepository
    {
        long Insert(OrderModel model);
        bool Delete(OrderModel model);
        bool Update(OrderModel model);
        IQueryable<OrderModel> GetOrders();
        OrderModel GetOrderById(long id);
        List<OrderDetailModel> GetOrderDetailById(long id);
        IQueryable<OrderDetailModel> GetOrderDetails();

        bool Insert(OrderDetailModel orderDetail);
    }
}
