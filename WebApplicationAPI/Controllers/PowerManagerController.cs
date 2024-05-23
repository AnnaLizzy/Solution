using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="doorPowerMangeService"></param>
    /// <param name="emailSender"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class PowerManagerController(IDoorPowerMangeService doorPowerMangeService, IEmailSender emailSender) : ControllerBase
    {
        private readonly IDoorPowerMangeService _doorPowerMangeService = doorPowerMangeService;
        private readonly IEmailSender _emailService = emailSender;       
        /// <summary>
        /// get all 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDoorPowerManager()
        {
            if (!ModelState.IsValid)
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
        [HttpGet]
        [Route("GetEmpNo/{empNo}")]
        public async Task<IActionResult> GetDoorPowerMangerByEmpNo(string empNo)
        {
            if (string.IsNullOrEmpty(empNo))
            {
                return BadRequest("Please enter employee no");
            }
            var result = await _doorPowerMangeService.GetDoorPowerManagerByEmp(empNo);
            if (result == null)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }
        /// <summary>
        /// Send mail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> SendEmail([FromForm] SendMail model)
        {
            if (string.IsNullOrEmpty(model.To))
            {
                return BadRequest("Please enter email");
            }        
            await _emailService.SendEmailAsync(model.To, model.Subject ?? string.Empty,model.Body ?? "");           
            return Ok();
        }
    }
}
