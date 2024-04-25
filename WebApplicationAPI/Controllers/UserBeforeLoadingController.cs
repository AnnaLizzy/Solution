using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBeforeLoadingController(IUserBeforeLoadingService service) : ControllerBase
    {
        private readonly IUserBeforeLoadingService _userBeforeLoadingService = service;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserBeforeLoading()
        {
            var data = await _userBeforeLoadingService.GetUserBeforeLoading();
            return Ok(data);
        }
        [HttpGet("/bgId")]
        public async Task<IActionResult> GetUserBeforeLoading(int bgId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _userBeforeLoadingService.GetUserBeforeLoadingByBG(bgId);
            return Ok(data);
        }
    }
}
