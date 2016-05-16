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
        private static Uri BaseUrl = new Uri("https://api.flickr.com/");
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url_s{ get; set; }
        public string Url_l { get; set; }
        public virtual Project Project { get; set; }
        public static List<Flickr> GetFlickr()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            var request = new RestRequest("services/rest/?method=flickr.interestingness.getList&format=json&per_page=15&page=1&extras=url_s,url_l&api_key=" + EnvironmentVariables.ApiKey);
            var response = client.Execute(request);
            char[] MyCharStart = { 'j', 's', 'o', 'n', 'F', 'l', 'i', 'c', 'k', 'r', 'A', 'p', 'i', '(' };
            char[] MyCharEnd = { ')' };
            string NewString = response.Content.TrimStart(MyCharStart);
            NewString = NewString.TrimEnd(MyCharEnd);
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(NewString);
            var flickrList = JsonConvert.DeserializeObject<List<Flickr>>(jsonResponse["photos"]["photo"].ToString());
            return flickrList;
        }
    }
}
