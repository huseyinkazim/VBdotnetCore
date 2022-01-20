using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business.DTO.Requests
{
    public class AddProductRequest
    {

        /*
         * "name": "API Ürün 1",
  "price": 100,
  "imageUrl": "",
  "description": "Açıklama 1",
  "discount": 0.15,
  "categoryId": 1
         */
        public string Name { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float? Discount { get; set; }
        public int? CategoryId { get; set; }
    }
}
