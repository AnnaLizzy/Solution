using ApiLibrary.ViewModels;
using ApiLibrary.Interfaces;
using System.Net.Http;
using WebApplicationAPI.Constants;
using ApiLibrary.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace ApiLibrary
{
    public class ListLocationApiClient(HttpClient httpClient, IHttpClientFactory httpClientFactory,
            IAreaApiClient area, IRegionApiClient region,
            IHttpContextAccessor accessor)
            : BaseApiClient(httpClient, httpClientFactory), IListLocationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IAreaApiClient _areaApiClient = area;
        private readonly IRegionApiClient _regionApiClient = region;
        private readonly IHttpContextAccessor _httpContextAccessor = accessor;
        private readonly string _baseUrl = SystemConstants.Url.BaseApiUrl;
        public async Task<bool> CreateLocation(ListLocationVM location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location), "Please enter Location");
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);

            if (location.StartTime > location.EndTime)
            {
                throw new Exception(SystemApiConst.MessageError.StartTimeGreaterThanEndTime);
            }

            var areaName = await _areaApiClient.GetArea(int.Parse(location.Area!));
            var areResult = areaName.ShortName;

            string? regResult = null;
            if (location.Region != "no data")
            {
                var regionName = await _regionApiClient.GetRegionByID(int.Parse(location.Region!));
                regResult = regionName.RegionName;
            }

            var locationID = areResult + (regResult ?? "");

            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(locationID ?? ""), "LocationID" },
                { new StringContent(location.LocationName ?? ""), "LocationName" },
                { new StringContent(areResult ?? ""), "Area" },
                { new StringContent(location.Floors?.ToString() ?? ""), "Floors" },
                { new StringContent(location.Region ?? "no data"), "Region" },
                { new StringContent(location.Building ?? ""), "Building" },
                { new StringContent(location.Azimuth ?? ""), "Azimuth" },
                { new StringContent(location.StationType ?? ""), "StationType" },
                { new StringContent(location.Other ?? ""), "Other" },
                { new StringContent(location.StartTime.ToString() ?? ""), "StartTime" },
                { new StringContent(location.EndTime.ToString() ?? ""), "EndTime" },
                { new StringContent(location.SignUser ?? ""), "SignUser" },
                { new StringContent(location.EmployeeNo ?? ""), "EmployeeNo" }
            };

            var response = await client.PostAsync("api/Location", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLocation(int id)
        {
            return await DeleteAsync($"api/Location/{id}");

        }

        public async Task<List<ListLocationVM>> GetAllLocations()
        {
            return await GetAsync<List<ListLocationVM>>("api/Location")
                ?? throw new Exception(SystemApiConst.MessageError.Error);
        }

        public async Task<ListLocationVM> GetLocationById(int id)
        {
            return await GetAsync<ListLocationVM>($"api/Location/{id}")
                ?? throw new Exception(SystemApiConst.MessageError.Error);
        }

        public async Task<bool> UpdateLocation(int id, ListLocationVM location)
        {
            var sessions = _httpContextAccessor.HttpContext?.Session.GetString(SystemApiConst.Setting.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location), "Please enter Location");
            }
            var areaName = await _areaApiClient.GetArea(int.Parse(location.Area!));
            var areResult = areaName.ShortName;            
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(location.LocationName ?? ""), "LocationName" },
                { new StringContent(areResult ?? ""), "Area" },
                { new StringContent(location.Floors?.ToString() ?? ""), "Floors" },
                { new StringContent(location.Region ?? ""), "Region" },
                { new StringContent(location.Building ?? ""), "Building" },
                { new StringContent(location.Azimuth ?? ""), "Azimuth" },
                { new StringContent(location.StationType ?? ""), "StationType" },
                { new StringContent(location.Other ?? ""), "Other" },
                { new StringContent(location.StartTime.ToString() ?? ""), "StartTime" },
                { new StringContent(location.EndTime.ToString() ?? ""), "EndTime" },
                { new StringContent(location.SignUser ?? ""), "SignUser" }                
            };
            var response = await client.PatchAsync($"api/Location/{id}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
