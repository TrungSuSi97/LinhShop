using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.Order")]
    public class Order : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public virtual string OrderCode { get; set; }
        public virtual long UserId { get; set; }
        public virtual decimal Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
        public bool IsCharged { get; set; }
        public string CodeDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalMoney { get; set; }
        public int Quantity { get; set; }
        public int PointUsed { get; set; }
        public bool IsSendToGhn { get; set; }
        public int ServiceId { get; set; }
        public double GhnTotalFee { get; set; }
        public string GhnOrderCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string FullName { get; set; }
        public UserPaymentMethod PaymentMethod { get; set; }
    }
}
