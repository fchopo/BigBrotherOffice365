using BigBrotherO365.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrotherO365.Service
{
    public interface ITenantService
    {
        TenantToken GetInfo(string code);
    }
}
