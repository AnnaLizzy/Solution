namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listLocationService"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class ListLocationsController(IListLocationService listLocationService
        ) : ControllerBase
    {
        private readonly IListLocationService _listLocationService = listLocationService;
        /// <summary>
        /// Get tất cả các địa điểm 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // Get locations
        public async Task<IActionResult> GetLocations()
        {
            var data = await _listLocationService.GetLocations();
            if (data == null)
            {
                return BadRequest("ko co du lieu");
            }
            return Ok(data);
        }
        /// <summary>
        /// lấy địa điểm theo id khu vực 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationByAreaID(int id)
        {
            var data = await _listLocationService.GetLocationByAreaID(id);
            if (data == null)
            {
                return BadRequest($"không có dữ liệu vỡi id : {id}");
            }
            return Ok(data);
        }
        /// <summary>
        /// Post location
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        // create location
        public IActionResult PostLocation()
        {
            return Ok("PostLocation");
        }
        /// <summary>
        /// Update location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchLocation(int id)
        {
            return Ok("PatchLocation");
        }
    }
}
