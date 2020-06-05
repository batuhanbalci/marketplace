using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.DataEngine;
using MarketplaceBlazorApp.Shared;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            ItemDE itemDE = new ItemDE();
            return await itemDE.GetItems();
        }

        [AllowAnonymous]
        [HttpGet("{itemID}/{userID}")]
        public async Task<IEnumerable<ItemModel>> GetItem(int itemID, int userID)
        {
            ItemDE itemDE = new ItemDE();
            return await itemDE.GetItemWithPhotos(itemID, userID);
        }

        [Route("[action]")]     //PUT???
        [HttpPost]
        public async Task MakeProfilePhoto([FromBody] ItemPhotoModel itemPhoto)
        {
            ItemDE itemDE = new ItemDE();
            await itemDE.MakeProfilePhoto(itemPhoto.ItemID, itemPhoto.Path);
        }

        [Route("[action]")]
        [HttpPut]
        public async Task UpdateItem([FromBody] ItemModel item)
        {
            ItemDE itemDE = new ItemDE();
            await itemDE.AddOrEditItem(item);
        }

        [Route("[action]")]
        [AllowAnonymous]
        [HttpPost]
        public async Task UpdateClickCount([FromBody] int itemID)
        {
            ItemDE itemDE = new ItemDE();
            await itemDE.IncreaseClickCount(itemID);
        }
    }
}