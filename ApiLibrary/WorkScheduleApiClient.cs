using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using WebApplicationAPI.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary
{
    public class WorkScheduleApiClient(HttpClient httpClient,IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient,httpClientFactory), IWorkScheduleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        public async Task<bool> CreateWorkSchedule(CreateWorkScheduleViewModel workSchedule)
        {
            // Kiểm tra dữ liệu đầu vào
            if (workSchedule == null)
            {
                throw new ArgumentNullException(nameof(workSchedule), "workSchedule không được null");
            }

            // Kiểm tra các thuộc tính cần thiết
            if (workSchedule.EmployeeID == 0 || string.IsNullOrEmpty(workSchedule.LocationID) || workSchedule.ShiftID == 0 ||
                workSchedule.StartTime == DateTime.MinValue || workSchedule.EndTime == DateTime.MinValue)
            {
                throw new ArgumentException("Chưa được cung cấp đầy đủ thông tin", nameof(workSchedule));
            }

     
  

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);

                var requestContent = new MultipartFormDataContent
                    {
                        { new StringContent(workSchedule.EmployeeID.ToString()), "EmployeeID" },
                        { new StringContent(workSchedule.LocationID), "LocationID" },
                        { new StringContent(workSchedule.ShiftID.ToString()), "ShiftID" },
                        { new StringContent(workSchedule.StartTime.ToString() ?? ""), "StartTime" },
                        { new StringContent(workSchedule.EndTime.ToString() ?? ""), "EndTime" },
                        { new StringContent(workSchedule.Frequenly?.ToString() ?? ""),"Frequenly" },
                        { new StringContent(workSchedule.Interval.ToString()),"Interval" },
                        { new StringContent(workSchedule.ByWeekday.ToString() ?? ""),"ByWeekday" }

                    };

            // Gửi yêu cầu API
            var response = await client.PostAsync("/api/WorkSchedule/", requestContent);

            // Kiểm tra kết quả của yêu cầu và xử lý
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Xử lý lỗi hoặc ngoại lệ
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi khi gửi yêu cầu API: {errorMessage}");
            }
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
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(workSchedule.EmployeeName ?? ""), "EmployeeName" },          
                { new StringContent(workSchedule.LocationID ?? ""), "LocationID" },
                { new StringContent(workSchedule.ShiftID.ToString() ?? ""), "ShiftID" },
                { new StringContent(workSchedule.StartTime.ToString() ?? ""), "StartTime" },
                { new StringContent(workSchedule.EndTime.ToString() ?? ""), "EndTime" },
                { new StringContent(workSchedule.Frequency?.ToString() ?? ""), "Frequency" },
                { new StringContent(workSchedule.Interval.ToString() ?? ""), "Interval" },
                { new StringContent(workSchedule.ByWeekday?.ToString() ?? ""), "ByWeekday" }
            };
            var response = await client.PutAsync($"/api/WorkSchedule/{workSchedule.SchedulesID}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
