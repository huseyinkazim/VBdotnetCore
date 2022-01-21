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
                var result = await productService.AddProductAsync(productRequest);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }

            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                //var existingProduct = productService.GetProductById(id);
                if (await productService.IsProductExist(id))
                {
                    Product updatedProduct = await productService.UpdateProductAsync(request);
                    return Ok();
                }

                return NotFound();
            }
            return BadRequest(ModelState);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsProductExist(id))
            {
                await productService.Delete(id);
                return Ok();

            }
            return NotFound();

        }
    }
}
