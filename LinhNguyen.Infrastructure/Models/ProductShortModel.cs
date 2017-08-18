using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class ProductShortModel
    {
        public ProductColor Color { get; set; }
        public ProductColor Size { get; set; }
        public int? Quantity { get; set; }
        public long ProductId { get; set; }
    }
}
