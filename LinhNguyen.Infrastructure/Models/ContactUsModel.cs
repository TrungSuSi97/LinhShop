using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class ContactUsModel : BaseModel
    {
        public long Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "TxtFullNameRequired")]
        [Display(Name = "TxtFullName", ResourceType = typeof(Resources.Resources))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "TxtFullNameLong")]
        public string FullName { get; set; }
        [Display(Name = "TxtUserPhone", ResourceType = typeof(Resources.Resources))]
        public string Phone { get; set; }
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
                                         ErrorMessageResourceName = "TxtEmailInvalid")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "TxtEmailRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "TxtEmailLong")]
        [Display(Name = "TxtUserEmail", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
        [Display(Name = "TxtSubjectText", ResourceType = typeof(Resources.Resources))]
        public string Subject { get; set; }
    }
}
