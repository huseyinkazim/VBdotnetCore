using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniShop.Business;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {

            return View(productService.GetProducts());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = fillCategories();
            return View();
        }

        private IEnumerable<SelectListItem> fillCategories()
        {
            List<SelectListItem> selectLists = new List<SelectListItem>();
            categoryService.GetCategories().ToList()
                           .ForEach(category =>
                                    selectLists.Add(new SelectListItem
                                    {
                                        Text = category.Name,
                                        Value = category.Id.ToString()
                                    }));

            return selectLists;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Product addedProduct = productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = fillCategories();
            return View();
        }

    }
}
