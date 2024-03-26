using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationApp.Controllers
{
    public class WorkScheduleController(IWorkScheduleApiClient workScheduleApi,
            IListLocationApiClient listLocationApiClient,IAreaApiClient areaApiClient) : Controller
    {
        private readonly IWorkScheduleApiClient workScheduleApi = workScheduleApi;
        private readonly IListLocationApiClient listLocationApi = listLocationApiClient;
        private readonly IAreaApiClient areaApi = areaApiClient;
        public async Task<IActionResult> Index()
        {

            var data = await workScheduleApi.GetWorkSchedules();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await workScheduleApi.GetWorkSchedule(id);
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            var getAreaList = await areaApi.GetAreas();
            IEnumerable<SelectListItem> areaData = getAreaList.Select(a => new SelectListItem
            {
                Text = a.AreaName,
                Value = a.AreaID.ToString()
            });
            ViewBag.GetAreaList = areaData;
         
            //List<ListLocationVM>? locationList;

            //switch (areaData.FirstOrDefault()?.Value)
            //{
            //    case "3":
            //        locationList = await listLocationApi.GetLocation(3);                   
            //        ViewBag.LocationList = locationList?.Select(l => new SelectListItem
            //        {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        break;
            //    case "99":
            //        locationList = await listLocationApi.GetLocation(99);                    
            //        ViewBag.LocationList = locationList?.Select(l => new SelectListItem
            //        {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        break;
            //    case "101":
            //        locationList = await listLocationApi.GetLocation(101);                   
            //        ViewBag.LocationList = locationList?.Select(l => new SelectListItem
            //        {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        break;
            //    case "5":
            //        var locationList5 = await listLocationApi.GetLocation(5);
            //       ViewBag.LocationList = locationList5.Select(l => new SelectListItem
            //       {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        break;
            //    case "11":
            //        var locationList11 = await listLocationApi.GetLocation(11);
            //        ViewBag.LocationList = locationList11.Select(l => new SelectListItem
            //        {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        break;
            //    default:
            //        var allLocationList = await listLocationApi.GetAllLocations();
            //        IEnumerable<SelectListItem> allLocationData = allLocationList.Select(l => new SelectListItem
            //        {
            //            Text = l.LocationName,
            //            Value = l.LocationID?.ToString()
            //        });
            //        ViewBag.LocationList = allLocationData;
            //        break;
            //}

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWorkScheduleViewModel workSchedule)
        {
            if (ModelState.IsValid)
            {
                await workScheduleApi.CreateWorkSchedule(workSchedule);
                return RedirectToAction(nameof(Index));
            }
            return View(workSchedule);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var workSchedule = await workScheduleApi.GetWorkSchedule(id);
            return View(workSchedule);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
