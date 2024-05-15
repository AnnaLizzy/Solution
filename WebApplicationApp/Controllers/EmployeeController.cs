using ApiLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Constants;

namespace WebApplicationApp.Controllers
{
    public class EmployeeController(IEmployeeApiClient employee, IHttpContextAccessor httpContextAccessor) : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient = employee;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public async Task<IActionResult> Index()
        {
            string? token = _httpContextAccessor?.HttpContext?.Session.GetString(SystemConstants.AppSetting.Token);
            if (token == null)
            {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index", "Account");
            }
            var data = await _employeeApiClient.GetEmployees(token);
            return View(data);
        }
    }
}
