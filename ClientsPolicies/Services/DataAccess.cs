using ClientsPolicies.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClientsPolicies.Services
{
    public class DataAccess
    {
        private readonly string _urlClients = "http://www.mocky.io/v2/5808862710000087232b75ac";
        private readonly string _urlPolicies = "http://www.mocky.io/v2/580891a4100000e8242b75c5";

        public List<Policies> ExtractPoliciesData()
        {
            var readText = GetHtml(_urlPolicies);
            var data = JsonConvert.DeserializeObject<Dictionary<string, Policies[]>>(readText);
            var list = data["policies"].ToList();
            return list;
        }

        public List<Clients> ExtractClientsData()
        {
            var readText = GetHtml(_urlClients);
            var data = JsonConvert.DeserializeObject<Dictionary<string, Clients[]>>(readText);
            var list = data["clients"].ToList();
            return list;
        }

        private string GetHtml(string url)
        {
            using (WebClient client = new WebClient())
            {
                var htmlCode = client.DownloadString(url);
                return htmlCode;
            }
        }
    }
}
