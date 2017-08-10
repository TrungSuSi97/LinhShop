using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Resources.Entities
{
    public class ResourceEntry
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string Culture { get; set; }
        public virtual string Type { get; set; }

        public ResourceEntry()
        {
            Type = "string";
        }
    }
}
