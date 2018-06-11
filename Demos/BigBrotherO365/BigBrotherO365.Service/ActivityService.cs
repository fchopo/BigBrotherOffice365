using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BigBrotherO365.Data;
using BigBrotherO365.Service.Helpers;
using Newtonsoft.Json;

namespace BigBrotherO365.Service
{
    public class ActivityService : IActivityService
    {
        public async Task<IEnumerable<ActivityContent>> GetContentListAsync(string code,string contentType)
        {
            O365Core.CheckToken(code);
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://manage.office.com/api/v1.0/{0}/activity/feed/subscriptions/Content?contenttype={1}&publisheridentifier={2}", O365Core.Token.tenantToken.tid,contentType, O365Core.Token.tenantToken.tid);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", O365Core.Token.access_token);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    if (jsonResult.Contains("contentUri"))
                    {
                        List<ActivityContent> activityContentList = JsonConvert.DeserializeObject<List<ActivityContent>>(jsonResult);
                        return activityContentList;
                    }
                    else return null;
                }
                else return null;
            }
        }

        public async Task<List<ActivityDetail>> GetDetailsAsync(string code,string contentId)
        {
            O365Core.CheckToken(code);
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://manage.office.com/api/v1.0/{0}/activity/feed/audit/{1}?publisherIdentifier={2}", O365Core.Token.tenantToken.tid, contentId, O365Core.Token.tenantToken.tid);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", O365Core.Token.access_token);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    if (jsonResult.Contains("CreationTime"))
                    {
                        List<ActivityDetail> activityDetails = JsonConvert.DeserializeObject<List<ActivityDetail>>(jsonResult);
                        return activityDetails;
                    }
                    else return null;
                }
                else return null;
            }
        }
    }
}
