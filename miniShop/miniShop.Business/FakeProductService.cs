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
        public List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product{ Id=1, Name="Ürün 1", Price=10, Description="Açıklama 1", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=2, Name="Ürün 2", Price=10, Description="Açıklama 2", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=3, Name="Ürün 3", Price=10, Description="Açıklama 3", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=4, Name="Ürün 4", Price=10, Description="Açıklama 4", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"},
                new Product{ Id=5, Name="Ürün 5", Price=10, Description="Açıklama 5", Discount=0.0f, ImageUrl="https://via.placeholder.com/150"}
            };

            return products;
        }
    }
}
