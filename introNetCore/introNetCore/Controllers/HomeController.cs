using introNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ad = "Türkay";
            ViewBag.Tarih = DateTime.Now;
            dynamic x = 0;
            ViewBag.OlduMu = false;

            IEnumerable<Product> products = new List<Product>
            {
                new Product { Id=1, ProductName="Klavye", Price=100},
                new Product { Id=2, ProductName="Mouse", Price=200},
                new Product { Id=3, ProductName="Kamera", Price=300},
                new Product { Id=4, ProductName="Monitör", Price=400}

            };


            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }

    }
}
