using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MainContext _context;

        public OrderRepository(MainContext context)
        {
            _context = context;
        }
        public bool Delete(OrderModel model)
        {
            try
            {
                var existedOrder = _context.Orders.Where(x => x.Id == model.Id).FirstOrDefault();
                if (existedOrder != null)
                {
                    _context.Orders.Remove(existedOrder);
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public OrderModel GetOrderById(long id)
        {
            try
            {
                var existedOrder = _context.Orders.Where(x => x.IsDeleted == false && x.Id == id)
                     .Select(x => new OrderModel
                     {
                         Id = x.Id,
                         FullName = x.FullName,
                         UserName = x.User.UserName,
                         Email = x.User.Email,
                         LastModifiedBy = x.LastModifiedBy,
                         CreateBy = x.CreateBy,
                         IsCharge = x.IsCharged,
                         CreatedDate = x.CreatedDate,
                         OrderCode = x.OrderCode,
                         CodeDiscount = x.CodeDiscount,
                         TotalMoney = x.TotalMoney,
                         Discount = x.Discount,
                         Quantity = x.Quantity,
                         TotalPoint = x.User.Point,
                         PointUsed = x.PointUsed,
                         IsSendToGhn = x.IsSendToGhn,
                         ServiceId = x.ServiceId,
                         Phone = x.Phone,
                         Address = x.Address,       
                         Note = x.Note
                     }).FirstOrDefault();

                if (existedOrder != null)
                {
                    var detail = _context.OrderDetails
                    .Include(d => d.Product)
                    .Where(x => x.IsDeleted == false && x.OrderId == id).ToList();
                    if (detail.Any())
                    {
                        existedOrder.OrderDetails = detail.Select(x => new OrderDetailModel
                        {
                            Id = x.Id,
                            TotalMoney = x.TotalMoney,
                            UserId = existedOrder.UserId,
                            CreateBy = x.CreateBy,
                            Color = x.Product.Color,
                            Description = x.Product.Description,
                            Discount = x.Product.Discount.Value,
                            Cost = x.Product.Cost.Value,
                            ProductCode = x.Product.Code,
                            ProductId = x.Product.ProductId,
                            ProductName = x.Product.ProductName,
                            Quantity = x.Quantity,
                            Size = x.Product.Size
                        }).ToList();
                    }
                }

                return existedOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<OrderDetailModel> GetOrderDetailById(long id)
        {
            return _context.OrderDetails.Where(x => x.OrderId == id && x.IsDeleted == false)
                .Select(x => new OrderDetailModel
                {
                    Color = x.Product.Color,
                    CreatedDate = x.CreatedDate,
                    Description = x.Product.Description,
                    Cost = x.Product.Cost.Value,
                    Discount = x.Product.Discount.Value,
                    Id = x.Id,
                    ProductCode = x.Product.Code,
                    ProductName = x.Product.ProductName,
                    Quantity = x.Quantity,
                    Size = x.Product.Size,
                    TotalMoney = x.TotalMoney
                }).ToList();
        }

        public IQueryable<OrderDetailModel> GetOrderDetails()
        {
            return _context.OrderDetails.Where(x => x.IsDeleted == false)
                 .Select(x => new OrderDetailModel
                 {
                     Color = x.Product.Color,
                     CreatedDate = x.CreatedDate,
                     Description = x.Product.Description,
                     Cost = x.Product.Cost.Value,
                     Id = x.Id,
                     ProductCode = x.Product.Code,
                     ProductName = x.Product.ProductName,
                     ProductId = x.Product.ProductId,
                     Quantity = x.Quantity,
                     Size = x.Product.Size,
                     TotalMoney = x.TotalMoney,
                     Like = x.Product.NumLike
                 });
        }

        public IQueryable<OrderModel> GetOrders()
        {
            return _context.Orders.Include(d => d.User)
                .Where(x => x.IsDeleted == false)
                .Select(x => new OrderModel
                {
                    Id = x.Id,
                    UserName  = x.User.UserName,
                    UserId = x.UserId,
                    Email = x.User.Email,
                    LastModifiedBy = x.LastModifiedBy,
                    CreateBy = x.CreateBy,
                    IsCharge = x.IsCharged,
                    CreatedDate = x.CreatedDate,
                    OrderCode = x.OrderCode,
                    CodeDiscount = x.CodeDiscount,
                    TotalMoney = x.TotalMoney,
                    Discount = x.Discount,
                    Quantity = x.Quantity,
                    TotalPoint = x.User.Point,
                    PointUsed = x.PointUsed,
                    IsSendToGhn = x.IsSendToGhn,
                    ServiceId = x.ServiceId,
                    Phone = x.Phone,
                    Address = x.Address,
                    FullName = x.FullName,
                    Note = x.Note,
                    ShipTo = x.Address
                });
        }

        public long Insert(OrderModel model)
        {
            var orderDetails = new List<OrderDetail>();
            foreach (var item in model.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalMoney = item.TotalMoney,
                    CreateBy = item.CreateBy,
                    CreatedDate = item.CreatedDate,
                    LastModifiedBy = item.LastModifiedBy
                };
                orderDetails.Add(orderDetail);
            }

            var orderEntity = new Order
            {
                OrderDetails = orderDetails,
                IsCharged = false,
                UserId  = model.UserId,
                Total = model.OrderDetails.Sum(x => x.Cost),
                LastModifiedBy = model.LastModifiedBy,
                CreateBy = model.CreateBy,
                CreatedDate = model.CreatedDate,
                OrderCode = model.OrderCode,
                CodeDiscount = model.CodeDiscount,
                TotalMoney = model.TotalMoney,
                Discount = model.Discount,
                Quantity = model.Quantity,
                PointUsed = model.PointUsed,
                IsSendToGhn = model.IsSendToGhn,
                ServiceId = model.ServiceId,
                Phone = model.Phone,
                Address = model.Address,
                FullName = model.FullName,
                Note = model.Note
            };

            var user = _context.Users.FirstOrDefault(x => x.Id == model.UserId);
            if (user != null)
            {
                user.OrderCount++;
                _context.Entry(user).State = EntityState.Modified;
            }

            _context.Orders.Add(orderEntity);
            if (_context.SaveChanges() > 0)
            {
                return _context.Orders.Max(x => x.Id);
            }

            return 0;
        }

        public bool Insert(OrderDetailModel orderDetail)
        {
            var orderDetailEntity = new OrderDetail
            {
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                TotalMoney = orderDetail.Cost * orderDetail.Quantity,
                CreatedDate = DateTime.Now,
                CreateBy = orderDetail.CreateBy,
                LastModifiedBy = orderDetail.LastModifiedBy
            };

            _context.OrderDetails.Add(orderDetailEntity);
            return _context.SaveChanges() > 0;
        }

        public bool Update(OrderModel model)
        {
            var existedOrder = _context.Orders.Where(x => x.Id == model.Id).FirstOrDefault();
            if (existedOrder != null )
            {
                existedOrder.IsCharged = model.IsCharge;
                existedOrder.IsSendToGhn = model.IsSendToGhn;
                existedOrder.GhnTotalFee = model.GhnTotalFee;
                _context.Entry(existedOrder).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
