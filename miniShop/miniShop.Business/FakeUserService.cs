using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
    public class FakeUserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User { Id=1, UserName="turkay", Name="Türkay Ürkmez" ,Password="123", Role="Admin", Email="turkay.urkmez@dinamikzihin.com"},
            new User { Id=2, UserName="user1",Name="name lastname", Password="123", Role="Admin", Email="user1@dinamikzihin.com"},
            new User { Id=3, UserName="user2",Name="name lastname", Password="123", Role="User", Email="user2@dinamikzihin.com"},
            new User { Id=4, UserName="user3",Name="name lastname", Password="123", Role="Editor", Email="user3@dinamikzihin.com"},

        };
        public User ValidateUser(string username, string password)
        {
            //throw new Exception("Örnek hata");
            return users.FirstOrDefault(u => u.UserName == username && u.Password == password);

        }
    }
}
