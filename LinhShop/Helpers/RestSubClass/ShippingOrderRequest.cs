using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ShippingOrderRequest
    {
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public int ClientID { get; set; }
        public string Password { get; set; }
        public string SessionToken { get; set; }

        public string GHNOrderCode { get; set; }
        public string ClientOrderCode { get; set; }
        public string SealCode { get; set; }
        public int PickHubID { get; set; }

        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryDistrictCode { get; set; }

        public double CODAmount { get; set; }
        public int? ServiceID { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string ContentNote { get; set; }
    }
}