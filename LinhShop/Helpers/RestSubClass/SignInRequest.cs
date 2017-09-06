using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class SignInRequest
    {
        public int ClientID { get; set; }
        public string Password { get; set; }
    }
}