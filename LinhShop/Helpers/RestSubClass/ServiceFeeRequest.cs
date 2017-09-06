using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ServiceFeeRequest
    {
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public int ClientID { get; set; }
        public string Password { get; set; }
        public List<ServicesFeeInfo> Items { get; set; }
    }
}