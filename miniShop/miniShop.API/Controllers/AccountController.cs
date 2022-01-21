using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using miniShop.API.Models;
using miniShop.Business;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
            if (user!=null)
            {
                JwtSecurityToken token = GenerateToken(user);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest(new { message = "Hatalı...." });
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var key = "Bu cumle aramizda kalsin";
            var issuer = "turkayurkmez";
            var auidience = "turkayurkmez";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: auidience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: credential
                );

            return token;
        }
    }
}
