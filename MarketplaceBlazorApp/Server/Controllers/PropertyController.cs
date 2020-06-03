using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.Shared;
using MarketplaceBlazorApp.DataEngine;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        [HttpGet("{categoryID}/{propertyID}")]
        public async Task<IEnumerable<PropertyModel>> GetProperties(int categoryID = 0, int propertyID = 0)
        {
            PropertyDE propertDE = new PropertyDE();
            return await propertDE.Get(categoryID, propertyID);
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] PropertyModel property)
        {
            PropertyDE propertDE = new PropertyDE();
            await propertDE.AddOrEdit(property);
            return Ok();
        }
    }
}