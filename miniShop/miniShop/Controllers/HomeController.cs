using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miniShop.Business;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int page = 1, string categoryName = null)
        {
            ViewBag.Page = page;
            var totalItemPerPage = 3;
            var products = productService.GetProducts();

            var paginetedProducts = products.OrderBy(x => x.Id)
                                            .Skip((page - 1) * totalItemPerPage)
                                            .Take(totalItemPerPage);

            //HttpContext.Session.GetString("myCart");
            //1 -> 0 Skip
            //2 -> 3 Skip
            //3 -> 6 Skip
            // 27                   4 

            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / totalItemPerPage);
            return View(paginetedProducts);


            // TODO 1: Eğer zaman olursa, html üzerinde tag builder kullan
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
