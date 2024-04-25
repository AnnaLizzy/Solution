using ApiLibrary.ViewModels;
using ApiLibrary.Interfaces;
using System.Net.Http;
using WebApplicationAPI.Constants;

namespace ApiLibrary
{
    public class ListLocationApiClient(HttpClient httpClient,IHttpClientFactory httpClientFactory) 
        : BaseApiClient(httpClient,httpClientFactory), IListLocationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
      
        public async Task<bool> CreateLocation(ListLocationVM location)
        {
            if(location == null)
            {
                throw new ArgumentNullException(nameof(location), "Please enter Location");
            }
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(location.ListID.ToString()), "ListID" },
                { new StringContent(location.LocationID?.ToString() ?? ""), "LocationID" },
                { new StringContent(location.LocationName ?? ""), "LocationName" },
                { new StringContent(location.Area ?? ""), "Area" },
                { new StringContent(location.Floors?.ToString() ?? ""), "Floors" },
                { new StringContent(location.X?.ToString() ?? ""), "X" },
                { new StringContent(location.Y?.ToString() ?? ""), "Y" },
                { new StringContent(location.Region ?? ""), "Region" }
            };
            var respone = await client.PostAsync("/api/Locations", requestContent);
           return respone.IsSuccessStatusCode;
        }

        public async Task<List<ListLocationVM>> GetAllLocations()
        {           
            return await GetAsync<List<ListLocationVM>>("api/Location")
                ?? throw new Exception("Da co loi xay ra");
        }

        public async Task<List<ListLocationVM>> GetLocation(int id)
        {
            return await GetAsync<List<ListLocationVM>>($"api/ListLocations/{id}")//get location by areaid
                ?? throw new Exception("khong tim thay dia diem");
                
        }
        
    }
}
