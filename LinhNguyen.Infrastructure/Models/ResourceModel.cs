using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class ResourceModel : BaseModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string Value { get; set; }
        [Required]
        [Display(Name = "Language")]
        public string Culture { get; set; }
        public string Type { get; set; }
    }
}
