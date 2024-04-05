using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exception;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        private readonly ILocationService _locationService = locationService;

        /// <summary>
        /// Get all locations
        /// </summary>
        /// <returns>Returns all locations</returns>
        /// <remarks>
        /// examlpe :
        ///     get All location
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLocationByAreaID(int id)
        {
            var data = await _locationService.GetLocation(id);
            if (data == null)
            {
                return BadRequest($"không có dữ liệu vỡi id : {id}");
            }
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateLocation([FromBody] LocationDTO model)
        {
            await _locationService.CreateLocation(model);
            return Ok();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDTO model)
        {
            await _locationService.UpdateLocation(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                await _locationService.DeleteLocation(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest($"Failed to delete location with id: {id}. Error: {ex.Message}");
            }
        }
    }
}
