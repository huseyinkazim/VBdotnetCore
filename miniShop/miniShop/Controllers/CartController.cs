using Microsoft.AspNetCore.Mvc;
using miniShop.Business;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct(int productId)
        {

            Product product = productService.GetProductById(productId);
            // TODO 2 Sepete atılan tüm ürünler bir koleksiyonda tutulmalı.
            // TODO 3 Bu koleksiyon, toplam tutar, ürün çıkarma ve adet güncelleme yeteneklerine sahip olmalı.
            // TODO 4 Bu koleksiyon da SESSION içinde saklanmalı! Neden? Çünkü herkesin sepeti kendine.

            return Json(product.Name);
        }
    }
}
