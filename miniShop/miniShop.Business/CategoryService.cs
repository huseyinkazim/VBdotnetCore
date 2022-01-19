using miniShop.DataAccess;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class CategoryService : ICategoryService
    {
        private MiniShopDbContext miniShopDbContext;

        public CategoryService(MiniShopDbContext miniShopDbContext)
        {
            this.miniShopDbContext = miniShopDbContext;
        }
        public IList<Category> GetCategories()
        {
            return this.miniShopDbContext.Categories.ToList();
        }
    }
}
