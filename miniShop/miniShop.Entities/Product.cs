using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ürün adı boş olamaz")]
        [MinLength(3,ErrorMessage ="En az 3 karakter olmalı")]
        public string Name { get; set; }
        public double? Price { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float? Discount { get; set; }

        public virtual Category Category { get; set; }

        //[ForeignKey("Category")]
        public int? CategoryId { get; set; }
    }
}
