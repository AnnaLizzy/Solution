using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exception;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkScheduleController : ControllerBase
    {
    private readonly IWorkScheduleService _workScheduleService;
        public WorkScheduleController(IWorkScheduleService workScheduleService)
        {
            _workScheduleService = workScheduleService;
        }
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
        /// <summary>
        /// Create work schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateWorkSchedule( WorkScheduleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           await _workScheduleService.CreateWorkSchedule(model)    ;
           
         
            return Ok();
        }
        /// <summary>
        /// Delete work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkSchedule(int id)
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
        public async Task<ActionResult> UpdateWorkSchedule(int id, WorkScheduleDTO model)
        {
            await _workScheduleService.UpdateWorkSchedule(id, model);
            return Ok();
        }
    }
}
