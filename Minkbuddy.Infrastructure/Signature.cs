using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Minkbuddy.Infrastructure
{
    public static class Signature
    {
        public static string GetSHA512String(string secret, string baseUrl)
        {
            string encodedBaseUrl = WebUtility.UrlEncode(baseUrl);
            
            byte[] hashedValue;
            byte[] byteSecret = Encoding.UTF8.GetBytes(secret);
            byte[] byteBaseUrl= Encoding.UTF8.GetBytes("GET&"+ encodedBaseUrl);

            using (HMACSHA512 hmac = new HMACSHA512(byteSecret))
            {
                hashedValue = hmac.ComputeHash(byteBaseUrl);
            }

            string bitString = BitConverter.ToString(hashedValue);
            return bitString.Replace("-", "").ToLower();
        }
    }
}
