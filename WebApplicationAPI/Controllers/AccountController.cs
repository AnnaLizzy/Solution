﻿using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace WebApplicationAPI.Controllers
{
    /// <summary>
    /// Employees
    /// </summary>
    /// <param name="employeeService"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController(IEmployeeService employeeService)  : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>result</returns>
        /// <remarks>
        /// Sample: 
        ///       Username : V0515311
        ///       Password: 123456
        /// </remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _employeeService.Authenticate(model);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        } 
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<IActionResult> GetEmployee()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _employeeService.GetEmployees();
            return Ok(data);
        }
        /// <summary>
        /// get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]     
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _employeeService.GetEmployee(id);
            return Ok(data);
        }
        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]       
        public async Task<IActionResult> DeleteEmployeeByID(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok("Employee deleted");
        }
        /// <summary>
        /// Create employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]       
        public async Task<IActionResult> PostEmployee([FromForm] EmployeeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _employeeService.CreateEmployee(model);
                return Ok("Nhân viên đã được thêm thành công.");
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { message = ex.Message });
            }            
        }
        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _employeeService.UpdateEmployee(id, model);
                return Ok("Success");
            }
            catch(Exception ex) { return StatusCode(500, new { message = ex.Message }); }            
        }     
        
    }
}
