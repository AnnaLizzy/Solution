using ApiLibrary.Constants;
using ApiLibrary.Interfaces;
using ApiLibrary.ViewModels;
using WebApplicationAPI.Constants;

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
                throw new ArgumentNullException(nameof(workSchedule), "Please enter WorkSchedule");
            }

            // Kiểm tra các thuộc tính cần thiết
            if (workSchedule.EmployeeID == 0 || string.IsNullOrEmpty(workSchedule.LocationID) || workSchedule.ShiftID == 0 ||
                workSchedule.StartTime == DateTime.MinValue || workSchedule.EndTime == DateTime.MinValue)
            {
                throw new ArgumentException("Chưa được cung cấp đầy đủ thông tin", nameof(workSchedule));
            }


            string[] weekdaysArray = workSchedule.ByWeekday ?? [];
            string weekdaysString = string.Join(",", weekdaysArray);


            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);

                var requestContent = new MultipartFormDataContent
                    {
                        { new StringContent(workSchedule.EmployeeID.ToString()), "EmployeeID" },
                        { new StringContent(workSchedule.LocationID), "LocationID" },
                        { new StringContent(workSchedule.ShiftID.ToString()), "ShiftID" },
                        { new StringContent(workSchedule.StartTime.ToString() ?? ""), "StartTime" },
                        { new StringContent(workSchedule.EndTime.ToString() ?? ""), "EndTime" },
                        { new StringContent(workSchedule.Frequency?.ToString() ?? ""),"Frequency" },
                        { new StringContent(workSchedule.Interval.ToString()),"Interval" },
                        { new StringContent(weekdaysString),"ByWeekday" }

                    };

            // Gửi yêu cầu API
            var response = await client.PostAsync("/api/WorkSchedule/", requestContent);

            // Kiểm tra kết quả của yêu cầu và xử lý
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkSchedule(int? id)
        {
            return await DeleteAsync($"api/WorkSchedule/{id}");
        }

        public async Task<WorkScheduleViewModel> GetWorkSchedule(int? id)
        {
            return await GetAsync<WorkScheduleViewModel>(SystemApiConst.WorkSchedule.GetWorkSchedule+id)
                ?? throw new Exception("Cannot find work schedule");
        }

        public async Task<List<WorkScheduleViewModel>> GetWorkSchedules()
        {
            return await GetAsync<List<WorkScheduleViewModel>>(SystemApiConst.WorkSchedule.GetWorkSchedule)
                ?? throw new Exception("Error occurred");
        }

        public async Task<bool> UpdateWorkSchedule(WorkScheduleViewModel workSchedule)
        {
            var id = workSchedule.ScheduleID;
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
            var response = await client.PutAsync($"/api/WorkSchedule/{id}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
