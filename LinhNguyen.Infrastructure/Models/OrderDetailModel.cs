using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class OrderDetailModel : BaseModel
    {
        public OrderDetailModel()
        {
            TotalMoney = Quantity * Cost;
        }

        public string GuiId { get; set; }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public long ProductId { get; set; }
        public string ProductImagePath { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Cost { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public CategoryType Category { get; set; }
        public decimal TotalMoney { get; set; }
        public ProductSize Size { get; set; }
        public ProductColor Color { get; set; }
        public int Like { get; set; }
        public string Ip { get; set; }
    }
}
