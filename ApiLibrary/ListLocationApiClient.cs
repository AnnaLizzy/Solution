using ApiLibrary.ViewModels;
using ApiLibrary.Interfaces;
using WebApplicationAPI.Constants;
using ApiLibrary.Constants;
using Microsoft.AspNetCore.Http;
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
            //Handle Area and Region
            var areaName = await _areaApiClient.GetArea(int.Parse(location.Area!));
            var areResult = areaName.ShortName;
            var AreaName = areaName.AreaName;
            string? regResult = null;
            if (location.Region != "no data")
            {
                var regionName = await _regionApiClient.GetRegionByID(int.Parse(location.Region!));
                regResult = regionName.RegionName;
            }
            var locationID = areResult + "-" + (regResult ?? "");
           

            //Insert data to database
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(locationID ?? ""), "LocationID" },
                { new StringContent(location.LocationName ?? ""), "LocationName" },
                { new StringContent(AreaName ?? ""), "Area" },
                { new StringContent(location.Floors?.ToString() ?? ""), "Floors" },
                { new StringContent(regResult ?? "no data"), "Region" },
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
            var ListID = response.Content.ReadAsStringAsync().Result;
            var body = "Location ID: " + ListID + " has been created by "+ location.EmployeeNo+". Please click link here to sign "
                + $"<a href='https://localhost:44334/Location/Sign/{ListID}'>Click here</a>";
            await SendMail("thienthantihon29@gmail.com", "Location has been created", body);
            return response.IsSuccessStatusCode  ;
        }
        public async Task<bool> SendMail(string email, string subject, string body)
        {
            
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
                var requestContent = new MultipartFormDataContent
            {
                { new StringContent(email), "to" },
                { new StringContent(subject), "subject" },
                { new StringContent(body), "body" }
            };
                var response = await client.PostAsync("api/PowerManager/Send", requestContent);
                return response.IsSuccessStatusCode;       
           
        }
        public async Task<bool> SignLocation(int id,ListLocationVM locationVM)
        {
            var sessions = _httpContextAccessor.HttpContext?.Session.GetString(SystemApiConst.Setting.Token);
            if (string.IsNullOrEmpty(sessions))
            {
                throw new InvalidOperationException("Session token is missing.");
            }
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent
            {
                {new StringContent(locationVM.SignStatus.ToString() ),"SignStatus"},
               
            };      
            var response = await client.PostAsync($"api/Location/SignLocation/{id}", requestContent);

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
            if (string.IsNullOrEmpty(sessions))
            {
                throw new InvalidOperationException("Session token is missing.");
            }
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location), "Please enter Location");
            }
            var areaName = await _areaApiClient.GetArea(int.Parse(location.Area!));
            var areResult = areaName.ShortName;
            var AreaName = areaName.AreaName;
            string? regResult = null;
            if (location.Region != "no data")
            {
                var regionName = await _regionApiClient.GetRegionByID(int.Parse(location.Region!));
                regResult = regionName.RegionName;
            }

            var locationID = areResult + "-" + (regResult ?? "");
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(locationID ?? ""), "LocationID" },
                { new StringContent(location.LocationName ?? ""), "LocationName" },
                { new StringContent(AreaName ?? ""), "Area" },
                { new StringContent(location.Floors?.ToString() ?? ""), "Floors" },
                { new StringContent(regResult ?? ""), "Region" },
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
