using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("[action]/{itemID}")]
        public async Task<IActionResult> Upload(IFormFile[] files, int itemID)
        {
            ImageController imageController = new ImageController();
            try
            {
                if (files != null && files.Length > 0)
                {
                    string path = _env.ContentRootPath + "/../Client/wwwroot/img/";

                    foreach (var file in files)
                    {
                        using (FileStream fs = new FileStream(path + file.FileName, FileMode.Create, FileAccess.Write))
                        {
                            await file.CopyToAsync(fs);
                        }
                        await imageController.SaveItemPhoto(itemID, file.FileName);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }


}

