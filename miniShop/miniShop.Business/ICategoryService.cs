using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
  public interface ICategoryService
    {
        //You Ain't gonna need it : YAGNI
        public IList<Category> GetCategories();
    }
}
