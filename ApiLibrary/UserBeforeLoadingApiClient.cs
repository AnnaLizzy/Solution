using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;

namespace ApiLibrary
{
    public class UserBeforeLoadingApiClient(HttpClient httpClient,IHttpClientFactory clientFactory) 
        : BaseApiClient(httpClient,clientFactory), IUserBeforeLoadingApiClient
    {       
        public async Task<List<UserBeforeLoadingViewModel>> GetAll()
        {
           return await GetAsync<List<UserBeforeLoadingViewModel>>("api/UserBeforeLoading") ?? throw new Exception("Error occured");
        }

        public async Task<UserBeforeLoadingViewModel> GetById(int id)
        {
           return await GetAsync<UserBeforeLoadingViewModel>("api/UserBeforeLoading/" + id) ?? throw new Exception("Error occured ");  
        }
    }
}
