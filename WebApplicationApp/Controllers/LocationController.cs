using Microsoft.AspNetCore.Mvc;
using ApiLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiLibrary.ViewModels;
using System.Security.Claims;
using WebApplicationApp.ViewModels;



namespace WebApplicationApp.Controllers
{
    public class LocationController(IListLocationApiClient listLocationApiClient
        , IAreaApiClient areaApiClient,
        IRegionApiClient regionApiClient,
        IHttpContextAccessor ContextAccessor,
        IUserBeforeLoadingApiClient loadingApiClient) : Controller
    {
        private readonly IListLocationApiClient _listLocationApiClient = listLocationApiClient;
        private readonly IAreaApiClient _areaApiClient = areaApiClient;
        private readonly IRegionApiClient _regionApiClient = regionApiClient;
        private readonly IHttpContextAccessor httpContextAccessor = ContextAccessor;
        private readonly IUserBeforeLoadingApiClient userBeforeLoadingApiClient = loadingApiClient;
        public async Task<IActionResult> Index()
        {

            var data = await _listLocationApiClient.GetAllLocations();
            return View(data);

        }
    
        private async Task<IEnumerable<SelectListItem>> GetAreasAsync()
        {
            var getAreaList = await _areaApiClient.GetAreas();
            var areaData = getAreaList.Select(a => new SelectListItem
            {
                Text = a.AreaName,
                Value = a.AreaID.ToString()
            });
            return areaData;
        }
      
       
        private async Task<UserBeforeLoadingViewModel> GetUserInfor()
        {
            // Lấy userId từ HttpContextAccessor
            var userIdString = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
           
            if(userIdString == null)
            {
                return null;
            }
            // Chuyển đổi userIdString sang kiểu int bằng int.Parse()
            int userIdInt = int.Parse(userIdString!);

            // Thực hiện truy vấn data
            var data = await userBeforeLoadingApiClient.GetById(userIdInt);
            return data;
        }      
        public async Task<IActionResult> Create()
        {
            // Lấy thông tin người dùng
            var userInfo = await GetUserInfor();
            if (userInfo != null)
            {
                ViewBag.UserNO = userInfo.EmployeeNo;
                ViewBag.UserName = userInfo.EmployeeName;
                ViewBag.Notes = userInfo.Notes;
                ViewBag.BU = userInfo.BUCode;
            }
            else
            {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index","Account");
            }
              
            ViewBag.GetAreas = await GetAreasAsync();
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ListLocationVM request)
        {
            var userInfo = await GetUserInfor();
            if (userInfo != null)
            {
                ViewBag.UserNO = userInfo.EmployeeNo;
                ViewBag.UserName = userInfo.EmployeeName;
                ViewBag.Notes = userInfo.Notes;
                ViewBag.BU = userInfo.BUCode;
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Create failed. Please check your input.";
                return View(request);
            }
            
            var data = await _listLocationApiClient.CreateLocation(request);
            if(data == true)
            {
                TempData["Success"] = "Create successful";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Create failed. Please try later";
                return View(request);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            
            var data = await _listLocationApiClient.GetLocationById(id);
            if(data == null)
            {
                return BadRequest("không có dữ liệu");
            }
            return View(data);

        }      
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.GetAreas = await GetAreasAsync();
            var userInfo = await GetUserInfor();
            if (userInfo != null)
            {
                ViewBag.UserNO = userInfo.EmployeeNo;
                ViewBag.UserName = userInfo.EmployeeName;
                ViewBag.Notes = userInfo.Notes;
                ViewBag.BU = userInfo.BUCode;
            }
            var data = await _listLocationApiClient.GetLocationById(id);
            var result = new LocationsViewModel
            {
                LocationID = data.LocationID,
                LocationName = data.LocationName,
                Area = data.Area,
                Floors = data.Floors,
                Region = data.Region,
                Building = data.Building,
                Azimuth = data.Azimuth,
                StationType = data.StationType,
                Other = data.Other,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                SignUser = data.SignUser,
                EmployeeNo = data.EmployeeNo
            };
            if (result == null)
            {
                return BadRequest("không có dữ liệu");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id,[FromForm]ListLocationVM location)
        {
            if (location == null)
            {
                return BadRequest("không có dữ liệu");
            }
            var data = await _listLocationApiClient.UpdateLocation(id,location);
            if (data == false)
            {
                return BadRequest("không có dữ liệu");
            }
            return View(data);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _listLocationApiClient.DeleteLocation(id);
            if (data == false)
            {
                ViewData["error"] = "Xóa không thành công";
                return RedirectToAction("Index");

            }
            ViewData["success"] = "Xóa thành công";
            return RedirectToAction("Index");
        }
    }
}
