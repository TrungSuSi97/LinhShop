using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ServicesInfo
    {
        public int ShippingServiceID { get; set; }

        public string Name { get; set; }

        public int ServiceType { get; set; }

        public int Type { get; set; }
    }
}