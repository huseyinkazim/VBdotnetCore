using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace introNetCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Ürün fiyatı boş olamaz")]       
        public decimal? Price { get; set; }
    }
}
