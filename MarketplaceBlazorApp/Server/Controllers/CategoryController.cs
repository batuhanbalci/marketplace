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
    public class CategoryController : ControllerBase
    {
        [HttpGet("{categoryID}")]
        public async Task<IEnumerable<CategoryModel>> GetCategories(int categoryID = 0)
        {
            CategoryDE categoryDE = new CategoryDE();
            return await categoryDE.GetCategories(categoryID); 
        }

        [HttpPut]
        public async Task UpdateCategory([FromBody] CategoryModel category)
        {
            CategoryDE categoryDE = new CategoryDE();
            await categoryDE.AddOrEdit(category);
        }
    }
}