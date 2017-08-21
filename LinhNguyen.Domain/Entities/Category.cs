using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.Category")]
    public class Category : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Remote("IsCategoryNameExist", "Admin", ErrorMessage = "Category Name already exist")]
        public string CategoryName { get; set; }
        public ICollection<Product> ProductList { get; set; }
        public CategoryType Type { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    }
}
