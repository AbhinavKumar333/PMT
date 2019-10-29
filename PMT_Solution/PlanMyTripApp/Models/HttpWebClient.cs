using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PlanMyTripApp.Models
{
    public static class HttpWebClient
    {
        public static HttpClient CreateWebClient()
        {
            var client = new HttpClient();//http://localhost:62921/api/
            string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();
            client.BaseAddress = new Uri(serviceUrl);
            return client;
        }

    }
}