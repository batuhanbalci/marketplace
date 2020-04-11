using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.DataEngine;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("{categoryID}")]
        public IEnumerable<CategoryModel> GetCategories(int categoryID = 0)
        {
            return CategoryDE.GetCategories(categoryID); 
        }
    }
}