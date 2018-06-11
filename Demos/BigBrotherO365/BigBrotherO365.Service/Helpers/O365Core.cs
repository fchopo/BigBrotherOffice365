using BigBrotherO365.Data;
using JWT;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BigBrotherO365.Service.Helpers
{
    public static class O365Core
    {
        private static string client_id = "APP_CLIENT_ID";
        private static string client_secret = "APP_CLIENT_SECRET";

        public static DateTime Expires { get; set; }
        public static O365Token Token { get; set; }
   
        private static void GetToken(string code)
        {
            Expires = DateTime.Now.AddHours(1);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://login.windows.net");
                List<KeyValuePair<string, string>> listParam = new List<KeyValuePair<string, string>>();

                listParam.Add(new KeyValuePair<string, string>("resource", "https://manage.office.com"));
                listParam.Add(new KeyValuePair<string, string>("client_id", client_id));
                listParam.Add(new KeyValuePair<string, string>("client_secret", client_secret));
                listParam.Add(new KeyValuePair<string, string>("redirect_uri", "http://bigbrothero365web.azurewebsites.net/"));
                listParam.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                listParam.Add(new KeyValuePair<string, string>("code", code));
                var formContent = new FormUrlEncodedContent(listParam);

                var result = client.PostAsync("https://login.windows.net/common/oauth2/token", formContent).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;

                Token = JsonConvert.DeserializeObject<O365Token>(resultContent);
                Token.tenantToken = GetTenantToken(Token.access_token);
            };
        }

        private static TenantToken GetTenantToken(string access_token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                string resultContent = decoder.Decode(access_token, client_secret, verify: false);

                TenantToken tenantToken = JsonConvert.DeserializeObject<TenantToken>(resultContent);
                return tenantToken;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static string CheckToken(string code)
        {
            if (DateTime.Now >= Expires) GetToken(code);
            return Token.access_token;
        }
    }
}
