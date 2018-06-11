using System;
using System.Collections.Generic;
using System.Text;
using BigBrotherO365.Data;
using BigBrotherO365.Service.Helpers;

namespace BigBrotherO365.Service
{
    public class TenantService : ITenantService
    {
        public TenantToken GetInfo(string code)
        {
            O365Core.CheckToken(code);
            return O365Core.Token.tenantToken;
        }
    }
}
