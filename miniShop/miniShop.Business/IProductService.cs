using miniShop.Business.DTO.Requests;
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

        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(AddProductRequest product);
        Task<Product> UpdateProductAsync(UpdateProductRequest request);

        Task<bool> IsProductExist(int id);
        Task Delete(int id);
    }
}
                           