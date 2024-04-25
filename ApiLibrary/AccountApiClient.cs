using ApiLibrary.Constants;
using ApiLibrary.Interfaces;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
            var httpContent = new StringContent(json, Encoding.UTF8, ApiConst.Setting.StringContent);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.PostAsync(ApiConst.Url.LoginUrl, httpContent);
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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConst.Setting.Bearer, token);
            var response = await client.GetAsync(ApiConst.Url.GetEmployees);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<EmployeeDTO>>(await response.Content.ReadAsStringAsync())!;
            }
            return [];
        }
    }
}
