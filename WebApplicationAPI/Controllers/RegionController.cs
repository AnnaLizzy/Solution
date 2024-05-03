using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(IRegionService region) : Controller
    {
        private readonly IRegionService _region = region;
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRegions")]
        public async Task<IActionResult> GetRegions()
        {
            var data = await _region.GetRegions();
            return Ok(data);
        }
        /// <summary>
        /// get region by area id 
        /// ex: GetRegion/3/byAreaID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRegion/{id}/byAreaID")]
        public async Task<IActionResult> GetRegion(int id)
        {
            var data = await _region.GetRegion(id);
            return Ok(data);
        }
    }
}
