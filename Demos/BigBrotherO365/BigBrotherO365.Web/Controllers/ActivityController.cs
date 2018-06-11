using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherO365.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBrotherO365.Web.Controllers
{
    public class ActivityController : Controller
    {
        private IActivityService _service;

        public ActivityController(IActivityService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string id="Audit.General")
        {
            var result = await _service.GetContentListAsync(HttpContext.Session.GetString("code"), id);
            return result != null ? View(result) : View("NotFound");
        }



        public async Task<IActionResult> Details(string id)
        {
            var result = await _service.GetDetailsAsync(HttpContext.Session.GetString("code"), id);
            return result != null ? View(result) : View("NotFound");
        }
    }
}