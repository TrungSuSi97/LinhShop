using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class OrderInfoResponse
    {
        public string OrderCode { get; set; }
        public string OldSOCode { get; set; }
    }
}