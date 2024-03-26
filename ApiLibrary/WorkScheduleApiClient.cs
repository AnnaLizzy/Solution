using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using WebApplicationAPI.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary
{
    public class WorkScheduleApiClient(HttpClient httpClient,IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient), IWorkScheduleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        public async Task<bool> CreateWorkSchedule(CreateWorkScheduleViewModel workSchedule)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(workSchedule.EmployeeName ?? ""), "EmployeeName" }
            };
           
            var response = await client.PostAsync($"/api/WorkSchedule/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkSchedule(int? id)
        {
            return await DeleteAsync($"api/WorkSchedule/{id}");
        }

        public async Task<WorkScheduleViewModel> GetWorkSchedule(int? id)
        {
            return await GetAsync<WorkScheduleViewModel>($"api/WorkSchedule/{id}")
                ?? throw new Exception("Cannot find work schedule");
        }

        public async Task<List<WorkScheduleViewModel>> GetWorkSchedules()
        {
            return await GetAsync<List<WorkScheduleViewModel>>("api/WorkSchedule")
                ?? throw new Exception("Error occurred");
        }

        public async Task<bool> UpdateWorkSchedule(WorkScheduleViewModel workSchedule)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(workSchedule.EmployeeName ?? ""), "EmployeeName" },          
                { new StringContent(workSchedule.LocationID ?? ""), "LocationID" },
                { new StringContent(workSchedule.ShiftID.ToString() ?? ""), "ShiftID" },
                { new StringContent(workSchedule.StartTime.ToString() ?? ""), "StartTime" },
                { new StringContent(workSchedule.EndTime.ToString() ?? ""), "EndTime" }
            };
            var response = await client.PutAsync($"/api/WorkSchedule/{workSchedule.SchedulesID}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
