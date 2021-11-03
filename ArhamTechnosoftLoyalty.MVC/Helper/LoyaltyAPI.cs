using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Helper
{
    public class LoyaltyAPI
    {
        public HttpClient Initial(string uri)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(uri);
            return client;
        }
    }
}
