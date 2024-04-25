using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;

namespace ApiLibrary
{
    public class RegionApiClient(HttpClient httpClient, IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient,httpClientFactory),IRegionApiClient
    {
        public async Task<RegionsViewModel> GetRegion(int id)
        {
            return await GetAsync<RegionsViewModel>($"api/GetRegion/{id}/byAreaID")
                ?? throw new Exception("khong tim thay khu vuc");
        }

        public async Task<List<RegionsViewModel>> GetRegions()
        {
            return await GetAsync<List<RegionsViewModel>>("api/GetRegions")
                ?? throw new Exception("No data");
        }
    }
}
