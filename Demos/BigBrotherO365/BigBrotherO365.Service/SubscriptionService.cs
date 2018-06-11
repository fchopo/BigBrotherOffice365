using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BigBrotherO365.Data;
using BigBrotherO365.Service.Helpers;
using Newtonsoft.Json;

namespace BigBrotherO365.Service
{
    public class SubscriptionService : ISubscriptionService
    {
        public async Task<IEnumerable<O365Subscription>> ListAsync(string code)
        {
            O365Core.CheckToken(code);
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://manage.office.com/api/v1.0/{0}/activity/feed/subscriptions/list?publisheridentifier={1}", O365Core.Token.tenantToken.tid, O365Core.Token.tenantToken.tid);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", O365Core.Token.access_token);
                string jsonResult = await client.GetStringAsync(url);
                if (jsonResult.Contains("contentType"))
                {
                    List<O365Subscription> subscriptionList = JsonConvert.DeserializeObject<List<O365Subscription>>(jsonResult);
                    return subscriptionList;
                }
                else return null;
            }
        }

        public async Task<bool> StartAsync(string code, string contentType)
        {
            O365Core.CheckToken(code);
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://manage.office.com/api/v1.0/{0}/activity/feed/subscriptions/start?contenttype={1}&publisheridentifier={2}", O365Core.Token.tenantToken.tid, contentType, O365Core.Token.tenantToken.tid);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", O365Core.Token.access_token);
                HttpResponseMessage responseMessage=await client.PostAsync(url, null);
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<bool> StopAsync(string code, string contentType)
        {
            O365Core.CheckToken(code);
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://manage.office.com/api/v1.0/{0}/activity/feed/subscriptions/stop?contenttype={1}&publisheridentifier={2}", O365Core.Token.tenantToken.tid, contentType, O365Core.Token.tenantToken.tid);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", O365Core.Token.access_token);
                HttpResponseMessage responseMessage = await client.PostAsync(url, null);
                return responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
        }
    }
}
