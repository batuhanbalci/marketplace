using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.DataEngine;
using Microsoft.AspNetCore.Authorization;
using MarketplaceBlazorApp.Server.Services;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody]AuthenticateModel model)
        {
            UserModel umodel = new UserModel();
            umodel.Mail = model.Mail;
            umodel.Password = model.Password;
            var user = _userService.Authenticate(umodel);

            if (user == null)
            {
                return BadRequest(new { message = "Login failed, incorrect information." });
            }

            return Ok(user);
        }

        [HttpGet("{userID}")]
        public async Task<IEnumerable<UserModel>> GetUsers(int userID = 0)
        {
            UserDE userDE = new UserDE();
            return await userDE.GetUsers(userID);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody] UserModel user)
        {
            UserDE userDE = new UserDE();
            await userDE.AddOrEdit(user);
        }
    }
}