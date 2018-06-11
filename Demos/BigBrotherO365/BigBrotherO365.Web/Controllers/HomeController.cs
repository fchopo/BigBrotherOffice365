using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigBrotherO365.Web.Models;
using Microsoft.AspNetCore.Http;
using BigBrotherO365.Service;

namespace BigBrotherO365.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITenantService _service;

        public HomeController(ITenantService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            if(HttpContext.Request.QueryString.HasValue)
            {
                HttpContext.Session.SetString("code", HttpContext.Request.Query["code"].ToString());
                return View(_service.GetInfo(HttpContext.Session.GetString("code")));
            }
            else
            {
                if(HttpContext.Session.GetString("code")!=null) return View(_service.GetInfo(HttpContext.Session.GetString("code")));
                else return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
