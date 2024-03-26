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
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
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
        public async Task<IActionResult> CreateLocation([FromBody] LocationDTO model)
        {
             await _locationService.CreateLocation(model);
            return Ok();
          
           
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDTO model)
        {
            await _locationService.UpdateLocation(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
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
