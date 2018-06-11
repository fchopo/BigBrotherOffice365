using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrotherO365.Data
{
    public class ActivityDetail
    {
        public DateTime CreationTime { get; set; }
        public string Id { get; set; }
        public string Operation { get; set; }
        public string OrganizationId { get; set; }
        public int RecordType { get; set; }
        public string UserKey { get; set; }
        public int UserType { get; set; }
        public int Version { get; set; }
        public string Workload { get; set; }
        public string ClientIP { get; set; }
        public string ObjectId { get; set; }
        public string UserId { get; set; }
        public string CorrelationId { get; set; }
        public string EventSource { get; set; }
        public string ItemType { get; set; }
        public string ListId { get; set; }
        public string ListItemUniqueId { get; set; }
        public string Site { get; set; }
        public string UserAgent { get; set; }
        public string WebId { get; set; }
        public string SourceFileExtension { get; set; }
        public string SiteUrl { get; set; }
        public string SourceFileName { get; set; }
        public string SourceRelativeUrl { get; set; }
    }
}
