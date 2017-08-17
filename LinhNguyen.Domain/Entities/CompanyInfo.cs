using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.CompanyInfo")]
    public class CompanyInfo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string PathImageLogo { get; set; }
        public string Logan { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HotLine { get; set; }
        public string Title { get; set; }
        public int DateToChangeProduct { get; set; }
        public decimal FreeToDelivery { get; set; }
        public string Copyright { get; set; }
        public string PathImagePaymentMethod { get; set; }
        public string PathImageIdentity { get; set; }
        public string PathImageTransfer { get; set; }
        public int PercentForPoint { get; set; }
        public int NumberPointForPercent { get; set; }
        public string PickHubCode { get; set; }
        public string PickHubText { get; set; }
        public string FreeToDeliveryUsd { get; set; }
        public decimal UsdExchange { get; set; }
    }
}
