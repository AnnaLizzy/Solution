using ApiLibrary.Constants;
using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;

namespace ApiLibrary
{
    public class PowerManagerApiClient
        (HttpClient httpClient, IHttpClientFactory httpClientFactory)
        : BaseApiClient(httpClient,httpClientFactory),IPowerManagerApiClient
    {
        public async Task<List<PowerManagerViewModel>> GetPowerManager()
        {
            return await GetAsync<List<PowerManagerViewModel>>("api/PowerManager")
                 ?? throw new Exception(SystemApiConst.MessageError.Error); ;
        }

        public async Task<PowerManagerViewModel> GetPowerManagerByEmpNo(string empNo)
        {
            return await GetAsync<PowerManagerViewModel>($"api/PowerManager/GetEmpNo/{empNo}")
                ?? throw new Exception(SystemApiConst.MessageError.Error);
        }
    }
}
