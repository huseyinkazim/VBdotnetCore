using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using miniShop.Business;
using miniShop.Entities;
using miniShop.Extensions;
using miniShop.Models;
using Newtonsoft.Json;
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
            var collection = GetCartCollectionInSession();
            return View(collection);
        }

        public IActionResult AddProduct(int productId)
        {

            Product product = productService.GetProductById(productId);

            // TODO 4 Bu koleksiyon da SESSION içinde saklanmalı! Neden? Çünkü herkesin sepeti kendine.         
           

            if (product != null)
            {
               
                var cart = GetCartCollectionInSession();
                cart.AddProduct(product, 1);
                SaveSession(cart);
                return Json(product.Name);
            }

            return NotFound();
        }

        private void SaveSession(CartCollection cart)
        {
            HttpContext.Session.SetJson("myCart", cart);
        }

        private CartCollection GetCartCollectionInSession()
        {
            //if (HttpContext.Session.GetString("myCart")==null)
            //{
            //    CartCollection cartCollection = new CartCollection();
            //    var serializeCart = JsonConvert.SerializeObject(cartCollection);
            //    HttpContext.Session.SetString("myCart", serializeCart);
            //}

            //var serialized = HttpContext.Session.GetString("myCart");
            //return JsonConvert.DeserializeObject<CartCollection>(serialized);

            CartCollection cartCollection = HttpContext.Session.GetJson<CartCollection>("myCart") ?? new CartCollection();

            return cartCollection;





        }
    }
}
