using MarketplaceBlazorApp.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketplaceBlazorApp.DataEngine;
using MarketplaceBlazorApp.Client.Pages;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] AuthenticateModel login)
        {
            LoginResultModel umodel = new LoginResultModel(); // TO DO : user modelsiz yap ya da daha efficient
            UserDE userDE = new UserDE();
            umodel = userDE.UserLogin(login);

            if (umodel == null)
            {
                return BadRequest(new LoginResultModel { Successful = false, Error = "Hatalı mail veya şifre." });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Mail),
                new Claim(ClaimTypes.Role, umodel.Role.ToString()),
                new Claim(ClaimTypes.PrimarySid, umodel.UserID.ToString())//?? gerekli mi
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            //umodel.Successful = true;
            //umodel.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new LoginResultModel { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}