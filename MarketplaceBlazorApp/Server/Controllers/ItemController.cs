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
        [HttpGet]
        public IEnumerable<ItemModel> GetAllItems()
        {
            return ItemDE.GetItems();
        }

        [HttpGet("{itemID}")]
        public IEnumerable<ItemModel> GetItem(int itemID)
        {
            return ItemDE.GetItemWithPhotos(itemID);
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
    }
}