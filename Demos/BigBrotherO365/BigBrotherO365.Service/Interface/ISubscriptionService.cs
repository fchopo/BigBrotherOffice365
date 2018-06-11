using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BigBrotherO365.Data;

namespace BigBrotherO365.Service
{
    public interface ISubscriptionService
    {
        Task<bool> StartAsync(string code, string contentType);
        Task<bool> StopAsync(string code, string contentType);
        Task<IEnumerable<O365Subscription>> ListAsync(string code);
    }
}
