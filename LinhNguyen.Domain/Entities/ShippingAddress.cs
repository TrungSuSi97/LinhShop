using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.ShippingAddress")]
    public class ShippingAddress : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public string ShippingToAddress { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
