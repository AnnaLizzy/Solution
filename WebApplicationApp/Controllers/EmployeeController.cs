using ApiLibrary.ViewModels;

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
        public async Task<IActionResult> Details(int id)
        {
            string? token = _httpContextAccessor?.HttpContext?.Session.GetString(SystemConstants.AppSetting.Token);
            if (token == null)
            {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index", "Account");
            }
            var data = await _employeeApiClient.GetEmployee(id,token);
            return View(data);
        }
        public async Task<IActionResult> Edit(EmployeeViewModel request)
        {
            string? token = _httpContextAccessor?.HttpContext?.Session.GetString(SystemConstants.AppSetting.Token);
            if (token == null)
            {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index", "Account");
            }
            var data = await _employeeApiClient.UpdateEmployee(request);
            return View(data);
        }
    }
}
