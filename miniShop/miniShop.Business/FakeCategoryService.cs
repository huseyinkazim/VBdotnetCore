using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class FakeCategoryService : ICategoryService
    {
        public IList<Category> GetCategories()
        {
            return new List<Category>
           {
               new Category{ Id=1, Name="Elektronik"},
               new Category{ Id=2, Name="Giyim"},
               new Category{ Id=3, Name="Kozmetik"},


           };
        }
    }
}
