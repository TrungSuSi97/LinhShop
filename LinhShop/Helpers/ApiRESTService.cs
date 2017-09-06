using LinhNguyen.Infrastructure.Models;
using LinhShop.Helpers.RestSubClass;
using Newtonsoft.Json;
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
            client.Method = RestClient.HttpVerbEnum.Post;
            client.PostData = JsonConvert.SerializeObject(signInRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseSignIn = JsonConvert.DeserializeObject<SignInResponse>(client.MakeRequest());
            if (responseSignIn == null)
            {
                return "";
            }

            return responseSignIn.SessionToken; 
        }

        public  List<ClientHubInfo> GhnGetPickHubs()
        {
            var sessionToken = GhnSigin();
            //Get Pick Hubs
            var pickHubsRequest = new PickHubsRequest();
            client.EndPoint = baseUri + "GetPickHubs";
            pickHubsRequest.ApiKey = apiKey;
            pickHubsRequest.ApiSecretKey = apiSecretKey;
            pickHubsRequest.ClientID = int.Parse(clientId);
            pickHubsRequest.Password = password;
            pickHubsRequest.SessionToken = sessionToken;
            client.PostData = JsonConvert.SerializeObject(pickHubsRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseGetPickHubs = JsonConvert.DeserializeObject<PickHubsResponse>(client.MakeRequest());

            if (responseGetPickHubs == null)
            {
                return new List<ClientHubInfo>();
            }

            return responseGetPickHubs.HubInfo;
        }

        public List<DistrictProvinceInfo> GhnGetDistrictProvince()
        {
            var sessionToken = GhnSigin();
            //Get Pick Hubs
            var pickHubsRequest = new DistrictProvinceRequest();
            client.EndPoint = baseUri + "GetDistrictProvinceData";
            pickHubsRequest.ApiKey = apiKey;
            pickHubsRequest.ApiSecretKey = apiSecretKey;
            pickHubsRequest.ClientID = int.Parse(clientId);
            pickHubsRequest.Password = password;
            pickHubsRequest.SessionToken = sessionToken;

            client.PostData = JsonConvert.SerializeObject(pickHubsRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseGetPickHubs = JsonConvert.DeserializeObject<DistrictProvinceResponse>(client.MakeRequest());
            if (responseGetPickHubs == null)
            {
                return new List<DistrictProvinceInfo>();
            }

            return responseGetPickHubs.Data;
        }

        public List<ServicesInfo> GetListService(string idFrom, string idTo)
        {
            var sessionToken = GhnSigin();
            // Get Pick Hub
            var servicesRequest = new ServicesRequest();
            client.EndPoint = baseUri + "GetServiceList";
            servicesRequest.ApiKey = apiKey;
            servicesRequest.ApiSecretKey = apiSecretKey;
            servicesRequest.ClientID = int.Parse(clientId);
            servicesRequest.Password = password;
            servicesRequest.SessionToken = sessionToken;

            client.PostData = JsonConvert.SerializeObject(servicesRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseServices = JsonConvert.DeserializeObject<ServicesResponse>(client.MakeRequest());
            if (responseServices == null)
            {
                return new List<ServicesInfo>();
            }

            return responseServices.Services;
        }

        public ShippingOrderResponse CreateShipping(ClientHubInfo picHub, OrderModel model)
        {
            // Create Shipping Order
            var soRequest = new ShippingOrderRequest();

            soRequest.ApiKey = apiKey;
            soRequest.ApiSecretKey = apiSecretKey;
            soRequest.ClientID = int.Parse(clientId);
            soRequest.Password = password;
            soRequest.SessionToken = GhnSigin();

            soRequest.GHNOrderCode = string.Empty;
            var str = new Guid();
            soRequest.ClientOrderCode = model.OrderCode;
            soRequest.SealCode = string.Empty;
            soRequest.PickHubID = picHub.PickHubID;
            soRequest.RecipientName = model.FullName;
            soRequest.RecipientPhone = model.Phone;
            soRequest.DeliveryAddress = model.Address;
            soRequest.DeliveryDistrictCode = picHub.DistrictCode;

            soRequest.CODAmount = double.Parse(model.TotalMoney.ToString());
            soRequest.ServiceID = model.ServiceId;
            soRequest.Weight = 200; // 100 cm
            soRequest.Length = 200; // 100 cm
            soRequest.Height = 200; // 100 cm
            soRequest.ContentNote = model.Note;

            client.EndPoint = baseUri + "CreateShippingOrder";
            client.Method = RestClient.HttpVerbEnum.Post;
            client.PostData = JsonConvert.SerializeObject(soRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseCreateShippingOrder = JsonConvert.DeserializeObject<ShippingOrderResponse>(client.MakeRequest());
            return responseCreateShippingOrder;
        }

        public List<ServicesFeeInfo> GetServiceFee(ServicesFeeInfo info)
        {
            var sessionToken = GhnSigin();
            // Get Pick Hubs
            var servicesFeeRequest = new ServiceFeeRequest();
            client.EndPoint = baseUri + "CalculateServiceFee";
            servicesFeeRequest.ApiKey = apiKey;
            servicesFeeRequest.ApiSecretKey = apiSecretKey;
            servicesFeeRequest.ClientID = int.Parse(clientId);
            servicesFeeRequest.Password = password;

            var item = new List<ServicesFeeInfo>();

            item.Add(info);

            servicesFeeRequest.Items = item;
            client.PostData = JsonConvert.SerializeObject(servicesFeeRequest);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var responseFeeServices = JsonConvert.DeserializeObject<ServiceFeeResponse>(client.MakeRequest());
            if (responseFeeServices == null)
            {
                return new List<ServicesFeeInfo>(); 
            }

            return responseFeeServices.Items;
        }

        public OrderInfoResponse GetOrderInfo(string orderCode)
        {
            var order = new OrderInfoRequest();

            client.EndPoint = baseUri + "GetOrderInfo";
            order.ApiKey = apiKey;
            order.ApiSecretKey = apiSecretKey;
            order.ClientID = int.Parse(clientId);
            order.Password = password;
            order.OrderCode = orderCode;

            client.PostData = JsonConvert.SerializeObject(order);
            client.ContentType = RestClient.ContentTypeConst.Json;

            var response = JsonConvert.DeserializeObject<OrderInfoResponse>(client.MakeRequest());
            if (response == null)
            {
                return new OrderInfoResponse();
            }

            return response;
        }
    }
}