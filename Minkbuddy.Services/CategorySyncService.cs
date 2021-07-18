using Microsoft.Extensions.Configuration;
using Minkbuddy.Services.AbstractClass;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Minkbuddy.Services
{
    public class CategorySyncService : DataSyncService
    {
        private readonly string _url = "";
        //private readonly string _isoDate = ""; //TBD
        public CategorySyncService(string url, IConfiguration configuration) : base(url, configuration)
        {
            _url = url;
            //_isoDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); //TBD
        }
        public override async Task Sync()
        {
            //Step 1
            await GetAuthCode();
            //Step 2
            await GetToken();
            //Step 3
            GetSignature();

            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri(_url);

                // Setting content type.                   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP POST  
                response = await client.GetAsync("");

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    var _resp = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
