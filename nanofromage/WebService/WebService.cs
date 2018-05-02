using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class Webservice
    {
        private String baseSite = "";

        public Webservice(String baseSite)
        {
            this.baseSite = baseSite;
        }

        public async Task<TItem> HttpClientCaller<TItem>(String url, TItem item)
        {
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.baseSite);
                client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress+url);
                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<TItem>(result);
                }
            }
            return item;
        }
        
    }
}
