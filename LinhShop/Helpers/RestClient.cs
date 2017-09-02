using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace LinhShop.Helpers
{
    public class RestClient
    {
        public enum HttpVerbEnum
        {
            Get,
            Post
        }

        public class ContentTypeConst
        {
            public const string Json = "application/json";
            public const string Text = "text/xml";
            public const string PostForm = "application/x-www-form-urlencoded";
        }

        public string EndPoint { get; set; }
        public HttpVerbEnum Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = string.Empty;
            Method = HttpVerbEnum.Get;
            ContentType = ContentTypeConst.Text;
            PostData = string.Empty;
        }

        public RestClient(string endPoint, HttpVerbEnum method, string contentType)
        {
            EndPoint = endPoint;
            Method = method;
            ContentType = contentType;
        }

        public string MakeRequest(string userCredentials = "", string passCredentials = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(userCredentials) && !string.IsNullOrEmpty(passCredentials))
            {
                request.Credentials = new NetworkCredential(userCredentials, passCredentials);
            }

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerbEnum.Post)
            {
                var bytes = Encoding.UTF8.GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            var responseValue = string.Empty;
            using (var response =  (HttpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return responseValue;
        }
    }
}