using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LinhNguyen.Infrastructure.Models
{
    public class CompanyInfoModel : BaseModel 
    {
        public long Id { get; set; }
        public string PathImageLogo { get; set; }
        [Required]
        public HttpPostedFileBase ImageLogo { get; set; }
        [Required]
        public HttpPostedFileBase ImagePaymentMethod { get; set; }
        [Required]
        public HttpPostedFileBase ImageIdentity { get; set; }
        [Required]
        public HttpPostedFileBase ImageTransfer { get; set; }
        [Required]
        public string Logan { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HotLine { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Number Day to change Product")]
        [Required]
        public int DateToChangeProduct { get; set; }
        [Display(Name = "Free to delivery for order")]
        [Required]
        public decimal FreeToDelivery { get; set; }
        public decimal FreeToDeliveryUsd { get; set; }
        [Required]
        public string Copyright { get; set; }
        public string PathImagePaymentMethod { get; set; }
        public string PathImageIdentity { get; set; }
        public string PathImageTransfer { get; set; }
        //public string GiaoHangTieuChuan { get; set; }
        //public string GiaoHangNhanh { get; set; }
        //public decimal FeeGiaoHangTieuChuan { get; set; }
        //public decimal FeeGiaoHangNhanh { get; set; }
        public int PercentForPoint { get; set; }
        public int NumberPointForPercent { get; set; }

        [EmailAddress]
        [Required]
        public string EmailOffer { get; set; }

        public string PickHubCode { get; set; }
        public string PickHubText { get; set; }
        public decimal UsdExchange { get; set; }
    }
}
