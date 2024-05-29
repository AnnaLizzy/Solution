namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="region"></param>
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
        /// </summary>
        /// <remarks>
        /// example: id = 3 QV3
        ///    [
        ///    
        ///    ]
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRegion/{id}/byAreaID")]
        public async Task<IActionResult> GetRegion(int id)
        {
            var data = await _region.GetRegion(id);
            return Ok(data);
        }
        /// <summary>
        /// get region by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRegionById/{id}")]
        public async Task<IActionResult> GetRegionByID (int id)
        {
            var data = await _region.GetRegionByID(id);
            if(data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
