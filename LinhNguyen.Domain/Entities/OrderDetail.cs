using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.OrderDetail")]
    public class OrderDetail : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public decimal TotalBill { get; set; }
        public int Quantity { get; set; }
    }
}
