using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ServicesRequest
    {
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public int ClientID { get; set; }
        public string Password { get; set; }
        public string FromDistrictCode { get; set; }
        public string ToDistrictCode { get; set; }
        public string SessionToken { get; set; }
    }
}