using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class BaseModel
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}
