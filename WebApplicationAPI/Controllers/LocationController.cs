namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// Locations
    /// </summary>
    /// <param name="locationService"></param>  
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        private readonly ILocationService _locationService = locationService;
        //private readonly IEmailSender _emailService = emailSender;
        /// <summary>
        /// Get all locations
        /// </summary>
        /// <returns>Returns all locations</returns>
        /// <remarks>
        /// examlpe :
        ///     [
        ///     {
        ///"listID": 1,
        ///  "locationID": "QV-B01",
        ///  "locationName": "Cổng bảo vệ A1",
        ///  "area": "QV桂武",
        ///  "floors": "tầng 1",
        ///  "region": "1",
        ///  "areaID": 0,
        ///  "regionID": 0,
        ///  "azimuth": "Đông Bắc",
        ///  "stationType": "3 ca",
        ///  "building": "tòa B01",
        ///  "other": "ghi chú",
        ///  "startTime": "2024-05-01T00:00:00",
        ///  "endTime": "2024-05-31T00:00:00",
        ///  "signStatus": 2,
        ///  "signUser": null,
        ///  "signUserID": null,
        ///  "signDate": "0001-01-01T00:00:00",
        ///  "updateTime": "0001-01-01T00:00:00",
        ///  "createTime": "2024-05-17T09:44:00.7197493",
        ///  "employeeNo": null,
        ///  "notes": null
        ///},]
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var data = await _locationService.GetLocations();
            if (data == null)
            {
                return BadRequest("ko co du lieu");
            }
            return Ok(data);
        }
        /// <summary>
        /// Get location by ID
        /// </summary>
        /// <param name="id">The ID of the location</param>
        /// <returns>Returns the location with the specified ID</returns>
        [HttpGet("{id}")]    
        public async Task<IActionResult> GetLocationByID(int id)
        {
            var data = await _locationService.GetLocation(id);
            if (data == null)
            {
                return BadRequest($"không có dữ liệu vỡi id : {id}");
            }
            return Ok(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateLocation([FromForm] LocationDTO model)
        {
            if (model == null)
            {
                return BadRequest("Please enter Location");
            }
            var result = await _locationService.CreateLocation(model);

            if (result == 0)
            {
                return BadRequest("Create failed. Please check your input.");
            }
            return Ok(result);
        }
        /// <summary>
        /// Sign 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("SignLocation/{id}")]
        public async Task<IActionResult> SignLocation([FromRoute] int id, [FromForm] SignLocationDTO location)
        {
            try
            {
                var result = await _locationService.SignLocation(id, location);
                if (result == 0)
                {
                    return BadRequest("Sign failed. Please check your input.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete location with id: {id}. Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPatch("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromForm] LocationDTO model)
        {
            await _locationService.UpdateLocation(id, model);
            return Ok();
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                await _locationService.DeleteLocation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete location with id: {id}. Error: {ex.Message}");
            }
        }

    }
}
