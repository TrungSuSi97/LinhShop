using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LinhNguyen.Infrastructure.Models
{
    public class NewsModel : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [Display(Name = "Image")]
        public HttpPostedFileBase Image { get; set; }
        [Required]
        [Display(Name = "Paragraph")]
        [MaxLength(400)]
        public string Paragraph { get; set; }
    }
}
