using ApiLibrary.Constants;
using ApiLibrary.Interfaces;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApplicationAPI.Constants;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;

namespace ApiLibrary
{
    public class AccountApiClient(IHttpClientFactory httpClientFactory) :  IAccountApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;       
        private readonly string _baseUrl = SystemConstants.Url.BaseApiUrl;
        public async Task<ApiResult<string>> Authenticate(LoginDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, SystemApiConst.Setting.StringContent);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.PostAsync(SystemApiConst.Account.LoginUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync())!;
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync())!;
        }
        public async Task<ApiResult<string>> RefreshToken(LoginDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, SystemApiConst.Setting.StringContent);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.PostAsync(SystemApiConst.Account.LoginUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync())!;
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync())!;
        }
        public async Task<List<EmployeeDTO>> GetEmployees(string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SystemApiConst.Setting.Bearer, token);
            var response = await client.GetAsync(SystemApiConst.Account.GetEmployees);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<EmployeeDTO>>(await response.Content.ReadAsStringAsync())!;
            }
            return [];
        }
    }
}
