using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class CouponModel : BaseModel 
    {
        public long Id { get; set; }
        [Required]
        public string CouponsCode { get; set; }
        [Required]
        public string Reason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool SendEmail { get; set; }
        [Required]
        public int DiscountPercent { get; set; }
    }
}
