using Microsoft.AspNetCore.Mvc;
using ApiLibrary.Interfaces;
using WebApplicationApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApplicationApp.Controllers
{
    public class LocationController(IListLocationApiClient listLocationApiClient
        , IAreaApiClient areaApiClient,
        IRegionApiClient regionApiClient) : Controller
    {
        private readonly IListLocationApiClient _listLocationApiClient = listLocationApiClient;
        private readonly IAreaApiClient _areaApiClient = areaApiClient;
        private readonly IRegionApiClient _regionApiClient = regionApiClient;
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
       
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.GetAreas = await GetAreasAsync();
            return View();
        }
        


    }
}
