﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Domain.Entities
{
    public class BaseClass 
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual DateTime ModifyDate { get; set; }
        public virtual string Error { get { return null; } }
    }
}
