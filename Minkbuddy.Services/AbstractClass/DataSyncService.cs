using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Minkbuddy.Infrastructure;
using Newtonsoft.Json;

namespace Minkbuddy.Services.AbstractClass
{
    public abstract class DataSyncService
    {
        private readonly string _urlForSignature = "";
        private readonly IConfiguration _config;
        public string AuthorizationCode { get; private set; }
        public string Token { get; private set; }
        public string IsoDateString { get; private set; }
        public string ClientSignature { get; private set; }
        public bool MoveNext { get; private set; }

        public DataSyncService(string urlForSignature, IConfiguration config)
        {
            _urlForSignature = urlForSignature;
            IsoDateString = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            _config = config;
        }

        /// <summary>
        /// Step 1
        /// </summary>
        /// <returns>Get AuthCode</returns>
        protected async Task GetAuthCode()
        {
            var requestPayload = new
            {
                clientId = _config["Woohoo:Authkeys:consumerKey"],
                username = _config["Woohoo:Authkeys:username"],
                password = _config["Woohoo:Authkeys:password"]
            };

            string authCodeUrl = _config["Woohoo:Urls:baseUrl"] + _config["Woohoo:Urls:authCodeUrl"];

            var jsonRequestBody = JsonConvert.SerializeObject(requestPayload);

            AuthorizationCode = await PostApiCall(authCodeUrl, jsonRequestBody);

            MoveNext = true;

        }

        /// <summary>
        /// Step 2 
        /// </summary>
        /// <returns>Get Token</returns>
        protected async Task GetToken()
        {
            if (MoveNext)
            {
                var requestPayload = new
                {
                    clientId = _config["Woohoo:AuthKeys:consumerKey"],
                    clientSecret = _config["Woohoo:AuthKeys:consumerSecret"],
                    authorizationCode = AuthorizationCode,
                };

                string authCodeUrl = _config["Woohoo:Urls:baseUrl"] + _config["Woohoo:Urls:tokenUrl"];

                var jsonRequestBody = JsonConvert.SerializeObject(requestPayload);

                Token = await PostApiCall(authCodeUrl, jsonRequestBody); 
            }
        }

        /// <summary>
        /// Step 3 
        /// </summary>
        /// <returns>Generate Signature</returns>
        protected void GetSignature()
        {
            if (MoveNext)
            {
                ClientSignature = Signature.GetSHA512String(Convert.ToString(_config["Woohoo:AuthKeys:consumerSecret"]), _urlForSignature); 
            }
        }

        private async Task<string> PostApiCall(string completeUrl, string body)
        {
            string returnString = "";
            using (var client = new HttpClient())
            {
                try
                {
                    // Setting Base address.  
                    client.BaseAddress = new Uri(completeUrl);

                    // Setting content type.                   
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    var content = new StringContent(Convert.ToString(body));

                    // HTTP POST  
                    response = await client.PostAsync(completeUrl, content).ConfigureAwait(false);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        var result = response.Content.ReadAsStringAsync().Result;
                        returnString = (result.Split(':')[1]).Replace("}","").Replace("\"", ""); //going simple
                    }
                }
                catch (Exception ex)
                {
                    MoveNext = false;
                    throw;
                }
            }
            return returnString;
        }

        public abstract Task Sync();
    }
}
