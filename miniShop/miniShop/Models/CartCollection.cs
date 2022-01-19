using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class CartCollection
    {
        //Dikkat!!! public bir özellik olmazsa serialize edemezsiniz
        public List<ProductInCard> Products { get; set; } = new List<ProductInCard>();

        public void AddProduct(Product product, int quantity)
        {
            var existingProduct = Products.Find(x => x.Product.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;
            }
            else
            {
                Products.Add(new ProductInCard { Product = product, Quantity = quantity });
            }

        }
        public void RemoveProduct(Product product)
        {
            Products.RemoveAll(x => x.Product.Id == product.Id);
        }

        public void Clear()
        {
            Products.Clear();
        }

        public decimal TotalPrice()
        {
            return Products.Sum(productInCart =>
            (decimal)productInCart.Product.Price *
            (decimal)(1 - productInCart.Product.Discount) * productInCart.Quantity);
        }

    }

    public class ProductInCard
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
