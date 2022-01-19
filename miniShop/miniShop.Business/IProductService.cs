using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
   public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int productId);
        Product AddProduct(Product product);
    }
}
