using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LinhNguyen.Infrastructure.Models
{
    public class UserModel : BaseModel
    {
        public long Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources), 
            ErrorMessageResourceName = "TxtFullNameRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
            ErrorMessageResourceName = "TxtFullNameLong")]
        [Display(Name = "TxtFullName", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        public string FullName { get; set; }

        [Display(Name = "TxtUserEmail", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
                                         ErrorMessageResourceName = "TxtEmailInvalid")]
        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                  ErrorMessageResourceName = "TxtEmailRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                          ErrorMessageResourceName = "TxtEmailLong")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                  ErrorMessageResourceName = "TxtUsernameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                          ErrorMessageResourceName = "TxtUsernameLong")]
        [Display(Name = "TxtUsername", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                  ErrorMessageResourceName = "TxtUserPasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "TxtPassword", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [StringLength(25, ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "TxtPasswordLong", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "TxtConfirmPassword", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "TxtUserAddress1", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                 ErrorMessageResourceName = "TxtAddressRequired")]
        [StringLength(300, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                         ErrorMessageResourceName = "TxtAddressLong")]
        public string Address { get; set; }

        [Display(Name = "TxtUserAddress2", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [StringLength(300, ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                         ErrorMessageResourceName = "TxtAddressLong")]
        public string Address1 { get; set; }

        [Display(Name = "TxtUserPhone", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(LinhNguyen.Resources.Resources),
                 ErrorMessageResourceName = "TxtPhoneRequired")]
        public string PhoneNumber { get; set; }

        [Display(Name = "TxtUserBirthday", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "TxtUserRole", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        public UserRole Role { get; set; }

        [Display(Name = "TxtUserImage", ResourceType = typeof(LinhNguyen.Resources.Resources))]
        public HttpPostedFileBase FileImage { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "TxtSex")]
        public Gender? Gender { get; set; }
        public int Point { get; set; }

        public string SelectedTheme { get; set; }
        public string SelectedAccent { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    }
}
