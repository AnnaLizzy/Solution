using ApiLibrary.Interfaces;
using WebApplicationAPI.Constants;
using EmployeeViewModel = ApiLibrary.ViewModels.EmployeeViewModel;

namespace ApiLibrary
{
    public class EmployeeApiClient(HttpClient httpClient, IHttpClientFactory httpClientFactory) : BaseApiClient(httpClient, httpClientFactory), IEmployeeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<bool> CreateEmployee(EmployeeViewModel employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Please enter Employee");
            }
            if (employee.EmployeeID != 0 && !string.IsNullOrEmpty(employee.EmployeeNo) && !string.IsNullOrEmpty(employee.Password)
                && !string.IsNullOrEmpty(employee.EmployeeName))
            {
                throw new Exception("Please enter EmployeeNo, Password, EmployeeName");
            }
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(employee.EmployeeNo?.ToString() ?? string.Empty), "EmployeeNo" },
                { new StringContent(employee.Password?.ToString() ?? string.Empty ), "Password" },
                { new StringContent(employee.EmployeeName ?? string.Empty), "EmployeeName" },
                { new StringContent(employee.Gender?.ToString() ?? string.Empty), "Gender" },
                { new StringContent(employee.PhoneNumber?.ToString() ?? string.Empty), "PhoneNumber" },
                { new StringContent(employee.DateOfBirth.ToString()), "DateOfBirth" },
                { new StringContent(employee.IsDeleted.ToString()), "IsDeleted" },
                { new StringContent(employee.CreateTime.ToString()), "CreateTime" },
                { new StringContent(employee.Company?.ToString() ?? string.Empty), "Company" }
            };
            var response = await client.PostAsync("/api/Account/", requestContent);
            return response.IsSuccessStatusCode;


        }

        public async Task<bool> DeleteEmployee(int? id)
        {
            return await DeleteAsync($"api/Account/{id}");
        }

        public async Task<EmployeeViewModel> GetEmployee(int? id, string token)
        {
            return await GetAsyncToken<EmployeeViewModel>($"api/Account/{id}",token) ?? throw new Exception("Error occured");
        }

        public async Task<List<EmployeeViewModel>> GetEmployees(string token)
        {
            return await GetAsyncToken<List<EmployeeViewModel>>("api/Account",token) ?? throw new Exception("Error occured");
        }

        public Task<bool> UpdateEmployee(EmployeeViewModel employee)
        {
            var id = employee.EmployeeID;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.Url.BaseApiUrl);
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(employee.EmployeeNo?.ToString() ?? string.Empty), "EmployeeNo" },
                { new StringContent(employee.Password?.ToString() ?? string.Empty ), "Password" },
                { new StringContent(employee.EmployeeName ?? string.Empty), "EmployeeName" },
                { new StringContent(employee.Gender?.ToString() ?? string.Empty),"Gender" },
                { new StringContent(employee.PhoneNumber?.ToString() ?? string.Empty), "PhoneNumber" },
                { new StringContent(employee.DateOfBirth.ToString()), "DateOfBirth" },
                { new StringContent(employee.IsDeleted.ToString()), "IsDeleted" },
                { new StringContent(employee.CreateTime.ToString()), "CreateTime" },
                { new StringContent(employee.Company?.ToString() ?? string.Empty), "Company" }
            };
            var response = client.PutAsync($"/api/Account/{id}", requestContent).Result;
            return Task.FromResult(response.IsSuccessStatusCode);
        }
    }
}
