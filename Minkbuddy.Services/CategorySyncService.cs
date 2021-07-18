using Microsoft.Extensions.Configuration;
using Minkbuddy.Services.AbstractClass;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Minkbuddy.Models.Domain;

namespace Minkbuddy.Services
{
    public class CategorySyncService : DataSyncService
    {
        private readonly IConfiguration _configuration;

        public CategorySyncService(string urlForSignature, IConfiguration configuration) : base(urlForSignature, configuration)
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

                        // HTTP GET  
                        response = await client.GetAsync(Convert.ToString(_configuration["Woohoo:Urls:categoryUrl"]).Replace("{id}","122"));
                        //response = await client.GetAsync("");

                        // Verification  
                        if (response.IsSuccessStatusCode)
                        {
                            // Reading Response.  
                            var result = response.Content.ReadAsStringAsync().Result;
                            var serializeObject = JsonConvert.DeserializeObject<Category>(result);
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
