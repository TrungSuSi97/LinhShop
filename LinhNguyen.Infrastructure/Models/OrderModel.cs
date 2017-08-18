using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class OrderModel : BaseModel
    {
        public string GuiId { get; set; }
        public long Id { get; set; }
        public string OrderCode { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public bool IsCharge { get; set; }

        public string Email { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
        public decimal Fee { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalMoney { get; set; }
        public string CodeDiscount { get; set; }
        public int Quantity { get; set; }
        public int DiemDaDung { get; set; }
        public int TongDiem { get; set; }
        public string ShipTo { get; set; }
        public bool IsSendToGhn { get; set; }
        public int ServiceId { get; set; }
        public double GhnTotalFee { get; set; }
        public string GhnOrderCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }
}
