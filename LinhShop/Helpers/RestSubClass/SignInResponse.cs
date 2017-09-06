using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class SignInResponse
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ErrorMessage { get; set; }
        public string SessionToken { get; set; }
    }
}