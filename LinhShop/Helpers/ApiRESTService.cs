using LinhShop.Helpers.RestSubClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace LinhShop.Helpers
{
    public class ApiRESTService
    {
        private readonly string baseUri = WebConfigurationManager.AppSettings["Ghn_BaseUri"].ToString();
        private readonly string password = WebConfigurationManager.AppSettings["Ghn_Password"].ToString();
        private readonly string clientId = WebConfigurationManager.AppSettings["Ghn_ClientID"].ToString();
        private readonly string apiSecretKey = WebConfigurationManager.AppSettings["Ghn_ApiSecretKey"].ToString();
        private readonly string apiKey = WebConfigurationManager.AppSettings["Ghn_ApiKey"].ToString();

        private readonly RestClient client;
        private string sessionToken = string.Empty;

        public ApiRESTService()
        {
            client = new RestClient();
        }

        public string GhnSigin()
        {
            // Sigin system
            var signInRequest = new SignInRequest
            {
                ClientID = int.Parse(clientId),
                Password = password
            };

            client.EndPoint = baseUri + "SignIn";

        }
    }
}