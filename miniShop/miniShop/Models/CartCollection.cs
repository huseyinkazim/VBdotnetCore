using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class CartCollection
    {
        public List<ProductInCard> Products { get; set; }

        public void AddProduct(Product product, int quantity)
        {

        }
        public void RemoveProduct(Product product)
        {

        }

        public void Clear() { }

        public decimal TotalPrice()
        {
            return 0;
        }
    }

    public class ProductInCard
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
