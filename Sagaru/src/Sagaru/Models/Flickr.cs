using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Sagaru.Models
{
    public class Flickr
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url_s{ get; set; }
        public string Url_l { get; set; }

        public static List<Flickr> GetFlickr()
        {
            var client = new RestClient("https://api.flickr.com/services/rest/");
            var request = new RestRequest("?method=flickr.interestingness.getList&format=json&per_page=15&page=1&extras=url_s,url_l&api_key="+EnvironmentVariables.ApiKey, Method.GET);
            var response = client.Execute(request);
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var flickrList = JsonConvert.DeserializeObject<List<Flickr>>(jsonResponse["photo"].ToString());
            return flickrList;
        }

    }
}
