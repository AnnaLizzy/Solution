namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
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
        /// <summary>
        /// Get user by BgID
        /// </summary>
        /// <param name="bgId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/bg/{bgId}")]
        public async Task<IActionResult> GetUserBeforeLoading(int bgId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _userBeforeLoadingService.GetUserBeforeLoadingByBG(bgId);
            return Ok(data);
        }
        /// <summary>
        /// getbyid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserBeforeLoadingById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _userBeforeLoadingService.GetUserBeforeLoadingById(id);
            return Ok(data);
        }
    }
}
