using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class LoginModel
    {      
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                 ErrorMessageResourceName = "TxtEmailRequired")]
        [Display(Name = "TxtEmailOrUsername", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                 ErrorMessageResourceName = "TxtEmailRequired")]
        [Display(Name = "TxtEmailOrUsername", ResourceType = typeof(Resources.Resources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "TxtUserPasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "TxtPassword", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [Display(Name = "TxtRememberMe", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
