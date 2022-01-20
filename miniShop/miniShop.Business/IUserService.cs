using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
   public interface IUserService
    {
        public User ValidateUser(string username, string password);
    }
}
