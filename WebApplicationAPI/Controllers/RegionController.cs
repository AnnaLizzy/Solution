using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(IRegionService region) : Controller
    {
        private readonly IRegionService _region = region;
        [HttpGet]
        [Route("GetRegions")]
        public async Task<IActionResult> GetRegions()
        {
            var data = await _region.GetRegions();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetRegion/{id}/byAreaID")]
        public async Task<IActionResult> GetRegion(int id)
        {
            var data = await _region.GetRegion(id);
            return Ok(data);
        }
    }
}
