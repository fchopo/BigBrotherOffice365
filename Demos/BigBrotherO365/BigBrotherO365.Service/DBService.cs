using System;
using System.Collections.Generic;
using System.Text;
using BigBrotherO365.Data.EF;
using BigBrotherO365.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherO365.Service
{
    public class DBService:IDBService
    {
        public async Task<bool> Save(string code, string contentType, Office365LogContext db)
        {

            ActivityService service = new ActivityService();
            IEnumerable<ActivityContent> contents = await service.GetContentListAsync(code, contentType);

            foreach (ActivityContent content in contents)
            {
                IEnumerable<ActivityDetail> details = await service.GetDetailsAsync(code, content.contentId);

                foreach (ActivityDetail detail in details)
                {
                    ActivityLogs activityLog = new ActivityLogs();

                    activityLog.ClientIp = detail.ClientIP;
                    activityLog.CorrelationId = detail.CorrelationId;
                    activityLog.CreationTime = detail.CreationTime;
                    activityLog.EventSource = detail.EventSource;
                    activityLog.Id = detail.Id;
                    activityLog.ItemType = detail.ItemType;
                    activityLog.ListId = detail.ListId;
                    activityLog.ListItemUniqueId = detail.ListItemUniqueId;
                    activityLog.ObjectId = detail.ObjectId;
                    activityLog.Operation = detail.Operation;
                    activityLog.OrganizationId = detail.OrganizationId;
                    activityLog.RecordType = detail.RecordType;
                    activityLog.Site = detail.Site;
                    activityLog.SiteUrl = detail.SiteUrl;
                    activityLog.SourceFileExtension = detail.SourceFileExtension;
                    activityLog.SourceFileName = detail.SourceFileName;
                    activityLog.SourceRelativeUrl = detail.SourceRelativeUrl;
                    activityLog.UserAgent = detail.UserAgent;
                    activityLog.UserId = detail.UserId;
                    activityLog.UserKey = detail.UserKey;
                    activityLog.UserType = detail.UserType;
                    activityLog.Version = detail.Version;
                    activityLog.WebId = detail.WebId;
                    activityLog.Workload = detail.Workload;

                    db.ActivityLogs.Add(activityLog);
                    await db.SaveChangesAsync();

                }
            }
            return true;
        }        
    }
}
