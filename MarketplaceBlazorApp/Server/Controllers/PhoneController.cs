using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.DataEngine;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        [HttpGet("{userID}")]
        public async Task<IEnumerable<PhoneModel>> GetPhones(int userID)
        {
            PhoneDE phoneDE = new PhoneDE();
            return await phoneDE.GetPhonesByUserID(userID);
        }

        [HttpPut]
        public async Task AddOrEdit([FromBody] PhoneModel phoneModel)
        {
            PhoneDE phoneDE = new PhoneDE();
            await phoneDE.AddOrEditPhone(phoneModel);
        }

        [HttpDelete("{phoneID}")]
        public async Task Delete(int phoneID)
        {
            PhoneDE phoneDE = new PhoneDE();
            await phoneDE.DeletePhone(phoneID);
        }
    }
}