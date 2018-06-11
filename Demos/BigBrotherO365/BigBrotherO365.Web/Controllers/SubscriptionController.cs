using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BigBrotherO365.Service;
using Microsoft.AspNetCore.Http;


namespace BigBrotherO365.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _service.ListAsync(HttpContext.Session.GetString("code")));
        }

        public IActionResult Start()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Start(string id)
        {
            await _service.StartAsync(HttpContext.Session.GetString("code"), id);
            return RedirectToAction("Index");
        }

        public IActionResult Stop(string id)
        {
            return View("Stop", id);
        }

        [HttpPost]
        [ActionName("Stop")]
        public async Task<IActionResult> StopSubscription(string id)
        {
            await _service.StopAsync(HttpContext.Session.GetString("code"), id);
            return RedirectToAction("Index");
        }
    }
}