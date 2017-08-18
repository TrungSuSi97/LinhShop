using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LinhNguyen.Infrastructure.Models
{
    public class ProductModel : BaseModel 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }
        [Required]
        [Display(Name = "ProductCode")]
        [StringLength(12, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z0-9]+$")]
        [Remote("CheckExistingCode", "Admin", ErrorMessage = "Code already exists")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Image1")]
        public HttpPostedFileBase Image1 { get; set; }
        [Required]
        [Display(Name = "Image2")]
        public HttpPostedFileBase Image2 { get; set; }
        [Display(Name = "Image3")]
        public HttpPostedFileBase Image3 { get; set; }
        [Display(Name = "Image4")]
        public HttpPostedFileBase Image4 { get; set; }
        [Display(Name = "Image5")]
        public HttpPostedFileBase Image5 { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal? Cost { get; set; }
        [Display(Name = "Discount")]
        public int? Discount { get; set; }
        [Display(Name = "Category")]
        public int Catetory { get; set; }
        [Display(Name = "Made by")]
        public string ProductBy { get; set; }
        public virtual ProductSize Size { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Additional Information")]
        public string AdditionalInformation { get; set; }
        public string Modern { get; set; }
        public string Note { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public string ImagePath5 { get; set; }
        [Display(Name = "New Trend")]
        public bool IsNewCollection { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Quantity { get; set; }
        public int NumLike { get; set; }
        public ProductColor Color { get; set; }
        public decimal UserAmount { get; set; }
        [StringLength(50)]
        [Display(Name = "FreeText")]
        public string FreeText { get; set; }
    }
}
