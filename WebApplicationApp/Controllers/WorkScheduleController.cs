using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApplicationAPI.Constants;

namespace WebApplicationApp.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class WorkScheduleController(IWorkScheduleApiClient workScheduleApi,
            IListLocationApiClient listLocationApiClient,IAreaApiClient areaApiClient,
            IWorkShiftApiClient shiftApiClient,
            IAccountApiClient accountApiClient,
            IHttpContextAccessor accessor
            ) : Controller
    {
        private readonly IWorkScheduleApiClient workScheduleApi = workScheduleApi;
        private readonly IListLocationApiClient listLocationApi = listLocationApiClient;
        private readonly IAreaApiClient areaApi = areaApiClient;
        private readonly IWorkShiftApiClient shiftApi = shiftApiClient;
        private readonly IAccountApiClient accountApi = accountApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor = accessor;
        
        public async Task<IActionResult> Index()
        {

            var data = await workScheduleApi.GetWorkSchedules();
            return View(data);
        }
       
        public async Task<IActionResult> ShowMap()
        {        
            ViewBag.GetLocationList = await GetListLocations();
            ViewBag.GetAreaList = await GetAreasAsync();
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await workScheduleApi.GetWorkSchedule(id);
            return View(data);
        }
        /// <summary>
        /// func get all areas
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<SelectListItem>> GetAreasAsync()
        {
            var getAreaList = await areaApi.GetAreas();
            var areaData = getAreaList.Select(a => new SelectListItem
            {
                Text = a.AreaName,
                Value = a.AreaID.ToString()
            });
            return areaData;
        }
        private async Task<IEnumerable<SelectListItem>> GetWorkShifts()
        {
            var getShiftList = await shiftApi.GetWorkShifts();
            var shiftData = getShiftList.Select(s => new SelectListItem
            {
                Text = s.NameShift,
                Value = s.ShiftID.ToString()
            });
            return shiftData;
        }
        private async Task<IEnumerable<SelectListItem>> GetListLocations()
        {
            var list = await listLocationApi.GetAllLocations();
            var locationData = list.Select(l => new SelectListItem
            {
                Text = l.LocationName,
                Value = l.LocationID?.ToString()
            });
            return locationData;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string? token = _httpContextAccessor?.HttpContext?.Session.GetString(SystemConstants.AppSetting.Token);

            ViewBag.GetAreaList = await GetAreasAsync();

            ViewBag.GetShiftList = await GetWorkShifts();
           
            ViewBag.GetLocationList = await GetListLocations();

            if (token != null)
            {
                var getEmployeeList = await accountApi.GetEmployees(token);

                IEnumerable<SelectListItem> employeeData = getEmployeeList.Select(e => new SelectListItem
                {
                    Text = e.EmployeeName,
                    Value = e.EmployeeID.ToString()
                });
                ViewBag.GetEmployeeList = employeeData;
            }
            else {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index", "Account");
            }
           
            return View();
        }

        [HttpPost]  
       // [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]CreateWorkScheduleViewModel workSchedule)
        {
            if (!ModelState.IsValid)
            {
                // ModelState không hợp lệ, hiển thị lại form tạo công việc với thông báo lỗi
                TempData["Error"] = "Create failed. Please check your input.";
                return View(workSchedule);
            }

            // Gọi API để tạo công việc
            var result = await workScheduleApi.CreateWorkSchedule(workSchedule);

            if (result)
            {
                // Tạo công việc thành công, chuyển hướng đến trang danh sách công việc
                TempData["Success"] = "Create successful";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Tạo công việc thất bại, hiển thị lại form tạo công việc với thông báo lỗi
                TempData["Error"] = "Create failed. Please try again later.";
                return View(workSchedule);
            }
        }
        /// <summary>
        /// Update work schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var workSchedule = await workScheduleApi.GetWorkSchedule(id);
            return View(workSchedule);
        }
        [HttpPost]    
        //[Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(int id, WorkScheduleViewModel workSchedule)
        {
            if (id != workSchedule.SchedulesID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await workScheduleApi.UpdateWorkSchedule(workSchedule);
                return RedirectToAction(nameof(Index));
            }
            return View(workSchedule);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var workSchedule = await workScheduleApi.GetWorkSchedule(id);
            return View(workSchedule);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await workScheduleApi.DeleteWorkSchedule(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
