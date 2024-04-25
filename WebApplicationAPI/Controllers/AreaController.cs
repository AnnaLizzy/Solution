using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AreaController(IAreaService areaService,
        ILocationService locationService,
        IWorkScheduleService workScheduleService) : ControllerBase
    {
        private readonly IAreaService _areaService = areaService;
        private readonly ILocationService _locationService = locationService;
        private readonly IWorkScheduleService _workScheduleService = workScheduleService;
        /// <summary>
        ///     Get all area
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetArea")]
        public async Task<IActionResult> GetArea()
        {
            var data = await _areaService.GetAreas();
            return Ok(data);
        }
        /// <summary>
        ///    Get area by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [HttpGet]
        [Route("GetArea/{id}")]
        public async Task<IActionResult> GetAreaByID(int id)
        {
            var data = await _areaService.GetArea(id) ?? throw new AppException($"Khong ton tai khu vuc voi id : {id}");

            return Ok(data);
        }
        /// <summary>
        ///  Lấy địa điểm theo id khu vực 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [HttpGet]
        [Route("GetArea/{id}/Location")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var data = await _locationService.GetLocation(id) ?? throw new AppException($"Khong ton tai dia diem voi id :{id}");
            return Ok(data);
        }
        /// <summary>
        ///    Get all locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var data = await _locationService.GetLocations();
            return Ok(data);
        }
        /// <summary>
        ///    Patch location by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> PatchLocation(int id, [FromBody] LocationDTO model)
        {
            await _locationService.UpdateLocation(id, model);
            return Ok("Success");
        }
        /// <summary>
        /// Delete location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/Location")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocation(id);
            return Ok("Location deleted");
        }
        /// <summary>
        /// Get all work schedule
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWorkSchedule")]
        public async Task<IActionResult> GetWorkSchedule()
        {
            var data = await _workScheduleService.GetWorkSchedules();
            return Ok(data);
        }
    }
}
