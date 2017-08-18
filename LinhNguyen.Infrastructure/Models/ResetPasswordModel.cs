using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class ResetPasswordModel
    {

        [Display(Name = "TxtUserEmail", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                                       ErrorMessageResourceName = "TxtEmailInvalid")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                ErrorMessageResourceName = "TxtEmailRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                        ErrorMessageResourceName = "TxtEmailLong")]
        public string Email { get; set; }
    }
}
