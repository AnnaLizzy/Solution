using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;

namespace ApiLibrary
{
    public class AreaApiClient(HttpClient httpClient) : BaseApiClient(httpClient), IAreaApiClient
    {
        public async Task<AreaViewModel> GetArea(int id)
        {
            return await GetAsync<AreaViewModel>($"api/Area/GetArea/{id}")
                ?? throw new Exception("khong tim thay khu vuc");
        }

        public async Task<List<AreaViewModel>> GetAreas()
        {
            return await GetAsync<List<AreaViewModel>>("api/Area/GetArea")
                ?? throw new Exception("Da co loi xay ra");
        }
    }
}
