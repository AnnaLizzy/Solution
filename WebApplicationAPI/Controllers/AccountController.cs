﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController(IEmployeeService employeeService,
        IConfiguration configuration)      : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
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
        [AllowAnonymous]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDTO model)
        {

             await _employeeService.CreateEmployee( model);
            return Ok("Success");
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
            await _employeeService.UpdateEmployee(id, model);
            return Ok("Success");
        }
      
        
    }
}