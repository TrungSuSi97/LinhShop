using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LinhNguyen.Infrastructure.Models
{
    public class CategoryModel : BaseModel
    {
        public long Id { get; set; }
        [Remote("IsCategoryNameExist", "Admin", ErrorMessage = "Category Name already exist")]
        [Required]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Category type")]
        public CategoryType Type { get; set; }
        [Required]
        [Display(Name = "Image")]
        public HttpPostedFileBase Image { get; set; }

        public byte[] ImagePic { get; set; }

        public string ImageType { get; set; }
    }
}

