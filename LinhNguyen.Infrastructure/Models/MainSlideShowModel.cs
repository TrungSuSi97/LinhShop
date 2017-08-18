using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LinhNguyen.Infrastructure.Models
{
    public class MainSlideShowModel
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }

        [Display(Name = "Image1")]
        [Required]
        public HttpPostedFileBase Image1 { get; set; }

        [Display(Name = "Image2")]
        [Required]
        public HttpPostedFileBase Image2 { get; set; }

        [Display(Name = "Image3")]
        [Required]
        public HttpPostedFileBase Image3 { get; set; }

        [Display(Name = "Image4")]
        [Required]
        public HttpPostedFileBase Image4 { get; set; }

        public SlideShowType Type { get; set; }
    }
}
