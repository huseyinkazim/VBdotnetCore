using AutoMapper;
using Microsoft.EntityFrameworkCore;
using miniShop.Business.DTO.Requests;
using miniShop.DataAccess;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class ProductService : IProductService
    {
        private MiniShopDbContext miniShopDbContext;
        private IMapper mapper;

        public ProductService(MiniShopDbContext miniShopDbContext, IMapper mapper)
        {
            this.miniShopDbContext = miniShopDbContext;
            this.mapper = mapper;
        }

        public Product AddProduct(Product product)
        {
            miniShopDbContext.Products.Add(product);
            miniShopDbContext.SaveChanges();
            return product;
        }

        public async Task<Product> AddProductAsync(AddProductRequest productRequest)
        {

            var product = mapper.Map<Product>(productRequest);
            await miniShopDbContext.Products.AddAsync(product);
            await miniShopDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await miniShopDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            miniShopDbContext.Products.Remove(product);
            await miniShopDbContext.SaveChangesAsync();
        }

        public Product GetProductById(int productId)
        {
            return miniShopDbContext.Products.Find(productId);

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await miniShopDbContext.Products.FindAsync(id);
        }

        public List<Product> GetProducts()
        {
            return miniShopDbContext.Products.ToList();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await miniShopDbContext.Products.ToListAsync();
        }

        public async Task<bool> IsProductExist(int id)
        {
            return await miniShopDbContext.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateProductAsync(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            miniShopDbContext.Update<Product>(product);
           // miniShopDbContext.Entry<Product>().State = EntityState.
            await miniShopDbContext.SaveChangesAsync();
            return product;
        }
    }
}
