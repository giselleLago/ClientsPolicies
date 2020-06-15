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
        private readonly string _url = "http://www.mocky.io/v2/5808862710000087232b75ac";

        public List<Clients> ExtractData()
        {
            var readText = GetHtml(_url);
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
