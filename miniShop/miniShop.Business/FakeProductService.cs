using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
   public class FakeProductService : IProductService
    {
        List<Product> products;
        public FakeProductService()
        {
            products = new List<Product>
            {
                new Product{ Id=1, Name="Mikrofon", Price=10, Description="Açıklama 1", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=2, Name="Monitör", Price=10, Description="Açıklama 2", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=3, Name="Laptop", Price=10, Description="Açıklama 3", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=4, Name="Ürün 4", Price=10, Description="Açıklama 4", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=5, Name="Ürün 5", Price=10, Description="Açıklama 5", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"}
            };
        }
        public Product GetProductById(int productId)
        {
            return products.Find(p => p.Id == productId);
        }

        public List<Product> GetProducts()
        {          

            return products;
        }
    }
}
