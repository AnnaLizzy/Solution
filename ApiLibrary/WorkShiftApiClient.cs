using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary
{
    public class WorkShiftApiClient(HttpClient httpClient,IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient, httpClientFactory), IWorkShiftApiClient
        
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        public async Task<bool> AddWorkShift(WorkShiftViewModel workShift)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44300");
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(workShift.NameShift ?? ""), "Name" },
                { new StringContent(workShift.DescriptionShift ?? ""), "Description" },
                { new StringContent(workShift.StartTime.ToString()), "StartTime" },
                { new StringContent(workShift.EndTime.ToString()), "EndTime" }
            };
            var response = await client.PostAsync($"/api/WorkShift/", requestContent);
           return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkShift(int id)
        {
             return  await DeleteAsync($"api/WorkShift/{id}");
           
        }

        public async Task<WorkShiftViewModel> GetWorkShift(int id)
        {
            return await GetAsync<WorkShiftViewModel>($"api/WorkShift/{id}")
                ?? throw new Exception("khong tim thay ca lam viec");
        }

        public async Task<List<WorkShiftViewModel>> GetWorkShifts()
        {
            return await GetAsync<List<WorkShiftViewModel>>("api/WorkShift")
                ?? throw new Exception("Da co loi xay ra");
        }

        public async Task<bool> UpdateWorkShift( WorkShiftViewModel workShift)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44300");
            var requestContent = new MultipartFormDataContent
            {               
                { new StringContent(workShift.NameShift ?? ""), "Name" },
                { new StringContent(workShift.DescriptionShift ?? ""), "Description" },
                { new StringContent(workShift.StartTime.ToString()), "StartTime" },
                { new StringContent(workShift.EndTime.ToString()), "EndTime" }
            };
            var response = await client.PutAsync($"/api/WorkShift/{workShift.ShiftID}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
