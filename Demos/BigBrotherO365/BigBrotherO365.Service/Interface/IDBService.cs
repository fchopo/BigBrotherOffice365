using BigBrotherO365.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigBrotherO365.Service
{
    public interface IDBService
    {
        Task<bool> Save(string code, string contentType, Office365LogContext db);
    }
}
