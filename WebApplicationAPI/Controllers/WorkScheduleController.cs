using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkScheduleController(IWorkScheduleService workScheduleService) : ControllerBase
    {
    private readonly IWorkScheduleService _workScheduleService = workScheduleService;

        /// <summary>
        /// Get all work schedules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<WorkScheduleDTO>>> GetWorkSchedules()
        {
            var data = await _workScheduleService.GetWorkSchedules();
            if(data == null)
            {
                return BadRequest("No data");
            }
            return Ok(data);
        }
        /// <summary>
        /// Get work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkScheduleDTO>> GetWorkSchedule(int id)
        {
            var data = await _workScheduleService.GetWorkSchedule(id);
            if (data == null)
            {
                return BadRequest("No data");
            }
            return Ok(data);
        }
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<WorkScheduleDTO>> GetWorkScheduleByEmployeeId(int id)
        {
            var data = await _workScheduleService.GetWorkScheduleByEmployeeId(id);
            if (data == null)
            {
                return BadRequest("No data");
            }
            return Ok(data);
        }
        [HttpGet("location/{id}")]
        public async Task<ActionResult<WorkScheduleDTO>> GetWorkScheduleByLocationId(string id)
        {
            var data = await _workScheduleService.GetWorkScheduleByLocationId(id);
            if (data == null)
            {
                return BadRequest("No data");
            }
            return Ok(data);
        }
        /// <summary>
        /// Create work schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateWorkSchedule([FromForm] WorkScheduleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               var result =  await _workScheduleService.CreateWorkSchedule(model);
            if (result.ResultObj == true)
            {
                return Ok(result.Message);
            }
            else
            {
                ModelState.AddModelError("", result?.Message ?? "");
                return BadRequest(ModelState);
                
            }
            
            
        }
        /// <summary>
        /// Delete work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkSchedule(int id)
        {
            await _workScheduleService.DeleteWorkSchedule(id);
            return Ok();
        }
        /// <summary>
        /// Update work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateWorkSchedule(int id, WorkScheduleDTO model)
        {
            await _workScheduleService.UpdateWorkSchedule(id, model);
            return Ok();
        }
    }
}
