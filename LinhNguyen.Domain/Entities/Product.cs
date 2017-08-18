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
    [Table("dbo.Product")]
    public class Product : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Code { get; set; }
        public virtual string ImagePath1 { get; set; }
        public virtual string ImagePath2 { get; set; }
        public virtual string ImagePath3 { get; set; }
        public virtual string ImagePath4 { get; set; }
        public virtual string ImagePath5 { get; set; }

        public virtual decimal? Cost { get; set; }
        public virtual int? Discount { get; set; }
        public virtual string ProductBy { get; set; }
        public virtual ProductSize Size { get; set; }
        public virtual string FreeText { get; set; }
        public virtual string Description { get; set; }
        public virtual string AdditionalInformation { get; set; }
        public virtual int Catetory { get; set; }
        public virtual string  Modern { get; set; }
        public virtual string Note { get; set; }
        public bool IsNewCollection { get; set; }
        public int? Quantity { get; set; }
        public int NumLike { get; set; }
        public ProductColor Color { get; set; }
    }
}
