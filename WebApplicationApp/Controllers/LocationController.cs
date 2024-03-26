using Microsoft.AspNetCore.Mvc;
using ApiLibrary.Interfaces;
using WebApplicationApp.Models;



namespace WebApplicationApp.Controllers
{
    public class LocationController(IListLocationApiClient listLocationApiClient, IAreaApiClient areaApiClient) : Controller
    {
        private readonly IListLocationApiClient _listLocationApiClient = listLocationApiClient;
        private readonly IAreaApiClient _areaApiClient = areaApiClient;
        public async Task<IActionResult> Index()
        {

            var locations = await _listLocationApiClient.GetAllLocations();
            var areas = await _areaApiClient.GetAreas();

            var listLocation = new ListLocation()
            {
                Location = locations,
                Area = areas
            };

            return View(listLocation);

        }
    }
}
