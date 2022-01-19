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

        public Product GetProductById(int productId)
        {
            return miniShopDbContext.Products.Find(productId);

        }

        public List<Product> GetProducts()
        {
            return miniShopDbContext.Products.ToList();
        }
    }
}
