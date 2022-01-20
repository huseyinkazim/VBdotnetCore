using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniShop.Business;
using miniShop.Business.DTO.Requests;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await productService.GetProductByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest productRequest)
        {


            if (ModelState.IsValid)
            {
                //aslında doğru olan; convert işlemini productServis'in yapmasıdır.

                Product product = new Product
                {
                    Name = productRequest.Name,
                    CategoryId = productRequest.CategoryId,
                    Description = productRequest.Description,
                    Discount = productRequest.Discount,
                    ImageUrl = productRequest.ImageUrl,
                    Price = productRequest.Price
                };
                int result = await productService.AddProductAsync(product);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }

            return BadRequest(ModelState);

        }
    }
}
