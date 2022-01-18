using DiifferenceLIDI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiifferenceLIDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScoped scoped;
        private readonly ISingleton singleton;
        private readonly ITransient transient;
        private readonly GuidService guidService;

        public HomeController(ILogger<HomeController> logger, IScoped scoped, ISingleton singleton, ITransient transient, GuidService guidService)
        {
            _logger = logger;
            this.scoped = scoped;
            this.singleton = singleton;
            this.transient = transient;
            this.guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid.ToString();
            ViewBag.Scoped = scoped.Guid.ToString();
            ViewBag.Transient = transient.Guid.ToString();

            ViewBag.ScopeSingleton = guidService.Singleton.Guid.ToString();
            ViewBag.ScopeScoped = guidService.Scoped.Guid.ToString();
            ViewBag.ScopeTransient = guidService.Transient.Guid.ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
