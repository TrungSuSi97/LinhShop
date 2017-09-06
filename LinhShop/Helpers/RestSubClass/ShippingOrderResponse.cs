using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ShippingOrderResponse
    {
        public string OrderCode { get; set; }
        public double TotalFee { get; set; }
        public string ErrorMessage { get; set; }
        public string SessionToken { get; set; }
    }
}