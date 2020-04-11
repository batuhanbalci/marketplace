using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceBlazorApp.Server.DataEngine;

namespace MarketplaceBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private RegionDE regionDE;
        public RegionController()
        {
            regionDE = new RegionDE();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Cities()
        {
            return new JsonResult(regionDE.GetRegionCities());
        }

        [Route("[action]/{cityID}")]
        [HttpGet]
        public JsonResult Counties(int cityID)
        {
            return new JsonResult(regionDE.GetRegionCounties(cityID));
        }

        [Route("[action]/{countyID}")]
        [HttpGet]
        public JsonResult Districts(int countyID)
        {
            return new JsonResult(regionDE.GetRegionDistricts(countyID));
        }

        [Route("[action]/{districtID}")]
        [HttpGet]
        public JsonResult Neighborhoods(int districtID)
        {
            return new JsonResult(regionDE.GetRegionNeighborhoods(districtID));
        }
    }
}