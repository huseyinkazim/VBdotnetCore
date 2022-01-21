using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business.DTO.Requests
{
   public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float? Discount { get; set; }
        public int? CategoryId { get; set; }
    }
}
