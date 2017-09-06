using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ServiceFeeResponse
    {
        public List<ServicesFeeInfo> Items { get; set; }
    }
}