using BigBrotherO365.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigBrotherO365.Service
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityContent>> GetContentListAsync(string code,string contentType);
        Task<List<ActivityDetail>> GetDetailsAsync(string code, string contentId);

    }
}
