using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigBrotherO365.Service;
using Microsoft.AspNetCore.Http;
using BigBrotherO365.Data.EF;

namespace BigBrotherO365.Web.Controllers
{
    public class DBController : Controller
    {
        private IDBService _service;
        private Office365LogContext _db;
        public DBController(IDBService service,Office365LogContext db)
        {
            _service = service;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> Proceed()
        {
            await _service.Save(HttpContext.Session.GetString("code"),"Audit.Sharepoint",_db);
            await _service.Save(HttpContext.Session.GetString("code"), "Audit.AzureActiveDirectory", _db);
            await _service.Save(HttpContext.Session.GetString("code"), "Audit.General", _db);

            return RedirectToAction("Index", "Home");
        }
    }
}