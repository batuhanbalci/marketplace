using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.DataEngine;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public async Task SaveItemPhoto(int itemID = 0, string fileName = "")
        {
            ImageDE imageDE = new ImageDE();
            await imageDE.SaveItemPhoto(itemID, fileName);
        }

        [HttpDelete("{photoID}")]
        public async Task Delete(int photoID)
        {
            ImageDE imageDE = new ImageDE();
            await imageDE.DeletePhoto(photoID);
        }
    }
}