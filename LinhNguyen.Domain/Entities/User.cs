using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    [Table("dbo.User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
        public virtual string Address { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual 
    }
}
