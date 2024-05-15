using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workShiftService"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShiftController(IWorkShiftService workShiftService) : ControllerBase
    {
        private readonly IWorkShiftService _workShiftService = workShiftService;
        /// <summary>
        /// Get all work shifts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<WorkShiftDTO>>> GetWorkShifts()
        {
            return await _workShiftService.GetWorkShifts();
        }
        /// <summary>
        /// Get work shift by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkShiftDTO>> GetWorkShift(int id)
        {
            return await _workShiftService.GetWorkShiftByID(id);
        }
    }
}
