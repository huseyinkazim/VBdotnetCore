using Microsoft.EntityFrameworkCore;
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
        public ProductService(MiniShopDbContext miniShopDbContext)
        {
            this.miniShopDbContext = miniShopDbContext;
        }

        public Product AddProduct(Product product)
        {
            miniShopDbContext.Products.Add(product);
            miniShopDbContext.SaveChanges();
            return product;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            await miniShopDbContext.Products.AddAsync(product);
            var affectedRowCount = await miniShopDbContext.SaveChangesAsync();
            return affectedRowCount;
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
    }
}
