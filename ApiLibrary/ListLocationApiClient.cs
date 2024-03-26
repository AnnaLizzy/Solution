using ApiLibrary.ViewModels;
using ApiLibrary.Interfaces;

namespace ApiLibrary
{
    public class ListLocationApiClient(HttpClient httpClient) : BaseApiClient(httpClient), IListLocationApiClient
    {
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
