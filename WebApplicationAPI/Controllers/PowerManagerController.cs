using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerManagerController(IDoorPowerMangeService doorPowerMangeService) : ControllerBase
    {
        private readonly IDoorPowerMangeService _doorPowerMangeService = doorPowerMangeService;

        [HttpGet]
        public async Task<IActionResult> GetDoorPowerManager()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _doorPowerMangeService.GetDoorPowerManager();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoorPowerManager(int id)
        {
            var data = await _doorPowerMangeService.GetDoorPowerManager(id);
            return Ok(data);
        }
    }
}
