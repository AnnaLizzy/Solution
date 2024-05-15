using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="doorPowerMangeService"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class PowerManagerController(IDoorPowerMangeService doorPowerMangeService) : ControllerBase
    {
        private readonly IDoorPowerMangeService _doorPowerMangeService = doorPowerMangeService;
        /// <summary>
        /// get all 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// get door power manager by bg id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetDoorPowerManager(int id)
        {
            var data = await _doorPowerMangeService.GetDoorPowerManager(id);
            return Ok(data);
        }
        /// <summary>
        /// get by employee no
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("GetEmpNo/{empNo}")]
        //public async Task<IActionResult> GetDoorPowerMangerByEmpNo(string empNo)
        //{
        //    var result = await _doorPowerMangeService.GetDoorPowerManagerByEmp(empNo);
        //    if(result == null)
        //    {
        //        return BadRequest("Error");
        //    }
        //    return Ok(result);
        //}
    }
}
