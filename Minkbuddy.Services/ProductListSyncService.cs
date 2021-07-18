using Microsoft.Extensions.Configuration;
using Minkbuddy.Models.Domain;
using Minkbuddy.Services.AbstractClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Minkbuddy.Services
{
    public class ProductListSyncService : DataSyncService
    {
        private readonly IConfiguration _configuration;

        public ProductListSyncService(string urlForSignature, IConfiguration configuration) : base(urlForSignature, configuration)
        {
            _configuration = configuration;
        }
        
        public override async Task Sync()
        {
            //Step 1
            await GetAuthCode();
            //Step 2
            await GetToken();
            //Step 3
            GetSignature();

            if (MoveNext)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        // Setting Base address.  
                        client.BaseAddress = new Uri(_configuration["Woohoo:Urls:baseUrl"]);

                        // Setting content type.                   
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("dateAtClient", IsoDateString);
                        client.DefaultRequestHeaders.TryAddWithoutValidation("signature", ClientSignature);
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                        // Initialization.  
                        HttpResponseMessage response = new HttpResponseMessage();

                        // HTTP POST  
                        response = await client.GetAsync(Convert.ToString(_configuration["Woohoo:Urls:productListUrl"]).Replace("{id}", "122"));

                        // Verification  
                        if (response.IsSuccessStatusCode)
                        {
                            // Reading Response.  
                            var result = response.Content.ReadAsStringAsync().Result;
                            var serializeObject = JsonConvert.DeserializeObject<ProductList>(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
