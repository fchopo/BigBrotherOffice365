using System;

namespace BigBrotherO365.Data
{
    public class O365Token
    {
        public string code { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public TenantToken tenantToken { get; set; }
        
        
    }
}
