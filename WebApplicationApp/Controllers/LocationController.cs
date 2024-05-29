using Microsoft.AspNetCore.Mvc.Rendering;
using ApiLibrary.Constants;
using WebApplicationAPI.Models.Enum;
using ApiLibrary.ViewModels;



namespace WebApplicationApp.Controllers
{
    public class LocationController(IListLocationApiClient listLocationApiClient
        , IAreaApiClient areaApiClient,
        IRegionApiClient regionApiClient,
        IHttpContextAccessor ContextAccessor,
        IUserBeforeLoadingApiClient loadingApiClient
       ) : Controller
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
      
       
        private async Task<UserBeforeLoadingViewModel?> GetUserInfor()
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
            var session = httpContextAccessor?.HttpContext?.Session.GetString(SystemApiConst.Setting.Token);
            if (ModelState.IsValid && session != null)
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
                    return RedirectToAction("Index", "Account");
                }

                ViewBag.GetAreas = await GetAreasAsync();
                return View();
            }
            TempData["Error"] = "Please login to continue";
            return RedirectToAction("Index", "Account");
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
                TempData["Error"] = "Không có dữ liệu";
                return RedirectToAction("Index");
            }
            return View(data);
        }      
        public async Task<IActionResult> Update(int id)
        {
            var session = httpContextAccessor?.HttpContext?.Session.GetString(SystemApiConst.Setting.Token);
            if(session != null)
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
                return View(data);
            }      
            else
            {
                TempData["Error"] = "Please login to continue";
                return RedirectToAction("Index", "Account");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,[FromForm]ListLocationVM location)
        {
            var session = httpContextAccessor?.HttpContext?.Session.GetString(SystemApiConst.Setting.Token);            
            if (ModelState.IsValid && session != null)
            {
                // Kiểm tra nếu người dùng không thay đổi giá trị
                if (string.IsNullOrEmpty(location.Area) || string.IsNullOrEmpty(location.Region))
                {
                    // Lấy giá trị cũ từ cơ sở dữ liệu và gán lại cho model
                    var existingLocation = await _listLocationApiClient.GetLocationById(id);
                    location.Area = existingLocation.AreaID.ToString();
                    location.Region = existingLocation.RegionID.ToString();
                }

                var result = await _listLocationApiClient.UpdateLocation(id, location);
                if (result)
                {
                    TempData["Success"] = "Update successful";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Update failed. Please try later";
                }
            }
            TempData["Error"] = "Please login to continue";
            return View(location);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _listLocationApiClient.DeleteLocation(id);
            if (data == false)
            {
                ViewData["Error"] = "Xóa không thành công";
                return RedirectToAction("Index");

            }
            ViewData["Success"] = "Xóa thành công";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Sign(int id)
        {
            var data = await _listLocationApiClient.GetLocationById(id);
            var checkSign = new ListLocationVM
            {
                SignStatus = data.SignStatus
            };
            if(checkSign.SignStatus == Status.DA_KY)
            {
                TempData["Infor"] = "Đã ký";

                return View(data);
            }
            if (data == null)
            {
                ViewData["Error"] = "Không có dữ liệu";
                return View();
            }          
            return View(data);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Sign([FromRoute]int id,[FromForm] ListLocationVM model)
        {
            var result = await _listLocationApiClient.GetLocationById(id);

            var data = await _listLocationApiClient.SignLocation(id,model);
            if (data == false)
            {
                TempData["Error"] = "Ký không thành công";
                return View(result);
            }
            TempData["Success"] = "Ký thành công";
            return View(result);
        }
    }
}
